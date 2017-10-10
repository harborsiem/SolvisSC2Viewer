# Release Notes

## Version 2.1


- Hilfe ergänzt mit Dateibeschreibung für so*.txt und mi*.txt
- Sensoren S25 bis S30 ergänzt (Bedeutung in der Hilfe für mi*.txt Dateien)
- Bei mi*.txt Dateien wird für die Sensoren und Aktoren (Checkboxen) im Tooltip zusätzlich Solvis-Name und Einheit (aus Logdatei) angezeigt. z.B. [S1, °C]
- SolvisControl Version ZR132/Nxxx: Logdateien „mi*.txt“ korrigiert.

## Version 2.0
- SolvisControl Version ZR132/Nxxx wird unterstützt: Versionseinstellung in der Konfiguration. Neuer Dateityp für Logdateien „mi*.txt“ ist zusätzlich in der Auswahl beim Datei Öffnen Dialog verfügbar.
- Für Solar VSG und Solar KW ist der Pulswert des Volumenstromgebers und die spezifische Wärmekapazität der Solarflüssigkeit einstellbar.
- Korrigierte Formeln für Solar VSG und Solar KW
- „Freie Formeln“: Bei Neueingabe oder Änderungen ist kein Neustart nötig
- Fehlerbehebungen.

## Version 1.3
- Ein Tages Modus für Logdateien. Wenn der Menupunkt aktiviert ist, dann wird nach dem Öffnen einer Logdatei nur ein Tag angezeigt. Die restlichen Tage der Logdatei können über die „vorheriger Tag“-, „nächster Tag“-Schalter in der Toolbar angezeigt werden.
- mehrere Logdateien beim „Datei Öffnen“ auswählbar. Die erste Datei wird direkt zur Anzeige gebracht. Mit den zusätzlichen „vorherige Datei“-, „nächste Datei“-Schaltern in der Toolbar werden die übrigen Dateien zur Anzeige gebracht.
- Eigene Formeln für Solar VSG (S17) und Solar KW (P02) möglich für die Anzeige im Chart.
- Erweiterung „Freie Formeln“ auf 5 Stück.
- „Freie Formeln“ auch als selbsterstellte Dll (Formula.dll) möglich. Anfragen beim Author.
- Zeitübersicht wird jetzt im Dokumentationsverzeichnis des Benutzers abgespeichert.
- Fehlerbehebungen

## Version 1.2.1
- schnellere Chartanzeige (Löschen von Datenreihen wurde wesentlich beschleunigt)
- Anzeigen und Druckfunktion für Dateien „paramact.txt“ und „zaehlst.txt“ vorbereitet (aktuelle Parametereinstellungen, Zählerstände). Zum Ausprobieren und Testen der Funktionen sind diese aktivierbar in Datei User.config (Xml-Tag: <Prototype>true</Prototype>)
- Fehlerbehebungen, Ergänzungen im Programm und Dokumentation

**Bekannte Probleme**

Programmstart nach erster Installation bringt einen Splashscreen mit Text "Ungehandelte Ausnahme ..." Bitte Schaltfläche "Weiter" betätigen und Programm beenden. Beim nächsten Programmstart ist alles OK.

## Version 1.2
- Umschalter Fadenkreuz, Zoom Auswahl im Chart
- verbesserte Zeitachsen Beschriftung
- drei freie Formeln für Chartanzeige (Siehe Hilfe>Dokumentation)
- Anzeige Zeiteinstellungen

## Version 1.1
- Logos geändert, MSI-Setup korrigiert
- Formel für Solar VSG korrigiert
- Tooltips für Auswahlboxen (Sensor, Aktor, Option), längerer Text möglich !
- Default Farben korrigiert
- Speicherung der bisherigen User.Config Datei nach Update des Programms unter UserVersion.Config
- Dokumentation korrigiert und erweitert