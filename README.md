Wanneer je deze versie voor de eerste keer opent na downloaden:

* Controleer de Package Manager Console, je krijgt de melding "Some NuGet packages are missing...". Klik op de "Restore" knop die aan de rechterzijde van de console verschijnt.
    * Zie je geen package manager console --> bovenaan Tools > NuGet Package Manager > Package Manager Console
    * Als je deze melding niet kreeg:
        * Manage nuget packages bij Dal
        * Verwijder hier ook het EntityFramework package als het nog geïnstalleerd staat
        * Installeer dit package opnieuw
        * Eventueel om zeker te zijn Visual Studio nog eens afsluiten en opnieuw opstarten
        * Ten slotte nog eens de drie commando's uitvoeren
* In het Dal project: open de map Migrations en verwijder daarin alle bestanden BEHALVE Configuration.cs
