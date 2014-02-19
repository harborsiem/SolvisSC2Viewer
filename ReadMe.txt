erforderliche Installationen:
Visual Studio 2010 Express C# (oder h�here Version des Visual Studio)

Optionale Installationen:
WiX Toolset, Version 3.5
WixEdit, Version 0.7.5
Libre Office (Writer) zum Editieren von HTML-Files
HTML Help Workshop, Version 4.74.8702
TortoiseSVN Version 1.7.x oder 1.8.x zur Versionsverwaltung
WinRar als Zipper




F�r die korrekte Projektstruktur m�ssen die Verzeichnisse
app, files, help und Properties
in das Verzeichnis SolvisSC2Viewer verschoben werden.

Weiterhin m�ssen die Dateien
MainForm.cs, MainForm.Designer.cs, MainForm.resx, Program.cs und SolvisSC2Viewer.csproj
in das Verzeichnis SolvisSC2Viewer verschoben werden.

Ab Zeile 60 in der Datei SolvisSC2Viewer.csproj sind die folgenden Anweisungen

  <PropertyGroup>
    <SignAssembly>true</SignAssembly>
  </PropertyGroup>
  <PropertyGroup>
    <AssemblyOriginatorKeyFile>..\..\..\Signature\Harbor.keys</AssemblyOriginatorKeyFile>
  </PropertyGroup>

zu entfernen, da der Assembly Strongname Keyfile nicht mitgeliefert wird.


Hinweis nur f�r Benutzer, die die freien Formeln �ber Visual Studio programmieren wollen:

F�r eine erfolgreiche Compilation des Projekts "Formula" ist die installierte SolvisSC2Viewer.exe 
("Program Files\Solvis\SolvisSC2\SolvisSC2Viewer.exe")
in das ProjektVerzeichnis SolvisSC2Viewer\bin\Release zu kopieren.

In der Datei Formula\Formulas.cs m�ssen die Methoden Formula1 bis Formula5
und FormulaSolarVSG und FormulakW mit selbstgeschriebenen ProgrammCode erg�nzt werden.
Der Tag <HasFormulaDll> in der User.config Datei muss auf den Wert true gesetzt werden.

Die erzeugte Datei Formula.dll ist nach "Program Files\Solvis\SolvisSC2\" zu kopieren.