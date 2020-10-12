@echo off

echo "nuget locations:"
dotnet nuget locals all --list

set ACISPackageManager=%HOMEPATH%\.nuget\packages\acisextensionsdk\1.0.4.1310\Tools\WapdSMEPackageManager_x64.exe

set _ENV=Test
%ACISPackageManager% BuildPackage -InputDir:C:\Git\Liftr.GenevaActions\src\Liftr.ACIS\bin\Debug\net462 -OutputDir:C:\Git\Liftr.GenevaActions\src\Liftr.ACIS\bin\Debug\AcisPackages\ -PackageName:Liftr_%_ENV% -SMEConfig:LiftrExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.dll