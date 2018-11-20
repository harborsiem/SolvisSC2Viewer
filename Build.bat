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
Set HtmlHelp="%X86ProgramFiles%\HTML Help Workshop\hhc"
%MsBuildPath% SolvisSC2Viewer.sln /p:Configuration=Debug /p:Platform="x86"
%MsBuildPath% SolvisSC2Viewer.sln /p:Configuration=Release /p:Platform="x86"
cd SolvisSC2Viewer\help
%HtmlHelp% SolvisViewer.hhp
copy /Y /B SolvisViewer.chm ..\bin\Release\SolvisViewer.chm
copy /Y /B SolvisViewer.chm ..\bin\Debug\SolvisViewer.chm
cd ..\..
"%Wix3xPath%\candle.exe" -nologo %AppName%.wxs -out %AppName%.wixobj -ext WixUtilExtension -ext WixUIExtension -ext WixNetFxExtension
"%Wix3xPath%\light.exe" -nologo %AppName%.wixobj -out %AppName%.msi -ext WixUtilExtension -ext WixUIExtension -ext WixNetFxExtension
pause