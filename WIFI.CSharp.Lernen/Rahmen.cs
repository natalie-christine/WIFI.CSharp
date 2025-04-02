using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.CSharp.Lernen
{
    /// <summary>
    /// Stellt Zeichen zum Erstellen
    /// von Rechtecken in der Konsole bereit
    /// </summary>
    internal static class Rahmen : System.Object
    {
        /// <summary>
        /// Ruft das Zeichen für links Oben ab
        /// </summary>
        public static char LinksOben
        {
            get
            {
                return '\u250C';
            }
        }

        /// <summary>
        /// Ruft das Zeichen für rechts Oben ab
        /// </summary>
        public static char RechtsOben
        {
            get
            {
                return '\u2510';
            }
        }

        /// <summary>
        /// Ruft das Zeichen für links Unten ab
        /// </summary>
        public static char LinksUnten
        {
            get
            {
                return '\u2514';
            }
        }

        /// <summary>
        /// Ruft das Zeichen für rechts Unten ab
        /// </summary>
        public static char RechtsUnten
        {
            get
            {
                return '\u2518';
            }
        }

        /// <summary>
        /// Ruft das Zeichen für eine waagrechte Linie ab
        /// </summary>
        public static char Horizontal
        {
            get
            {
                return '\u2500';
            }
        }

        /// <summary>
        /// Ruft das Zeichen für eine senkrechte Linie ab
        /// </summary>
        public static char Vertikal
        {
            get
            {
                return '\u2502';
            }
        }

    }
}
