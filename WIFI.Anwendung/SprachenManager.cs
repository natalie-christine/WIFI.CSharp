using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung
{
    /// <summary>
    /// Stellt einen Dienst zum Verwalten
    /// der Oberflächensprachen bereit
    /// </summary>
    public class SprachenManager : AppObjekt
    {
        #region Unterstützte Sprachen

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private Daten.Sprachen? _Liste = null;

        /// <summary>
        /// Ruft die unterstützten Sprachen ab
        /// </summary>
        /// <remarks>Die Liste wird mit der
        /// Xml Sprachendatei aus den 
        /// Anwendungsressourcen initialisiert.
        /// Ab 20241217 werden die Sprachen
        /// entsprechend des Namens sortiert</remarks>
        public Daten.Sprachen Liste
        {
            get
            {
                if (this._Liste == null)
                {
                    //20241217 Die Liste nach Namen sortieren
                    //this._Liste = this.Controller.HoleAusRessourcen();
                    this._Liste = new Daten.Sprachen();
                    this._Liste.AddRange(
                        from s in this.Controller.HoleAusRessourcen()
                        orderby s.Name
                        select s);
                }

                return this._Liste;
            }
        }

        #endregion Unterstützte Sprachen

        #region Controller

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private Controller.SprachenController? _Controller = null;

        /// <summary>
        /// Ruft den Dienst zum Schreiben
        /// und Lesen von Anwendungssprachen ab
        /// </summary>
        private Controller.SprachenController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = this.Kontext
                        .Produziere<WIFI.Anwendung.Controller.SprachenController>();
                }

                return this._Controller;
            }
        }

        #endregion Controller

        #region Aktuelle Sprache

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private Daten.Sprache? _AktuelleSprache = null;

        /// <summary>
        /// Ruft die Sprache ab, die derzeit
        /// für die Anwendung benutzt wird,
        /// oder legt diese fest
        /// </summary>
        /// <remarks>Standardinitialisierung
        /// wird aus dem Betriebssystem bezogen.
        /// Sollte keine Lokalisierung vorhanden 
        /// sein, Englisch</remarks>
        public Daten.Sprache AktuelleSprache
        {
            get
            {
                if (this._AktuelleSprache == null)
                {
                    this.Festlegen(System.Globalization.CultureInfo
                        .CurrentUICulture.TwoLetterISOLanguageName);
                }

                return this._AktuelleSprache;
            }
            set => this._AktuelleSprache = value;
        }

        /// <summary>
        /// Stellt die aktuelle Anwendungssprache ein
        /// </summary>
        /// <param name="cultureInfoKürzel">Der Name
        /// der benötigten Sprache entsprechend von
        /// System.Globalization.CulturInfo.Name</param>
        /// <remarks>Sollte das Kürzel nicht vorhanden sein,
        /// wird Englisch benutzt</remarks>
        public void Festlegen(string cultureInfoKürzel)
        {
            //Gibt es die gewünschte Sprache
            //in den unterstützten Sprachen?
            var GewünschteSprache
                = this.Liste.Find(
                    s => s.Code.Equals(
                        cultureInfoKürzel,
                        StringComparison.InvariantCultureIgnoreCase)
                    );
            //Falls die Sprache 
            //nicht vorhanden ist, Englisch
            GewünschteSprache ??= this.Liste
                .Find(s => s.Code.Equals(
                                "en",
                                StringComparison.InvariantCultureIgnoreCase)
                );

            //Falls die gewünschte Sprache
            //sich vom Betriebssystem unterscheidet,
            //diese Sprache einstellen
            if (!GewünschteSprache!.Code
                    .Equals(System.Globalization.CultureInfo
                        .CurrentUICulture.TwoLetterISOLanguageName,
                        StringComparison.InvariantCultureIgnoreCase)
                )
            {
                System.Globalization.CultureInfo
                    .CurrentUICulture = new System.Globalization
                        .CultureInfo(GewünschteSprache.Code);
                //Sollte sich die Sprache geändert haben,
                //die Liste mit den unterstützten Sprachen
                //neulesen, damit diese auch in der
                //neuen Sprache sind. Dazu den Cache leeren,
                //d.h. das Feld auf null
                this._Liste = null!;
            }

            // Damit mit gleichen Speicheradressen gearbeitet wird,
            // die aktuelle Sprache auf das Objekt einstellen,
            // das in der aktuellen Liste der Sprache entspricht
            this.AktuelleSprache
                = this.Liste.Find(
                    s => s.Code.Equals(
                            GewünschteSprache.Code,
                            StringComparison.InvariantCultureIgnoreCase))!;
        }

        #endregion Aktuelle Sprache
    }
}
