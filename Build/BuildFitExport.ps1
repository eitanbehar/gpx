Clear-Host

Write-Host "Tool Build/Deployment Script"

$BaseFolder = 'C:\Personal\gpx'

$msbuild = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.EXE"

#Invoke-Expression "$msbuild $BaseFolder\ExportFit\ExportFit.sln /p:Configuration=Release /p:Platform='Any CPU' /t:clean /v:quiet /nologo"
#Invoke-Expression "$msbuild $BaseFolder\ExportFit\ExportFit.sln /p:Configuration=Release /p:Platform='Any CPU' /t:rebuild /v:quiet /nologo"

$newExeVersion = '1.0.0.0'
$newExeVersionFolder = '1_0_0_0'

#$ProjectXml = [xml](Get-Content $BaseFolder\ExportFit\ExportFit\ExportFit.csproj)
#$ns = new-object Xml.XmlNamespaceManager $ProjectXml.NameTable
#$ns.AddNamespace('msb', 'http://schemas.microsoft.com/developer/msbuild/2003')
#$AppVersion = $ProjectXml.SelectSingleNode("//msb:Project/msb:PropertyGroup/msb:ApplicationVersion", $ns)
#$AppVersion.InnerText = $newExeVersion
#$TargetPath = Resolve-Path "$BaseFolder\ExportFit\ExportFit\ExportFit.csproj"
#$ProjectXml.Save($TargetPath)

#Invoke-Expression "$msbuild $BaseFolder\ExportFit\ExportFit\ExportFit.csproj /p:Configuration=Release /p:Platform=AnyCPU /t:publish /v:quiet /nologo"

$username = Read-Host "Please enter your username"
$password = Read-Host -assecurestring "Please enter your password"

#Upload to FTP site

#rm -r directory
c:\bin\curl.exe --user $username:$password ftp://$username.net/  -X 'DELE /public_html/apps/Application%20Files/ExportFit_*'

$file = "$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\ExportFit.application"
c:\bin\curl.exe --user $username:$password -v -T $file ftp://$username.net//public_html/apps/

$files = @( "$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_1_0_0_0\ExportFit.exe.config.deploy",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_1_0_0_0\ExportFit.exe.deploy",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_1_0_0_0\ExportFit.exe.manifest",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_1_0_0_0\Fit.dll.deploy",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_1_0_0_0\FitUtils.dll.deploy",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_1_0_0_0\mp3device.ico.deploy",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_1_0_0_0\smartmed.ico.deploy" )

foreach($file in $files)
{
	Write-Host "Uploading file " $file
	c:\bin\curl.exe --user $username:$password -v -T $file ftp://$username.net//public_html/apps/Application%20Files/ExportFit_1_0_0_0/
}
