@echo off
dotnet build -c Debug /p:Platform=x64
dotnet build -c Debug /p:Platform=x86
nuget pack -OutputDirectory Packages