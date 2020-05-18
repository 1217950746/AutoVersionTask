Clear-Host

$ErrorActionPreference = "Stop"

$Current = Split-Path -Parent $MyInvocation.MyCommand.Definition
Set-Location $Current

function Remove ($path) {
    if (Test-Path $path) {
        "删除 $path"
        Remove-Item $path -Recurse
    }
}

Remove "$Current\bin"
Remove "$Current\Packages"

dotnet build -c Debug /p:Platform=x64
dotnet build -c Debug /p:Platform=x86

$version = (Get-Item "$Current\bin\x64\AutoVersionTask.dll").VersionInfo.FileVersion
dotnet pack --no-build --output Packages -p:NuspecFile=$Current\.nuspec -p:NuspecProperties="version=$version"

Write-Host "按任意键退出..."
[Console]::ReadKey() | Out-Null