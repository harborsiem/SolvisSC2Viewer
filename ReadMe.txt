erforderliche Installationen:
Visual Studio 2017 Community mit C# (oder höhere Version des Visual Studio)

Optionale Installationen:
WiX Toolset, Version 3.11
WixEdit, Version 0.7.5
Libre Office (Writer) zum Editieren von HTML-Files
HTML Help Workshop, Version 4.74.8702
Git und TortoiseGit zur Versionsverwaltung
7-Zip als Zipper



Ab Zeile 60 in der Datei SolvisSC2Viewer.csproj sind die folgenden Anweisungen

  <PropertyGroup>
    <SignAssembly>true</SignAssembly>
  </PropertyGroup>
  <PropertyGroup>
    <AssemblyOriginatorKeyFile>..\..\..\Signature\Harbor.keys</AssemblyOriginatorKeyFile>
  </PropertyGroup>

zu entfernen, da der Assembly Strongname Keyfile nicht mitgeliefert wird.


Hinweis nur für Benutzer, die die freien Formeln über Visual Studio programmieren wollen:

Für eine erfolgreiche Compilation des Projekts "Formula" ist die installierte SolvisSC2Viewer.exe 
("Program Files\Solvis\SolvisSC2\SolvisSC2Viewer.exe")
in das ProjektVerzeichnis SolvisSC2Viewer\bin\Release zu kopieren.

In der Datei Formula\Formulas.cs müssen die Methoden Formula1 bis Formula5
und FormulaSolarVSG und FormulakW mit selbstgeschriebenen ProgrammCode ergänzt werden.
Der Tag <HasFormulaDll> in der User.config Datei muss auf den Wert true gesetzt werden.

Die erzeugte Datei Formula.dll ist nach "Program Files\Solvis\SolvisSC2\" zu kopieren.

Achtung:
Bei einem 64Bit Windows heißt der Ordner ("Program Files (x86)\Solvis\SolvisSC2\") 
