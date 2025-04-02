using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.CSharp.Lernen
{
    /// <summary>
    /// Beschreibt das Lottospiel
    /// in einem Land und stellt
    /// einen Dienst zum Berechnen
    /// eines Quicktipps bereit
    /// </summary>
    internal class Lottoland : Entwicklungsbasis
    {
        /// <summary>
        /// Internes Feld zum Cachen
        /// der unterstützten Länder
        /// </summary>
        private static Lottoland[]? _UnterstützteLänder = null;

        /// <summary>
        /// Ruft die Liste mit den 
        /// möglichen Ländern ab
        /// </summary>
        /// <remarks>Diese können in der
        /// Konfigurationsdatei Lottoländer.txt
        /// im Programmverzeichnis gewartet werden</remarks>
        public static Lottoland[] UnterstützteLänder
        {
            get
            {
                if (Lottoland._UnterstützteLänder == null)
                {
                    Lottoland._UnterstützteLänder
                        = Lottoland.HoleUnterstützteLänder();
                }

                return Lottoland._UnterstützteLänder;
            }
        }

        /// <summary>
        /// Gibt die Länder aus der Konfigurationsdatei zurück
        /// </summary>
        /// <remarks>Die Konfigurationsdatei muss Lottoländer.txt
        /// heißen und im Programmverzeichnis liegen.
        /// Als Spaltentrennzeichen wird ein Tabulator angenommen,
        /// damit die Datei sowohl in englischen wie auch
        /// in anders sprachigen Systemen interpretiert werden kann.</remarks>
        protected static Lottoland[] HoleUnterstützteLänder()
        {
            Lottoland.Ausgeben(
                "HoleUntersützteLänder startet...",
                AusgabeModus.Debug);

            const string Datei = "LottoLänder.txt";
            var Dateipfad = System.IO.Path
                .Combine(Lottoland.Anwendungspfad, Datei);

            Lottoland.Ausgeben(
                $"Konfiguration: \"{Dateipfad}\"",
                AusgabeModus.Debug);

            var Konfiguration = new Textdatei { Pfad = Dateipfad };
            var Länderliste = new System.Collections.ArrayList();

            // Weil die erste Zeile die Spaltenbeschriftung ist,
            // nicht beim Index 0 sondern beim Index 1 beginnen
            for (int i = 1; i < Konfiguration?.Inhalt.Count; i++)
            {
                var Spalten = Konfiguration?.Inhalt[i]?
                    .ToString()?.Split('\t');

                //Für ein Land müssen drei Spalten vorhanden sind
                if (Spalten?.Length == 3)
                {
                    var NeuesLand = new Lottoland();

                    NeuesLand.Name = Spalten[0];
                    NeuesLand.AnzahlZahlen = int.Parse(Spalten[1]);
                    NeuesLand.HöchsteZahl = int.Parse(Spalten[2]);

                    Länderliste.Add(NeuesLand);
                }
            }

            Lottoland.Ausgeben(
                $"Es wurden {Länderliste.Count} Lottoländer gefunden...",
                AusgabeModus.Debug);

            Lottoland.Ausgeben(
                "HoleUntersützteLänder beendet.",
                AusgabeModus.Debug);

            //Im Teil 1 wird hier die generische Programmierung
            //bzw. die sprachintegretierte Abfrage LINQ benutzt
            //Hier in der Einführung soll mit einem
            //Standardarray gearbeitet werden
            var Ergebnis = new Lottoland[Länderliste.Count];
            for (int i = 0; i < Länderliste.Count; i++)
            {
                Ergebnis[i] = (Lottoland)Länderliste[i]!;
            }
            return Ergebnis;
        }

        /// <summary>
        /// Ruft den Namen des Lottolands ab
        /// oder legt diesen fest
        /// </summary>
        /// <remarks>Hier wird die implizite
        /// Eigenschaften Deklarstion benutzt,
        /// weil kein Zugriff auf das Feld
        /// notwendig ist. In Ausnahmefällen
        /// ist diese Lösung nutzbar</remarks>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Ruft die Anzahl der Zahlen eines
        /// Tipps in diesem Land ab oder legt diese fest
        /// </summary>
        public int AnzahlZahlen { get; set; } = 0;

        /// <summary>
        /// Ruft die größte Lottozahl in
        /// diesem Land ab oder legt diese fest
        /// </summary>
        public int HöchsteZahl { get; set; } = 0;

        /// <summary>
        /// Gibt für das Land die
        /// Zahlen eines Quicktipps zurück
        /// </summary>
        /// <remarks>Das ist das eigentliche
        /// Beispiel für die Durchlaufeschleife</remarks>
        public int[] BerechneTipp()
        {
            Lottoland.Ausgeben(
                "BerechneTipp startet...",
                AusgabeModus.Debug);

            // Das Ergebnis Array initialisieren
            // für die Anzahl in diesem Land
            var Ergebnis = new int[this.AnzahlZahlen];
            var AktuelleAnzahl = 0;
            var ObergrenzeExklusiv = this.HöchsteZahl + 1;

            // In einer Durchlaufeschleife
            do
            {
                // Neue Zahl zufällig ermitteln
                // zwischen 1 und der höchsten Zahl des Landes
                var NeueZahl = this.Zufallsgenerator
                    .Next(minValue: 1, maxValue: ObergrenzeExklusiv);

                // Ab der 2. Zahl prüfen,
                // ob diese schon vorhanden ist
                var Vorhanden = false;
                var i = 0;

                while (i < AktuelleAnzahl && !Vorhanden)
                {
                    if (Ergebnis[i] == NeueZahl)
                    {
                        Vorhanden = true;
                    }
                    else
                    {
                        i++;
                    }
                }

                // Die neue Zahl nur merken,
                // wenn sie noch nicht vorhanden ist
                if (!Vorhanden)
                {
                    Ergebnis[AktuelleAnzahl] = NeueZahl;
                    AktuelleAnzahl++;
                }
                // bis die Anzahl erreicht ist
            } while (AktuelleAnzahl < this.AnzahlZahlen);

            // Noch rasch sortieren
            System.Array.Sort(Ergebnis);

            Lottoland.Ausgeben(
                "BerechneTipp beendet.",
                AusgabeModus.Debug);

            // Ergebnis zurückgeben
            return Ergebnis;
        }
    }
}
