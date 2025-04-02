using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.CSharp.Lernen
{
    /// <summary>
    /// Stellt einen Dienst zum Arbeiten mit
    /// unformatieren Textdateien bereit
    /// </summary>
    internal class Textdatei : Entwicklungsbasis
    {

        // Klassenebene für Felder,
        // die IMMER PRIVAT sein müssen!

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private string _Pfad = string.Empty;

        /// <summary>
        /// Ruft den vollständigen Dateinamen
        /// ab oder legt diesen fest
        /// </summary>
        /// <remarks>Sollte ein alter Inhalt
        /// vorhanden sein, wird dieser bei einer
        /// Pfadänderung entfernt.</remarks>
        public string Pfad
        {
            get
            {
                // wie eine Funktionsmethode
                return this._Pfad;
            }
            set
            {

                // wie eine void Methode mit Parametername "value"
                if (this._Pfad != value && this._Inhalt != null)
                {
                    this._Inhalt = null;
                    Textdatei.Ausgeben(
                        "Ein alter Inhalt wurde entfernt...",
                        AusgabeModus.Debug);
                }

                // Die Einstellung von diesem Parameter value
                // müssen wir uns im Objektfeld merken
                this._Pfad = value;
                Textdatei.Ausgeben(
                    $"Textdatei.Pfad=\"{this._Pfad}\"",
                    AusgabeModus.Debug);

            }
        }

        /// <summary>
        /// Gibt den Inhalt der Datei beschrieben im
        /// Pfad als Fließtext mit einer eingestellten
        /// Zeilenlänge zurück.
        /// </summary>
        /// <param name="maxZeilenlänge">Eine Ganzzahl für
        /// die maximale Anzahl an Zeichen einer Zeile im Ergebnis</param>
        public string HoleFließtext(int maxZeilenlänge)
        {
            Textdatei.Ausgeben(
                "Textdatei.HoleFließtext startet...",
                AusgabeModus.Debug);

            var Text = new System.Text.StringBuilder();
            int AktuelleZeilenlänge = 0;

            foreach (string Wort in this.Inhalt)
            {
                if (Wort.Length > 0)
                {
                    if (AktuelleZeilenlänge + Wort.Length > maxZeilenlänge)
                    {
                        Text.AppendLine();
                        AktuelleZeilenlänge = 0;
                    }

                    Text.Append(Wort + " ");
                    AktuelleZeilenlänge += Wort.Length + 1;
                }
                else
                {
                    //Leere Wörter als Absatz interpretieren
                    //Die aktuelle Zeile abschließen ...
                    Text.AppendLine();
                    AktuelleZeilenlänge = 0;
                    //Eine leere Zeile machen ...
                    Text.AppendLine();
                }
            }

            Textdatei.Ausgeben(
                "Textdatei.HoleFließtext beendet.",
                AusgabeModus.Debug);

            return Text.ToString();
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private System.Collections.ArrayList? _Inhalt = null;

        /// <summary>
        /// Ruft die in der Datei enthaltenen 
        /// Zeilen als Datenfeld (Array) ab
        /// </summary>
        public System.Collections.ArrayList Inhalt
        {
            get
            {
                if (this._Inhalt == null)
                {
                    this._Inhalt = this.Lesen();
                    Textdatei.Ausgeben(
                        $"{this.GetType().Name} hat die dynamische Liste " +
                        $"für den Inhalt initialisiert...",
                        AusgabeModus.Debug);
                }

                return this._Inhalt;
            }
        }

        /// <summary>
        /// Liest den Inhalt der Datei im Pfad
        /// Zeile für Zeile und gibt eine Liste zurück
        /// </summary>
        /// <remarks>Sollte ein Problem auftreten,
        /// wird eine leere Liste zurückgeben</remarks>
        private System.Collections.ArrayList Lesen()
        {
            Textdatei.Ausgeben(
                "Textdatei.Lesen startet...",
                AusgabeModus.Debug);

            var Zeilen = new System.Collections.ArrayList();

            try
            {
                using var Datei
                    = new System.IO.StreamReader(
                                        this.Pfad,
                                        System.Text.Encoding.Latin1);

                Textdatei.Ausgeben(
                    "Lesen hat die Datei geöffnet...",
                    AusgabeModus.Debug);

                while (!Datei.EndOfStream)
                {
                    Zeilen.Add(Datei.ReadLine());
                }

                Textdatei.Ausgeben(
                    $"Lesen hat {Zeilen.Count} Zeilen gelesen...",
                    AusgabeModus.Debug);

                Datei.Close();

                Textdatei.Ausgeben(
                    "Lesen hat die Datei geschlossen.",
                    AusgabeModus.Debug);
            }
            catch (System.Exception ex)
            {
                Textdatei.Ausgeben(ex.Message, AusgabeModus.Fehler);
                this.OnLeseFehlerAufgetreten(EventArgs.Empty);
            }

            Textdatei.Ausgeben(
                "Textdatei.Lesen beendet.",
                AusgabeModus.Debug);
            return Zeilen;
        }

        /// <summary>
        /// Wird ausgelöst, wenn beim Lesen
        /// des Pfads ein Problem auftritt
        /// </summary>
        public event System.EventHandler? LeseFehlerAufgetreten;

        /// <summary>
        /// Löst das Ereignis LeseFehlerAufgetreten aus
        /// </summary>
        /// <param name="e">Ereignisdaten, hier leer</param>
        protected void OnLeseFehlerAufgetreten(EventArgs e)
        {
            if (this.LeseFehlerAufgetreten != null)
            {
                this.LeseFehlerAufgetreten(this, e);
            }
        }
    }
}
