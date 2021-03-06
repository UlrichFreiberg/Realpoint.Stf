param(
    [Parameter(Mandatory=$true)]
    [ValidateSet('Kernel', 'Utils')]
    [string] $TypeOfPackage,
    [switch] $PushPackage,
    [string] $NugetPackageDir = "c:\Temp\Stf\Temp\NuGetPackageDir"
)

$rootDir = Split-Path $MyInvocation.MyCommand.Path -Parent
$Stf_Root = (Resolve-Path "$rootDir\..\").Path
$NuGetExe = (Resolve-Path "$Stf_Root\Nuget\Nuget.exe").Path
$setVersionScript = "{0}\..\Build\SetBuildVersion.ps1" -f $rootDir
$buildScript = "{0}\..\Build\BuildVsSolutions.ps1" -f $rootDir

##########################################################################
# Get the name of the nuget package (changes with every new version)
##########################################################################
function Get-PackageName([string] $nugetPackageDir)
{
    $file = Get-ChildItem -Path $nugetPackageDir `
            | Where-Object { $_.Name -match "Mir\.Stf\..+\.nupkg" } `
            | Sort-Object -Descending `
            | Select-Object -First 1
    
    return $file.VersionInfo.FileName
}


##########################################################################
# Write a message
##########################################################################
function Write-InfoMessage([string] $Message)
{
    Write-Host $Message 
    Write-Host
}


##########################################################################
# Build the STF code
##########################################################################
function build-Stf()
{
    & $setVersionScript

    $buildFailure = & $buildScript

    if ($buildFailure)
    {
        Write-Error "One or more builderrors detected. Fix please!" -ErrorAction Stop
    }
}

##########################################################################
# Set $csprojLocation and $projectFile
##########################################################################
function set-projectLocation {
    $csprojLocation = $Null
    $projectFile = $Null

    switch ($TypeOfPackage)
    {
        'Kernel' { 
            $csprojLocation = "{0}\..\Source\StfKernel" -f $rootDir
            $projectFile = 'StfKernel.csproj'
        }
        'Utils' {
            $csprojLocation = "{0}\..\Source\StfUtils" -f $rootDir
            $projectFile = 'StfUtils.csproj'
        }
        Default { 
            Write-Error  'No type of package defined! Not creating nuget package' -ErrorAction Stop
        }
    }
    
    Set-Variable -Name csprojLocation -Value $csprojLocation -Scope Global   
    Set-Variable -Name projectFile    -Value $projectFile    -Scope Global   
}

##########################################################################
# 
# M A I N
# 
##########################################################################
Write-Host
Write-InfoMessage "Note that this script requires Nuget.exe. Get it here: https://dist.nuget.org/index.html"

build-Stf

set-projectLocation

Push-Location $csprojLocation

    if ($PushPackage)
    {
        if (test-path $NugetPackageDir) {
            Get-ChildItem -Path $NugetPackageDir `
            | Where-Object { $_.Name -match "Mir\.Stf\..+\.nupkg" } `
            | Remove-Item | Out-Null
        } else {
            mkdir -Path $NugetPackageDir -Force | Out-Null
        }    
    }

    # TODO: Receiving 500 error code when trying to push symbols package to symbolsource
    # nuget pack $kernelProjName -IncludeReferencedProjects -Symbols
    & $NuGetExe pack $projectFile -IncludeReferencedProjects -OutputDirectory $NugetPackageDir

    if ($PushPackage)
    {
        $packageName = Get-PackageName -nugetPackageDir $NugetPackageDir
        & $NuGetExe push $packageName
    }
    
Pop-Location