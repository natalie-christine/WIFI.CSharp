using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Daten
{
    /// <summary>
    /// Stellt eine dynamische Auflistung
    /// von Sprache Objekten bereit
    /// </summary>
    public class Sprachen 
        : System.Collections.Generic.List<Sprache>
    {

    }

    /// <summary>
    /// Stellt Information über
    /// eine Anwendungssprache bereit
    /// </summary>
    public class Sprache : System.Object
    {
        /// <summary>
        /// Ruft das .Net CulturInfo Kürzel
        /// dieser Sprache ab oder legt dieses fest
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Ruft die lesbare Bezeichnung
        /// dieser Sprache ab oder legt diese fest
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gibt einen Text zurück,
        /// der diese Sprache beschreibt
        /// </summary>
        public override string ToString()
        {
            return 
                $"{this.GetType().Name}(Code=\"{this.Code}\", " +
                $"Name=\"{this.Name}\")";
        }
    }
}
