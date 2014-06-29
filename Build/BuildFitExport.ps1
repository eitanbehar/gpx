Clear-Host

Write-Host "Tool Build/Deployment Script"

$BaseFolder = 'C:\Personal\gpx'

$msbuild = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.EXE"

Write-Host "Cleaning the build directory..."
Invoke-Expression "$msbuild $BaseFolder\ExportFit\ExportFit.sln /p:Configuration=Release /p:Platform='Any CPU' /t:clean /v:quiet /nologo"

Write-Host "Building Executable application..."
Invoke-Expression "$msbuild $BaseFolder\ExportFit\ExportFit.sln /p:Configuration=Release /p:Platform='Any CPU' /t:rebuild /v:quiet /nologo"

$newExeVersion = Get-ChildItem $BaseFolder\ExportFit\ExportFit\bin\Release\ExportFit.exe | Select-Object -ExpandProperty VersionInfo | % { $_.FileVersion }
$newLibVersion = Get-ChildItem $BaseFolder\ExportFit\ExportFit\bin\Release\FitUtils.dll | Select-Object -ExpandProperty VersionInfo | % { $_.FileVersion }

Write-Host "Building ClickOnce installer..."
#
# Because the ClickOnce target doesn't automatically update or sync the application version
# with the assembly version of the EXE, we need to grab the version off of the built assembly
# and update the Executable.csproj file with the new application version.
#
$ProjectXml = [xml](Get-Content $BaseFolder\ExportFit\ExportFit\ExportFit.csproj)
$ns = new-object Xml.XmlNamespaceManager $ProjectXml.NameTable
$ns.AddNamespace('msb', 'http://schemas.microsoft.com/developer/msbuild/2003')
$AppVersion = $ProjectXml.SelectSingleNode("//msb:Project/msb:PropertyGroup/msb:ApplicationVersion", $ns)
$AppVersion.InnerText = $newExeVersion
$TargetPath = Resolve-Path "$BaseFolder\ExportFit\ExportFit\ExportFit.csproj"
$ProjectXml.Save($TargetPath)

Invoke-Expression "$msbuild $BaseFolder\ExportFit\ExportFit\ExportFit.csproj /p:Configuration=Release /p:Platform=AnyCPU /t:publish /v:quiet /nologo"

#Write-Host "Deploying updates to network server..."
$LocalInstallerPath = (Resolve-Path "$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish").ToString() + "\*"
$RemoteInstallerPath = "\\rddp-vm21\c$\temp"
Copy-Item $LocalInstallerPath $RemoteInstallerPath -Recurse -Force

#Write-Host "Committing version increments to Perforce..."
#p4 submit -d "Updating Executable ClickOnce Installer to version $newExeVersion" //my/project/tool/path/Executable/Executable.csproj | Out-Null
#p4 submit -d "Updating Library to version $newLibVersion" //my/project/tool/path/Library/Properties/AssemblyInfo.cs | Out-Null
#p4 submit -d "Updating Execu