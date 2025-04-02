using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.CSharp.Teil1.Models
{
    /// <summary>
    /// Stellt eine Liste von
    /// Anwendungskapitel bereit
    /// </summary>
    public class Themen : System.Collections.Generic.List<Thema>
    {

    }

    /// <summary>
    /// Stellt Information über
    /// ein Anwendungskapitel bereit
    /// </summary>
    public class Thema : System.Object
    {
        /// <summary>
        /// Ruft die lesbare Bezeichnung
        /// des Kapitels ab oder legt diese fest
        /// </summary>
        [System.Xml.Serialization.XmlAttribute()]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Ruft nur den Namen der unformatierten
        /// Textdatei mit der Information dieses
        /// Kapitels ab oder legt diesen fest
        /// </summary>
        [System.Xml.Serialization.XmlAttribute()]
        public string Datei { get; set; } = string.Empty;

        /// <summary>
        /// Gibt einen Text zurück,
        /// der dieses Thema beschreibt
        /// </summary>
        public override string ToString()
        {
            return $"{this.GetType().Name}(Datei=\"{this.Datei}\")";
        }
    }
}
