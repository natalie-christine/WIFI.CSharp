using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Generisch
{
    /// <summary>
    /// Stellt einen Dienst zum Lesen bzw.
    /// Schreiben von Objekten
    /// aus oder in eine Xml Datei bereit.
    /// </summary>
    /// <remarks>Es wird die 
    /// .Net Xml Serialisierung benutzt</remarks>
    public class XmlController<T> : AppObjekt
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
        public void Speichern(string pfad, T daten)
        {
            var XmlSerialisierer = new System.Xml.Serialization
                .XmlSerializer(daten!.GetType());

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
        /// wenn das Deserialisieren der Daten nicht möglich war</exception>
        public T? Lesen(string pfad)
        {
            var XmlSerialisierer = new System.Xml.Serialization
                .XmlSerializer(typeof(T));

            using var Leser = new System.IO.StreamReader(pfad);

            return (T)XmlSerialisierer.Deserialize(Leser)!;
        }
    }
}
