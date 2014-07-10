﻿Clear-Host

Write-Host "Tool Build/Deployment Script"

$BaseFolder = 'c:\personal\gpx'

$msbuild = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.EXE"

Invoke-Expression "$msbuild $BaseFolder\ExportFit\ExportFit.sln /p:Configuration=Release /p:Platform='Any CPU' /t:clean /v:quiet /nologo"
Invoke-Expression "$msbuild $BaseFolder\ExportFit\ExportFit.sln /p:Configuration=Release /p:Platform='Any CPU' /t:rebuild /v:quiet /nologo"

$newExeVersion = '1.0.12.0'
$newExeVersionFolder = '1_0_12_0'

Invoke-Expression "$msbuild $BaseFolder\ExportFit\ExportFit\ExportFit.csproj /p:Configuration=Release /p:Platform=AnyCPU /t:publish /v:quiet /nologo"

$credential = Get-Credential -UserName baconao -Message Username

Write-Host "Deleting Previous Version"
Invoke-RestMethod -Method Delete -Uri https://api.bintray.com/packages/baconao/tools/ExportFIT/versions/1.0.0.0 -Credential $credential

$file = $BaseFolder + '\ExportFit\ExportFit\bin\Release\app.publish\ExportFit.application'
$uri = 'https://api.bintray.com/content/baconao/tools/ExportFIT/1.0.0.0/ExportFit.application'

Write-Host "Uploading file " $file
Invoke-RestMethod -Method Put -Uri $uri -InFile $file -Credential $credential 

$files = @( "$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_$newExeVersionFolder\ExportFit.exe.config.deploy",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_$newExeVersionFolder\ExportFit.exe.deploy",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_$newExeVersionFolder\ExportFit.exe.manifest",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_$newExeVersionFolder\Fit.dll.deploy",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_$newExeVersionFolder\FitUtils.dll.deploy",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_$newExeVersionFolder\mp3device.ico.deploy",
			"$BaseFolder\ExportFit\ExportFit\bin\Release\app.publish\Application Files\ExportFit_$newExeVersionFolder\smartmed.ico.deploy" )

foreach($file in $files)
{
	Write-Host "Uploading file " $file
	$name = [System.IO.Path]::GetFileName($file)
	$uri = 'https://api.bintray.com/content/baconao/tools/ExportFIT/1.0.0.0/Application Files/ExportFit_' + $newExeVersionFolder + '/' + $name	
	Invoke-RestMethod -Method Put -Uri $uri -InFile $file -Credential $credential 	
}

Write-Host "Publishing files"
Invoke-RestMethod -Method Post -Uri https://api.bintray.com/content/baconao/tools/ExportFIT/1.0.0.0/publish -Credential $credential 