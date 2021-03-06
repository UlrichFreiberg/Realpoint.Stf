$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition
$VersionFile = join-path $scriptPath "..\version.txt"


##########################################################################
# Get all AssemblyInfo.cs files
##########################################################################
function Get-AssemblyInfoFiles()
{
    Push-Location (join-path $scriptPath "..\")
         $assemblyInfos = Get-ChildItem -Filter "AssemblyInfo.cs" -Recurse | Where-Object { $_.FullName -notmatch "(\\SandBox\\|\\Demos\\)" }
    Pop-Location
    return $assemblyInfos
}


##########################################################################
# Set the right version in all assemblyinfo files
##########################################################################
function Set-Version([Object[]] $Files, [string] $NewVersion)
{
    function Update-Version([string] $Pattern, [string] $Text, [string] $TheNewVersion)
    {
        $match = [Regex]::Match($Text, $Pattern)
        if (-not $match.Success)
        {
            return $Text
        }

        $replacementString = "{0}{1}{2}" -f $match.Groups[1].Value, $TheNewVersion, $match.Groups[3].Value
        $edited = [Regex]::Replace($fileContents, $Pattern, $replacementString)
        return $edited
    }
    
    foreach($file in $Files)
    {
       # 'Get-Content | Out-string' puts a blank line at the end of the read text. This does not.
       $fileContents = [System.IO.File]::ReadAllText($file.FullName)
       
       if ([string]::IsNullOrEmpty($fileContents))
       {
            continue
       }

       $assemblyVersionPatterns = "(\[assembly: AssemblyVersion\(\`")(\d+\.\d+\.\d+\.\d+)(\`"\)\])", "(\[assembly: AssemblyFileVersion\(\`")(\d+\.\d+\.\d+\.\d+)(\`"\)\])" 
       foreach ($versionPattern in $assemblyVersionPatterns)
       {
           $fileContents = Update-Version -Pattern $versionPattern -Text $fileContents -TheNewVersion $NewVersion             
       }

       if ([string]::IsNullOrEmpty($fileContents))
       {
            continue
       }

       try
       {
           [System.IO.File]::WriteAllText($file.FullName, $fileContents, [System.Text.Encoding]::UTF8)
           # $file.FullName $fileContents -Encoding UTF8
       }
       catch [System.Exception]
       {
           if ($Error.Count > 0)
           {
                Write-Error $Error[0] -ErrorAction Continue                         
           }

           Write-Error ("Unable to update assembly version in file: [{0}]" -f $file.FullName) -ErrorAction Stop
       }
    }  
}


##########################################################################
# 
# M A I N
#
##########################################################################
if (-not (Test-Path $VersionFile))
{
    Write-Error "No version file found!" -ErrorAction Stop 
}

$CurrentVersion = Get-Content $VersionFile | Out-String

$Tokens = $CurrentVersion.Split(".")

$Major    = [int]( $Tokens[0])
$Minor    = [int]( $Tokens[1])
$BuildNo  = [int]( $Tokens[2]) + 1
$Revision = (Get-Date).ToString("MMddy")
$Revision = $Revision.Substring(0,4) + $Revision.Substring(5,1)
$Version  = ([string] $Major) + "." + ([string] $Minor) + "." + ([string]$BuildNo) + "." + ([string]$Revision)

Write-Host "New Version is set to [$Version]"
Set-Content -Path $VersionFile $Version

$assemblyInfos = Get-AssemblyInfoFiles
Set-Version -Files $assemblyInfos -NewVersion $Version

# fra en AssembyInfo.cs:
# // Version information for an assembly consists of the following four values:
# //
# //      Major Version
# //      Minor Version 
# //      Build Number
# //      Revision