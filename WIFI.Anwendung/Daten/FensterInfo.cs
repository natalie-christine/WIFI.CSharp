using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Daten
{
    /// <summary>
    /// Stellt eine dynamische Auflistung
    /// von FensterInfo Objekten bereit
    /// </summary>
    public class FensterInfos 
        : System.Collections.Generic.List<FensterInfo>
    {

    }

    /// <summary>
    /// Stellt die Daten für die Position,
    /// Größe und den Zustand eines 
    /// Anwendungsfensters bereit
    /// </summary>
    public class FensterInfo : System.Object
    {
        /// <summary>
        /// Ruft die interne Bezeichnung
        /// des Fenster ab oder legt diese fest
        /// </summary>
        /// <remarks>Der Name wird als Schlüssel
        /// zum Wiederfinden benutzt</remarks>
        public string Name { get; set; } = string.Empty;
        // Das ist ein Verweistyp, wo wir kein null wollen

        /// <summary>
        /// Ruft die Fensterdarstellung
        /// minimiert, maximiert bzw. normal ab
        /// oder legt diese fest
        /// </summary>
        public int Zustand { get; set; }
        // Das ist ein Wertetyp mit
        // Standard 0 (Null), weil ein
        // Fenster immer einen Zustand hat

        // Die nächsten Eigenschaften
        // enthalten nur brauchbare Werte,
        // wenn das Fenster im Normal-Zustand ist.
        // Deshalb nullable Wertetypen

        /// <summary>
        /// Ruft den Abstand zur linken
        /// Bildschirmkante ab oder legt diesen fest
        /// </summary>
        /// <remarks>Nur zulässig, wenn der
        /// Zustand Normal ist</remarks>
        public double? Links { get; set; } = null;

        /// <summary>
        /// Ruft den Abstand zur oberen
        /// Bildschirmkante ab oder legt diesen fest
        /// </summary>
        /// <remarks>Nur zulässig, wenn der
        /// Zustand Normal ist</remarks>
        public double? Oben { get; set; } = null;

        /// <summary>
        /// Ruft die Fensterbreite ab oder legt diese fest
        /// </summary>
        /// <remarks>Nur zulässig, wenn der
        /// Zustand Normal ist</remarks>
        public double? Breite { get; set; } = null;

        /// <summary>
        /// Ruft die Fensterhöhe ab oder legt diese fest
        /// </summary>
        /// <remarks>Nur zulässig, wenn der
        /// Zustand Normal ist</remarks>
        public double? Höhe { get; set; } = null;

        /// <summary>
        /// Gibt einen Text zurück,
        /// der diese FensterInfo beschreibt
        /// </summary>
        public override string ToString()
        {
            return
                $"{this.GetType().Name}(Name=\"{this.Name}\")";
        }
    }
}
