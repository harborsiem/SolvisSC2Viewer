@set INPUT=
@set /P INPUT=Type Version (e.g. V1.2): %=%
"%ProgramFiles%\Windows Installer XML v3.5\bin\candle.exe" -nologo .\SolvisSC2.wxs -out .\SolvisSC2.wixobj  -ext WixUIExtension  -ext WixNetFxExtension
"%ProgramFiles%\Windows Installer XML v3.5\bin\light.exe" -nologo .\SolvisSC2.wixobj -out .\SolvisSC2.msi  -ext WixUIExtension  -ext WixNetFxExtension
del SolvisSC2_%INPUT%.zip
"%ProgramFiles%\WinRar\winrar.exe" a -afzip SolvisSC2_%INPUT%.zip SolvisSC2.msi
pause

