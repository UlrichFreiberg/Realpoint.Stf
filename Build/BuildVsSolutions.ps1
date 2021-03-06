param (
   [string] $buildlogDirname = "C:\temp\BuildLogs",
   [string] $buildRoot = $null
)

$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition

. "$scriptPath\Invoke-MsBuild.ps1"

$Stf_Root = (Resolve-Path "$scriptPath\..\").Path
$NuGetExe = (Resolve-Path "$Stf_Root\Nuget\Nuget.exe").Path

if ([string]::IsNullOrEmpty($buildRoot)) {
   $buildRoot = $Stf_Root
}

# ensure buildlog dir exists
if (-not (test-path $buildlogDirname)) {
  mkdir $buildlogDirname
}

Function buildOneSolution($PathToSolution) {
  Write-Host "Building [$PathToSolution]"

  Write-Host "   - Restoring NuGet packages"
  $NuGetExeOutput = & $NuGetExe restore $PathToSolution
  
  Write-Host "   - Starting build"
  $buildSucceeded = Invoke-MsBuild -Path $PathToSolution `
                    -BuildLogDirectoryPath $buildlogDirname `
                    -KeepBuildLogOnSuccessfulBuilds `
                    -MsBuildParameters "/target:Clean;Build /property:Configuration=Release;Platform=""Any CPU""" `
                    -Verbose #-Debug 

  if ($buildSucceeded) { 
    Write-Host "Build completed successfully." 
  } else { 
    Write-Host "`n`nBuild failed. Check the build log file for errors.`n`n" 
  }

  return $buildSucceeded
}

Function FindSolutions() {
  Write-Host "Looking for solutions at [$buildRoot]"
  $Solutions = Get-ChildItem -Path $buildRoot -Name "*.sln" -Recurse | Select-String -NotMatch "^SandBox"
  
  Write-Host "Found these solutions"
  $Solutions | Out-Host
  return $Solutions 
}



##############################################################################
#
# M A I N
#
##############################################################################

cls

$Solutions = FindSolutions
$hasBuildFailure = $false

foreach($Solution in $Solutions) {
  $FullNameOfSolution = Join-Path $buildRoot $Solution
  $buildSuccess = buildOneSolution -PathToSolution $FullNameOfSolution

  if (-not $buildSuccess) {
      $hasBuildFailure = $true
  } 
}

return $hasBuildFailure