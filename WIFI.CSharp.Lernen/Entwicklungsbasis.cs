using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.CSharp.Lernen
{
    /// <summary>
    /// Steuert, wie die Ausgeben Methode
    /// den Text schreiben soll
    /// </summary>
    internal enum AusgabeModus
    {
        /// <summary>
        /// Information für die Benutzer
        /// </summary>
        Normal,
        /// <summary>
        /// Information für die Benutzer
        /// ohne Zeilenvorschub
        /// </summary>
        NormalBleibeInZeile,
        /// <summary>
        /// Information für das Protokoll
        /// </summary>
        Debug,
        /// <summary>
        /// Information in einer anderen
        /// Farbe zum Hinweisen auf ein Problem
        /// </summary>
        Fehler
    }

    /// <summary>
    /// Unterstützt sämtliche WIFI Klassen
    /// mit einer Basislogik
    /// </summary>
    /// <remarks>Diese Klasse kann
    /// nur als Basisklasse für andere
    /// benutzt werden (abstract)</remarks>
    internal abstract class Entwicklungsbasis : System.Object
    {
        /// <summary>
        /// Gibt die Information für
        /// Benutzer in der Konsole aus
        /// </summary>
        /// <param name="text">Die Information,
        /// die Benutzer lesen sollen</param>
        protected static void Ausgeben(string text)
        {
            Entwicklungsbasis.Ausgeben(text, AusgabeModus.Normal);
        }

        /// <summary>
        /// Gibt eine Information in
        /// der Konsole aus
        /// </summary>
        /// <param name="text">Die Information,
        /// die in die Konsole geschrieben werden soll</param>
        /// <param name="modus">Steuert, wie
        /// der Text in der Konsole 
        /// angezeigt werden soll</param>
        /// <remarks>Hier handelt es sich
        /// um eine überladene Methode</remarks>
        protected static void Ausgeben(
            string text,
            AusgabeModus modus)
        {
            switch (modus)
            {
                case AusgabeModus.Debug:
#if DEBUG
                    System.Console.ForegroundColor
                        = ConsoleColor.White;
                    System.Console.WriteLine(text);
                    System.Console.ResetColor();
#endif
                    break;

                case AusgabeModus.Normal:
                    System.Console.WriteLine(text);
                    break;

                case AusgabeModus.NormalBleibeInZeile:
                    System.Console.Write(text);
                    break;

                case AusgabeModus.Fehler:
                    System.Console.ForegroundColor
                        = ConsoleColor.Yellow;
                    System.Console.WriteLine(text);
                    System.Console.ResetColor();
                    break;
            }
        }

        /// <summary>
        /// Initialisiert ein Objekt
        /// </summary>
        /// <remarks>Hier handelt es sich
        /// um den Konstruktor aufgerufen
        /// mit dem new Schlüsselwort
        /// zum Präsentieren der .Net Reflection 
        /// über den Einstieg mit GetType()</remarks>
        public Entwicklungsbasis()
        {
            /*
            Entwicklungsbasis.Ausgeben(
                string.Format(
                    "Ein Objekt {0} lebt...",
                    this), 
                AusgabeModus.Debug);
            */
            Entwicklungsbasis.Ausgeben(
                $"Ein Objekt \"{this.GetType().Name}\" lebt...",
                 AusgabeModus.Debug);
        }

        /// <summary>
        /// Ruft den anwendungsweiten Dienst zum
        /// Berechnen von (Pseudo-)Zufallszahlen ab
        /// </summary>
        /// <remarks>Diese Implementierung ist
        /// erst seit .Net 6 gültig - früher
        /// musste man ein Objekt initialisieren</remarks>
        protected System.Random Zufallsgenerator
        {
            get
            {
                return System.Random.Shared;
            }
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private static string? _Anwendungspfad = null;

        /// <summary>
        /// Ruft das vollständig Verzeichnis ab,
        /// aus dem die Anwendung gestartet wurde.
        /// </summary>
        protected static string Anwendungspfad
        {
            get
            {
                if (Entwicklungsbasis._Anwendungspfad == null)
                {
                    Entwicklungsbasis._Anwendungspfad = System.IO.Path
                        .GetDirectoryName(
                                System.Reflection.Assembly.GetEntryAssembly()!
                                        .Location)!;
                    Entwicklungsbasis.Ausgeben(
                        $"Die Anwendung hat den Anwendungspfad ermittelt...", 
                        AusgabeModus.Debug);
                }

                return Entwicklungsbasis._Anwendungspfad;
            }
        }
    }
}
