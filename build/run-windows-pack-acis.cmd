@echo off

echo "nuget locations:"
dotnet nuget locals all --list

IF "%HOMEPATH%"=="" ( 
    echo "set HOMEPATH in CDPx"
    set HOMEPATH=C:\Users\ContainerAdministrator
)

set ACISPackageManager=%HOMEPATH%\.nuget\packages\acisextensionsdk\1.0.4.1310\Tools\WapdSMEPackageManager_x64.exe
echo "ACISPackageManager: %ACISPackageManager%"

set _ENV=Test
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Liftr_%_ENV% -SMEConfig:LiftrExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Datadog\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Datadog_%_ENV% -SMEConfig:DatadogExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Datadog.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Confluent\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Confluent_%_ENV% -SMEConfig:ConfluentExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Confluent.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Logz\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Logz_%_ENV% -SMEConfig:LogzExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Logz.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Elastic\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Elastic_%_ENV% -SMEConfig:ElasticExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Elastic.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Dynatrace\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Dynatrace_%_ENV% -SMEConfig:DynatraceExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Dynatrace.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Nginx\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Nginx%_ENV% -SMEConfig:NginxExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Nginx.dll

set _ENV=Prod
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Liftr_%_ENV% -SMEConfig:LiftrExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Datadog\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Datadog_%_ENV% -SMEConfig:DatadogExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Datadog.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Confluent\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Confluent_%_ENV% -SMEConfig:ConfluentExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Confluent.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Logz\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Logz_%_ENV% -SMEConfig:LogzExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Logz.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Elastic\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Elastic_%_ENV% -SMEConfig:ElasticExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Elastic.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Dynatrace\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Dynatrace_%_ENV% -SMEConfig:DynatraceExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Dynatrace.dll
%ACISPackageManager% BuildPackage -InputDir:%~dp0..\src\Liftr.ACIS.Nginx\bin\Release\net462 -OutputDir:%~dp0..\out\AcisPackages\ -PackageName:Nginx%_ENV% -SMEConfig:NginxExtension.%_ENV%.config -SMEAssembly:Microsoft.Liftr.ACIS.Nginx.dll