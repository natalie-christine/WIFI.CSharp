using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.CSharp.Lernen
{
    /// <summary>
    /// Steuert die Anwendung zum Lernen
    /// der objektorientierten Programmierung
    /// mit C# und .Net
    /// </summary>
    /// <remarks>Hier handelt es sich um
    /// Xml-Dokumentationskommentar angezeigt
    /// im Objektkatalog</remarks>
    internal class Anwendung : Entwicklungsbasis
    {
        /// <summary>
        /// Stellt den Haupteinstiegspunkt
        /// in eine .Net Anwendung bereit
        /// </summary>
        /// <remarks>Dieser muss Main heißen
        /// und zur Klasse gehören, d.h. statisch sein.
        /// Viele neuen Projektvorlagen in
        /// Visual Studio verstecken dieses Main</remarks>
        static void Main()
        {
            Anwendung.Ausgeben(
                "Die Anwendung startet...", 
                AusgabeModus.Debug);

            Anwendung.ZeigeTitel();
            Algorithmus.Arbeite();

            Anwendung.Ausgeben(
                "Die Anwendung ist beendet.",
                AusgabeModus.Debug);

        }

        /// <summary>
        /// Schreibt in einem Rahmen den
        /// Anwendungstitel in die Konsole
        /// </summary>
        // 20241105 - der Titel wird jetzt zentriert
        private static void ZeigeTitel()
        {
            Anwendung.Ausgeben(
                "Anwendung.ZeigeTitel startet...", 
                AusgabeModus.Debug);

            const string Muster = "{0}{1}{2}{3}{4}{3}{5}{1}{6}\r\n";
            int Innenbreite = System.Console.WindowWidth - 2;

            //20241105 zum Zentrieren
            int X = (Innenbreite - Texte.Titel.Length) / 2;

            Anwendung.Ausgeben(
                string.Format(
                    Muster, 
                    Rahmen.LinksOben,                   //0
                    //Vorsicht bei solchen nächsten Aufrufen!
                    //das funktioniert, weil die Garbage Collection
                    //später die horizontale Linie wieder entfernt
                    new string(
                        Rahmen.Horizontal,
                        Innenbreite),                   //1
                    Rahmen.RechtsOben,                  //2
                    Rahmen.Vertikal,                    //3
                    //20241105 - Titel zentrieren
                    //Texte.Titel.PadRight(Innenbreite),//4
                    Texte.Titel
                        .PadLeft(X + Texte.Titel.Length)
                        .PadRight(Innenbreite),         //4
                    Rahmen.LinksUnten,                  //5
                    Rahmen.RechtsUnten                  //6
                    )
                );

            Anwendung.Ausgeben(
                "Anwendung.ZeigeTitel beendet.",
                AusgabeModus.Debug);

        }
    }
}
