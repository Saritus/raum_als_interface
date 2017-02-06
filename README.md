# HAP

## Interface

#### Ladebildschirm

###### LoadScreen

<img src="http://i.imgur.com/OUkLi.gif" alt="LoadScreen" height="300">

###### LoadScreenActivity

Während des Ladebildschirms werden die Drops und die Bilder heruntergeladen.

#### Hauptbildschirm

###### MainScreen

<img src="/docs/ignore.gif" alt="MainScreen" height="300">

###### MainActivity

In der MainActivity werden alle im Objektmanager vorhandenen Drops als Buttons an der richtigen Stelle auf der Karte angezeigt.

#### Dropliste

###### HistoryView

<img src="http://i.imgur.com/60bts.gif" alt="HistoryView" height="300">

###### HistoryActivity

In der HistoryActivity wird die Listenanzeige mit den Daten der Drops gefüllt.

#### Detailansicht

###### DropDetailsView

<img src="https://i.redd.it/ol7ea42tl1dy.gif" alt="DropDetailsView" height="300">

###### DropDetailsActivity

In der DropDetailsActivity werden die Interface-Elemente der DropDetailsView mit den Daten eines bestimmten Drops gefüllt.

#### Neuen Drop erstellen

###### NewDropView

<img src="https://i.redd.it/2vjq5pxf209y.gif" alt="NewDropView" height="300">

###### NewDropActivity

In der NewDropActivity werden die vom Nutzer eingegebenen Daten ausgewertet und als neuer Drop abgespeichert.

## Objektmanager

Der Objektmanager verwaltet die lokalen Daten.

## Lokale Daten

Die lokalen Daten bestehen aus den Drops und den Bildern.

#### Drops

#### ImageStorage

Der ImageStorage ist ein Dictionary, welches alle benötigten Bilder gespeichert und ihren jeweiligen Links zugeordnet hat.

## Verbindung

Die Verbindung wird über einen Connector aufgebaut, der die Drops aus einer externen Quelle lädt.

## Beteiligte

Projektmanager: [Tom Ille](https://github.com/JamesTheButler)

Konzeptor: Konstantin George

Gestaltung: Thomas Theling

Front-End: [Julian Fuchs](https://github.com/Julian93MI)

Back-End: [Sebastian Mischke](https://github.com/Saritus)

[loadscreen]: http://i.imgur.com/OUkLi.gif

[mainscreen2]: http://i.imgur.com/Ssfp7.gif

[historyview]: http://i.imgur.com/60bts.gif

[dropdetailsview]: https://i.redd.it/ol7ea42tl1dy.gif

[newdropview]: https://i.redd.it/2vjq5pxf209y.gif
