@set INPUT=
@set /P INPUT=Type Version (e.g. V2.1): %=%
Set ProgName=SolvisSC2
Set Wix3xPath=%ProgramFiles%\WiX Toolset v3.11\bin
"%Wix3xPath%\candle.exe" -nologo %ProgName%.wxs -out %ProgName%.wixobj -ext WixUtilExtension -ext WixUIExtension -ext WixNetFxExtension
"%Wix3xPath%\light.exe" -nologo %ProgName%.wixobj -out %ProgName%.msi -ext WixUtilExtension -ext WixUIExtension -ext WixNetFxExtension
del SolvisSC2_%INPUT%.zip
"%ProgramFiles%\7-Zip\7z.exe" a -tzip SolvisSC2_%INPUT%.zip SolvisSC2.msi
pause

