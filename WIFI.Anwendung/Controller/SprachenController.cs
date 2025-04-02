using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Controller
{
    /// <summary>
    /// Stellt einen Xml Dienst zum Lesen bzw.
    /// Schreiben von Anwendungssprachen
    /// aus oder in eine Datei bereit.
    /// </summary>
    internal class SprachenController 
        : Generisch.XmlController<Daten.Sprachen>
    {
        /// <summary>
        /// Gibt die unterstützten Sprachen
        /// aus den Anwendungsressourcen zurück
        /// </summary>
        /// <remarks>Es wird davon ausgegangen,
        /// dass der Inhalt im Xml Format als 
        /// UTF-8 mit Signatur und dem Ressourcen 
        /// Schlüssel Sprachen gefunden wird.</remarks>
        public Daten.Sprachen HoleAusRessourcen()
        {
            //Für das Ergebnis
            var Sprachen = new Daten.Sprachen();

            //Den Xml-Text aus den Ressourcen
            //ab dem 2. Byte, weil das 1. Byte die Signatur ist
            string XmlDaten = System.Text.Encoding.UTF8
                .GetString(Properties.Resources.Sprachen)
                //wegen der Signatur
                .Substring(1);

            //Ein XmlDocument Objekt
            var XmlDokument = new System.Xml.XmlDocument();

            //Den Xml-Text aus den Ressourcen laden
            XmlDokument.LoadXml(XmlDaten);

            //Alle Elemente des Wurzel-Elements
            //abarbeiten und die Attribute in
            //die Eigenschaften des Sprache Objekts mappen
            foreach (
                System.Xml.XmlElement Element
                in XmlDokument.DocumentElement!.ChildNodes)
            {
                Sprachen.Add(
                    new Daten.Sprache
                    {
                        Code = Element.GetAttribute("code"),
                        Name = Element.GetAttribute("name")
                    });
            }
            //Die Liste der gefunden Sprachen zurückgeben
            return Sprachen;
        }
    }
}
