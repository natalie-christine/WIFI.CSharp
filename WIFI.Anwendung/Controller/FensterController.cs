using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Controller
{
    /// <summary>
    /// Stellt einen Xml Dienst zum Lesen bzw.
    /// Schreiben von FensterInfo Objekten
    /// aus oder in eine Datei bereit.
    /// </summary>
    internal class FensterController 
        : Generisch.XmlController<Daten.FensterInfos>
    {

    }

    // Das war die Lösung vor
    // dem Benutzen des generischen Controllers
    /*
    internal class FensterController : AppObjekt
    {
        /// <summary>
        /// Serialisiert die Daten im Xml Format
        /// in die gewünschte Datei
        /// </summary>
        /// <param name="pfad">Vollständige Pfadangabe
        /// der zu benutzenden Datei</param>
        /// <param name="daten">Die Liste mit den
        /// Informationen, die serialisiert werden soll</param>
        /// <exception cref="System.Exception">Tritt auf,
        /// wenn die Serialisierung nicht durchgeführt werden konnte</exception>
        /// <remarks>Controller sind schlank, d.h. keine
        /// Fehlerbehandlungen, ... Das ist Aufgabe der Manager</remarks>
        public void Speichern(string pfad, Daten.FensterInfos daten)
        {
            var XmlSerialisierer = new System.Xml.Serialization
                .XmlSerializer(daten.GetType());

            //XmlSerialisierer.dis... kein Dispose()
            //Aber der StreamWriter. Dispose() auf keinen Fall vergessen!
            using var Schreiber = new System.IO.StreamWriter(pfad);

            XmlSerialisierer.Serialize(Schreiber, daten);
        }

        /// <summary>
        /// Gibt den deserialisierten Inhalt aus der Datei zurück
        /// </summary>
        /// <param name="pfad">Vollständige Pfadangabe
        /// zur Xml Datei mit den benötigten Daten</param>
        /// <exception cref="System.Exception">Tritt auf,
        /// wenn das Desiralisieren der Daten nicht möglich war</exception>
        public Daten.FensterInfos? Lesen(string pfad)
        {
            var XmlSerialisierer = new System.Xml.Serialization
                .XmlSerializer(typeof(Daten.FensterInfos));

            using var Leser = new System.IO.StreamReader(pfad);

            return XmlSerialisierer.Deserialize(Leser)
                as Daten.FensterInfos;
        }
    }
    */
}
