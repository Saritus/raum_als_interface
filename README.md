# HAP

[Download](http://www.google.de)

## Werbung

<video width="100%" controls>
  <source src="https://github.com/Saritus/hap/blob/master/docs/advertisingvideo.mp4?raw=true" type="video/mp4">
<a href="https://github.com/Saritus/hap/blob/master/docs/advertisingvideo.mp4?raw=true">Download Video</a>
</video>

## Anwendung

<video width="100%" controls>
  <source src="https://github.com/Saritus/hap/blob/master/docs/applicationvideo.mp4?raw=true" type="video/mp4">
<a href="https://github.com/Saritus/hap/blob/master/docs/applicationvideo.mp4?raw=true">Download Video</a>
</video>

## Projekt

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/classdiagram.png" alt="Klassendiagramm" height="300">

## Lokale Daten

#### Drops

<img src="https://github.com/Saritus/hap/blob/master/docs/drop.png?raw=true" alt="Drop" width="100%">

Die Grundlage von hap sind die sogenannten Drops. Das, was für den Kalender der Termin ist, ist für HAP der Drop. Er speichert Informationen, wie ID, Name, Beschreibung, Kategorie, Ort, Zeit und Bild. Außerdem wird im Drop gekennzeichnet, ob ein Nutzer diesen Drop ignoriert hat.

#### ImageStorage

Der ImageStorage ist für die lokale Verwaltung von Bildern zuständig. Er besitzt ein Nachschlagewerk, welches jedem Bild einen eindeutigen Verweis zugeordnet. Das sorgt dafür, dass Drops, die das gleiche Bild besitzen, dieses nicht mehrfach an unterschiedlichen Stellen gespeichert haben müssen. Außerdem kümmert sich der ImageStorage um das Herunterladen von Bildern aus dem Internet, sollte es sich bei dem eingetragenen Verweis um eine URL handeln.

Programmiert ist der ImageStorage nach dem Prinzip des [Singleton-Patterns][singleton], welches dafür sorgt, dass unterschiedliche Activities auf dieselbe Instanz zugreifen können, ohne sie mittels eines Parameters zu übergeben.

## DropManager

<img src="https://github.com/Saritus/hap/blob/master/docs/dropmanager.png?raw=true" alt="DropManager" width="100%">

Der DropManager verwaltet sämtliche im System vorhandenen Drops. Er bietet mehrere Funktionen um die Liste nach bestimmten Kriterien, wie Gebäude oder Kategorie, zu filtern, nach Drops zu suchen, alle Drops in einer Datei zu speichern oder von einer Datei Drops zu laden, mittels eines Connectors sich mit einer Datenbank zu verbinden und somit Drops mit anderen Nutzern zu synchronisieren.

## Verbindung

<img src="https://github.com/Saritus/hap/blob/master/docs/fakeconnector.png?raw=true" alt="FakeConnector" width="100%">

Die Verbindung zu einer externen Quelle wird über ein Klasse gelöst, die das Connector-Interface implementiert. Dies sorgt dafür, dass die Art der Verbindung schnell und leicht gewechselt werden kann, da eine alternative Verbindungsklasse ebenfalls die Funktionen getNewDrops und saveNewDrop implementiert haben muss. Ebenso ist es möglich, einen FakeConnector zu benutzen, die zwar reagiert wie ein tatsächlicher Connector, in Wirklichkeit aber sämtliche Daten lokal vorliegen hat.

## Interface

#### Ladebildschirm

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/LoadingScreen.png" alt="LoadingScreen" height="300">

Während des Ladebildschirms werden die bisher heruntergeladenen und erstellten Drop aus einer Datei geladen. Anschließend wird geprüft, ob es neue Drops auf dem Server gibt, so dass diese ebenfalls dem DropManager hinzugefügt werden können. Sollte es bei den neuen Drops auch neue Bilder geben, so werden auch diese heruntergeladen und im ImageStorage vermerkt.

#### Hauptbildschirm

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/MainScreen.png" alt="MainScreen" height="300">

In der MainActivity werden alle im Objektmanager vorhandenen Drops als Buttons an der richtigen Stelle auf der Karte angezeigt.

#### Dropliste

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/History.png" alt="History" height="300">

In der HistoryActivity werden alle Drops des DropManager, sortiert nach ihrem jeweiligen Startdatum, in der Listenansicht angezeigt. Dafür wird für jeden Drop ein TableItem erstellt, welches die ID, den Namen, den Ort, die Startzeit und das Logo entsprechend der Kategorie des Drop besitzt. Diese TableItems werden dann der ListView hinzugefügt.

#### Detailansicht

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/DropDetail.png" alt="DropDetail" height="300">

Die Detailansicht dient dazu, dem Nutzer sämtliche in einem Drop gespeicherte Informationen anzuzeigen. Dafür werden Name, Beschreibung, Start- und Endzeit sowie Ort in einer einfachen Textansicht dargestellt. Für die Kategorie wird ein entsprechendes Icon abgebildet. Außerdem wird das im Drop eingetragene Bild angezeigt und wechselt beim Klick darauf in den Vollbildmodus. Zudem ist es möglich, sich die Position des Drop separiert auf einer Karte anzuschauen. Ebenfalls kann der Nutzer den Drop ignorieren, so dass er in der Hauptansicht nicht mehr auf der Karte abgebildet wird.

#### Neuen Drop erstellen

<img src="https://cdn.rawgit.com/Saritus/hap/master/docs/NewDrop.png" alt="NewDrop" height="300">

Das Erstellen eines neuen Drops erfolgt in einer gesonderten Eingabemaske. Hier kann der Nutzer den Namen, die Beschreibung und den Ort des Drop in einem Textfeld eingeben. Für den Ort wird anschließend in einer vorgefertigten Tabelle geschaut, an welcher Position sich der eingegebene Raum befindet. Die Start- und Endzeit wird vom Nutzer in einer sich zusätzlich öffnenden Kalenderansicht ausgewählt und danach intern in Form einer DateTime gespeichert. Wenn der Nutzer ein Bild für den Drop hinzufügen möchte, so wird dafür der Android-interne "Foto auswählen"-Dialog geöffnet und der Nutzer kann sich entweder eines der bereits auf dem Handy befindlichen Bilder aussuchen, oder über das Kamera-Menü ein neues aufnehmen und dieses benutzen. Nachdem sich für ein Bild entschieden wurde, so wird dieses dem ImageStorage hinzugefügt und der Verweis darauf im Drop hinterlegt.

## Beteiligte

Projektmanager: [Tom Ille](https://github.com/JamesTheButler)

Konzeptor: Konstantin George

Gestaltung: [Thomas Theling](https://www.thomastheling.com)

Front-End: [Julian Fuchs](https://github.com/Julian93MI)

Back-End: [Sebastian Mischke](https://github.com/Saritus)

[singleton]: https://msdn.microsoft.com/en-us/library/ff650316.aspx
