# HAP

[Download](http://www.google.de)

## Lokale Daten

Die lokalen Daten bestehen aus den Drops und den Bildern.

#### Drops



#### ImageStorage

Der ImageStorage ist ein Dictionary, welches alle benötigten Bilder gespeichert und ihren jeweiligen Links zugeordnet hat.

## Objektmanager

Der Objektmanager verwaltet die lokalen Daten.

## Verbindung

Die Verbindung wird über einen Connector aufgebaut, der die Drops aus einer externen Quelle lädt.

## Interface

#### Ladebildschirm

<img src="https://raw.githubusercontent.com/Saritus/hap/master/docs/LoadingScreen.png" alt="LoadingScreen" height="300">

Während des Ladebildschirms werden die Drops und die Bilder heruntergeladen.

#### Hauptbildschirm

<img src="https://raw.githubusercontent.com/Saritus/hap/master/docs/MainScreen.png" alt="MainScreen" height="300">

In der MainActivity werden alle im Objektmanager vorhandenen Drops als Buttons an der richtigen Stelle auf der Karte angezeigt.

#### Dropliste

<img src="https://raw.githubusercontent.com/Saritus/hap/master/docs/History.png" alt="History" height="300">

In der HistoryActivity wird die Listenanzeige mit den Daten der Drops gefüllt.

#### Detailansicht

<img src="https://raw.githubusercontent.com/Saritus/hap/master/docs/DropDetail.png" alt="DropDetail" height="300">

In der DropDetailsActivity werden die Interface-Elemente der DropDetailsView mit den Daten eines bestimmten Drops gefüllt.

#### Neuen Drop erstellen

<img src="https://raw.githubusercontent.com/Saritus/hap/master/docs/NewDrop.png" alt="NewDrop" height="300">

In der NewDropActivity werden die vom Nutzer eingegebenen Daten ausgewertet und als neuer Drop abgespeichert.

## Beteiligte

Projektmanager: [Tom Ille](https://github.com/JamesTheButler)

Konzeptor: Konstantin George

Gestaltung: Thomas Theling

Front-End: [Julian Fuchs](https://github.com/Julian93MI)

Back-End: [Sebastian Mischke](https://github.com/Saritus)
