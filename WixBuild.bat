@set INPUT=
@set /P INPUT=Type Version (e.g. V2.1): %=%
Set AppName=SolvisSC2

if not defined ProgramFiles(x86) goto x86
rem 64Bit Systems
  Set X86ProgramFiles=%ProgramFiles(x86)%
rem Set MsBuildPath="%windir%\Microsoft.NET\Framework\v4.0.30319\MsBuild.exe"
Set MsBuildPath="%X86ProgramFiles%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MsBuild.exe"
rem only 64 bit projects  Set MsBuildPath="%X86ProgramFiles%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\amd64\MsBuild.exe"
rem Set MsBuildPath="%windir%\Microsoft.NET\Framework64\v4.0.30319\MsBuild.exe"
  goto x86End

:x86
rem 32Bit Systems
  Set X86ProgramFiles=%ProgramFiles%
rem Set MsBuildPath="%windir%\Microsoft.NET\Framework\v4.0.30319\MsBuild.exe"
Set MsBuildPath="%ProgramFiles%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MsBuild.exe"
:x86End

Set Wix3xPath=%X86ProgramFiles%\WiX Toolset v3.11\bin
"%Wix3xPath%\candle.exe" -nologo %AppName%.wxs -out %AppName%.wixobj -ext WixUtilExtension -ext WixUIExtension -ext WixNetFxExtension
"%Wix3xPath%\light.exe" -nologo %AppName%.wixobj -out %AppName%.msi -ext WixUtilExtension -ext WixUIExtension -ext WixNetFxExtension
del SolvisSC2_%INPUT%.zip
"%ProgramFiles%\7-Zip\7z.exe" a -tzip SolvisSC2_%INPUT%.zip SolvisSC2.msi
pause

