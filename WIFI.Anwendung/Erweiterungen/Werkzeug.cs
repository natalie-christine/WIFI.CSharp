using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Erweiterungen
{
    /// <summary>
    /// Stellt diverse Hilfsmethoden
    /// für die Entwicklung bereit
    /// </summary>
    /// <remarks>Zum Aktivieren dieser Erweiterungen
    /// in der Klasse, wo diese eingesetzt werden,
    /// die using-Direktive auf den Namespace
    /// WIFI.Anwendung.Erweiterungen benutzen</remarks>
    public static class Werkzeug : System.Object
    {
        /// <summary>
        /// Prüft, ob im Pfad ein Unterordner
        /// für die aktuelle Oberflächensprache
        /// vorhanden ist, hängt diesen an und
        /// gibt das Ergebnis zurück
        /// </summary>
        /// <param name="pfad">Verzeichnisangabe,
        /// wo geprüft werden soll, ob ein Unterordner
        /// für die aktuelle Oberflächensprache vorhanden ist</param>
        /// <remarks>Damit kann die Existenz eines Ordners
        /// nicht geprüft werden. Sollte kein Unterordner
        /// für die Sprache gefunden wird, wird
        /// der Pfad unverändert zurückgegeben</remarks>
        public static string HoleLokalisierung(this string pfad)
        {
            // Kürzel der aktuellen Oberflächesprache feststellen
            var Kultur = System.Globalization.CultureInfo
                .CurrentUICulture.Name;

            var Ergebnis = System.IO.Path.Combine(pfad, Kultur);

            // Solange nicht alles geprüft ist
            // Prüfen, ob im Pfad dieser Ordner existiert
            while (!System.IO.Directory.Exists(Ergebnis) && Kultur.Length > 0)
            {
                // Falls nein, die Subkultur entfernen
                var PosLetzterBindestrich = Kultur.LastIndexOf('-');

                if (PosLetzterBindestrich > -1)
                {
                    Kultur = Kultur.Substring(0, PosLetzterBindestrich);
                }
                else
                {
                    // Ist kein Bindestrich mehr vorhanden,
                    // wurde alles geprüft
                    Kultur = string.Empty;
                }

                // und wieder prüfen
                Ergebnis = System.IO.Path
                    .Combine(pfad, Kultur);
            }

            // Ergebnis zurückgeben
            return Ergebnis;
        }
    }
}
