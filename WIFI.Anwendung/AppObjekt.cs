using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Zum Auslesen der Assembly Informationen
using WIFI.Anwendung.Erweiterungen;

namespace WIFI.Anwendung
{
    /// <summary>
    /// Unterstützt sämtliche WIFI Anwendungsobjekte
    /// mit Basisdiensten, z. B. dem Anwendungskontext
    /// </summary>
    public abstract class AppObjekt : System.Object
    {

        #region Infrastruktur bereitstellen

        /// <summary>
        /// Ruft die WIFI Anwendungsinfrastrukur
        /// ab oder legt diese fest.
        /// </summary>
        /// <remarks>Diese Eigenschaft muss eingestellt werden.
        /// Standardwert null</remarks>
        public Infrastruktur Kontext { get; set; } = null!;

        #endregion Infrastruktur bereitstellen

        #region FehlerAufgetreten Ereignisdeklaration

        /// <summary>
        /// Wird ausgelöst, wenn eine Ausnahme aufgetreten ist
        /// </summary>
        /// <remarks>Ereignisdeklaration. Das Schlüsselwort event 
        /// ist nur dazu, dass der Objektkatalog 
        /// ein Blitz-Symbol benutzt</remarks>
        public event FehlerAufgetretenEventHandler? FehlerAufgetreten;

        /// <summary>
        /// Löst das Ereignis FehlerAufgetreten aus
        /// </summary>
        /// <param name="e">Zusatzdaten mit der Ursache</param>
        /// <remarks>Hier handelt es sich um eine
        /// so genannte Ereignis-Auslöser Methode, die
        /// zum Überschreiben gekennzeichnet sind</remarks>
        protected virtual void OnFehlerAufgetreten(
            FehlerAufgetretenEventArgs e)
        {
            // Damit die Garbage Collection
            // nicht irrtümlich das Objekt entfernt,
            // mit einer Kopie der Methodenadresse arbeiten
            // (beim Multithreading - Teil 2)
            var BehandlerKopie = this.FehlerAufgetreten;

            // Alt - vor .Net 6
            /*
            if (BehandlerKopie != null)
            {
                BehandlerKopie(this, e);
            }
            */

            // Neu - Nullable Verweistypen
            BehandlerKopie?.Invoke(this, e);

        }

        #endregion FehlerAufgetreten Ereignisdeklaration

        #region Pfad-Informationen

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private static string? _Anwendungspfad = null;

        /// <summary>
        /// Ruft das vollständig Verzeichnis ab,
        /// aus dem die Anwendung gestartet wurde.
        /// </summary>
        public string Anwendungspfad
        {
            get
            {
                if (AppObjekt._Anwendungspfad == null)
                {
                    AppObjekt._Anwendungspfad = System.IO.Path
                        .GetDirectoryName(
                                System.Reflection.Assembly.GetEntryAssembly()!
                                        .Location)!;
                }

                return AppObjekt._Anwendungspfad;
            }
        }


        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private static string _Datenpfad = null!;

        /// <summary>
        /// Ruft das Verzeichnis im Benutzerprofil ab,
        /// wo die Anwendung ungefragt Server gespeicherte
        /// Daten speichern darf
        /// </summary>
        /// <remarks>Es ist sichergestellt,
        /// dass das Verzeichnis existiert</remarks>
        public string Datenpfad
        {
            get
            {
                if (AppObjekt._Datenpfad == null)
                {
                    AppObjekt._Datenpfad
                        = System.IO.Path.Combine(
                            System.Environment.GetFolderPath(
                                Environment.SpecialFolder
                                    .ApplicationData),
                            // An diesen Standardpfad
                            // den Firmennamen anhängen
                            this.HoleFirma(),
                            // Den Produktnamen anhängen
                            this.HoleProdukt(),
                            // Die Version anhängen
                            this.HoleVersion()
                    );
                }

                // Bei jedem Zugriff sicherstellen,
                // dass das Verzeichnis existiert
                System.IO.Directory
                    .CreateDirectory(AppObjekt._Datenpfad);

                return AppObjekt._Datenpfad;
            }
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private static string _LokalerDatenpfad = null!;

        /// <summary>
        /// Ruft das Verzeichnis im Benutzerprofil ab,
        /// wo die Anwendung ungefragt computerbezogene 
        /// Daten speichern darf
        /// </summary>
        /// <remarks>Es ist sichergestellt,
        /// dass das Verzeichnis existiert</remarks>
        public string LokalerDatenpfad
        {
            get
            {
                if (AppObjekt._LokalerDatenpfad == null)
                {
                    AppObjekt._LokalerDatenpfad
                        = System.IO.Path.Combine(
                            System.Environment.GetFolderPath(
                                Environment.SpecialFolder
                                    .LocalApplicationData),
                            // An diesen Standardpfad
                            // den Firmennamen anhängen
                            this.HoleFirma(),
                            // Den Produktnamen anhängen
                            this.HoleProdukt(),
                            // Die Version anhängen
                            this.HoleVersion()
                    );
                }

                // Bei jedem Zugriff sicherstellen,
                // dass das Verzeichnis existiert
                System.IO.Directory
                    .CreateDirectory(AppObjekt._LokalerDatenpfad);

                return AppObjekt._LokalerDatenpfad;
            }
        }

        #endregion Pfad-Informationen

    }
}
