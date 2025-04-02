using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using WIFI.Anwendung.Erweiterungen;

namespace WIFI.CSharp.Teil1.Models
{
    /// <summary>
    /// Stellt einen Dienst zum Verwalten
    /// der Anwendungskapitel bereit
    /// </summary>
    internal class ThemenManager
        : WIFI.Anwendung.AppObjekt
    {

        #region Datendienst

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private static string? _Konfigurationspfad = null;

        /// <summary>
        /// Ruft die vollständige lokalisierte
        /// Pfadangabe zu den Informationsdateien ab
        /// </summary>
        /// <remarks>Der eigentliche Dateiname
        /// muss zur gegeben Zeit angehängt werden.
        /// Sollte zur Laufzeit die Konfiguration
        /// geändert werden, muss die Anwendung
        /// neu gestartet werden</remarks>
        public string Konfigurationspfad
        {
            get
            {
                ThemenManager._Konfigurationspfad
                    ??= System.IO.Path.Combine(
                            this.Anwendungspfad,
                            Properties.Settings.Default
                            .InformationspfadRelativ).HoleLokalisierung();

                return ThemenManager._Konfigurationspfad;
            }
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private ThemenController? _Controller = null;

        /// <summary>
        /// Ruft den Dienst zum Lesen
        /// der Anwendungskapitel ab
        /// </summary>
        private ThemenController Controller
        {
            get
            {
                this._Controller ??= this.Kontext
                    .Produziere<ThemenController>();

                return this._Controller;
            }
        }

        #endregion Datendienst

        #region Anwendungskapitel

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private static Themen? _Liste = null;

        /// <summary>
        /// Ruft die Liste mit den
        /// konfigurierten Anwendungskapitel ab
        /// </summary>
        /// <remarks>Wird die Konfiguration geändert,
        /// die Anwendung neu starten. Als Name
        /// der Konfigurationsdatei wird "Themen.xml"
        /// im Konfigurationspfad erwartet.</remarks>
        public Themen Liste
        {
            get
            {
                if (ThemenManager._Liste == null)
                {
                    var Pfad = System.IO.Path
                        .Combine(
                            this.Konfigurationspfad,
                            "Themen.xml");

                    try
                    {
                        ThemenManager._Liste 
                            = this.Controller.Lesen(Pfad);
                    }
                    catch (System.Exception ex)
                    {
                        ThemenManager._Liste = new Themen();
                        this.OnFehlerAufgetreten(
                            new Anwendung.FehlerAufgetretenEventArgs(ex));
                    }
                }

                return ThemenManager._Liste!;
            }
        }

        #endregion Anwendungskapitel
    }
}
