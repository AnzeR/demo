## Demo MVC aplikacija

Datoteka **create tables.sql** vsebuje skripte za kreiranje table, datoteka **import.sql** pa import željenega števila testnih primerov.

Za MSSQL sem uporabil kar Docker image - navodila https://hub.docker.com/_/microsoft-mssql-server

Aplikacija je zelo okrnjena zaradi pomanjkanja časa in malo pozabljenih osnovnih gradnikov. Vsekakor bi bilo bolje uporabiti **ORM** (NPoco to podpira) namesto SQL skript in **MVC** namesto Razor Page (kot kaže sem izbral napačen "template" in potem sem pač nadaljeval od tam.

Tudi kakšno Grid kontrolo bi lahko našel in uporabil, ampak mislim, da vsak zna poklikati wizard, zato predvidevam da to ni fokus.
