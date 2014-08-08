@echo off

IF EXIST "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe" (
  SET MSBUILDEXE=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe
) ELSE IF EXIST "C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" (
  SET MSBUILDEXE=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
) ELSE (
  ECHO ERROR: Could not find msbuild.exe
  EXIT /B 1
)


echo Building DishOrder.sln...
"%MSBUILDEXE%" /t:Rebuild /p:Configuration=Release Dishes.sln
IF ERRORLEVEL 1 (
  ECHO Error building Dishes.sln
  EXIT /B 1
)


IF EXIST "Dishes.Tests\bin\Release\Dishes.Tests.exe" (
	echo Start run UnitTest...
	call Dishes.Tests\bin\Release\Dishes.Tests.exe
) ELSE (
  ECHO ERROR: Could not find Dishes.Tests.exe
  EXIT /B 1
)

exit /b 0

echo on