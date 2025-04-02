using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Interop;

namespace WIFI.CSharp.Teil1
{
    /// <summary>
    /// Kontrolliert das Hoch- und
    /// Herunterfahren der MVVM WPF WIFI Teil 1 Anwendung
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private WIFI.Anwendung.Infrastruktur _Kontext = null!;

        /// <summary>
        /// Ruft die WIFI Infrastruktur
        /// der Anwendung ab
        /// </summary>
        public WIFI.Anwendung.Infrastruktur Kontext
        {
            get
            {
                //if (this._Kontext == null)
                //{
                this._Kontext ??= new WIFI.Anwendung.Infrastruktur();
                //}

                return this._Kontext;
            }
        }

        /// <summary>
        /// Löst das Startup Ereignis aus
        /// </summary>
        /// <param name="e">Ereignisdaten mit den
        /// Startparamtern aus dem Betriebssystem</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //Ausdrücklich das machen,
            //was sonst im Startup erledigt wird
            base.OnStartup(e);

            //Anschließend...
            //Unsere Infrastruktur initialisieren
            //(Implizit beim ersten Zugriff auf die Eigenschaft)

            //Die zuletzt benutzte Oberflächensprache
            //wiederherstellen
            this.Kontext.Sprachen.Festlegen(
                Teil1.Properties.Settings.Default.AktuellerSprachcode);

            //Hauptviewmodell initialisieren
            var ViewModel = this.Kontext.Produziere<ViewModels.Anwendung>();

            //Das ViewModel bitten, die Hauptview zu öffnen
            ViewModel.Öffnen<Views.Hauptfenster>();
        }

        /// <summary>
        /// Löst das Exit Ereignis aus
        /// </summary>
        /// <param name="e">Ereignisdaten mit
        /// der Ursache des Beendens</param>
        protected override void OnExit(ExitEventArgs e)
        {
            //Vor dem Beenden...
            //Die aktuelle Sprache merken
            Teil1.Properties.Settings.Default.AktuellerSprachcode
                = this.Kontext.Sprachen.AktuelleSprache.Code;

            //Die Anwendungseinstellungen speichern
            Teil1.Properties.Settings.Default.Save();

            //Die Fensterpositionen und -zustände merken
            this.Kontext.Fenster.Speichern();

            //Zum Schluss noch das,
            //was sonst passiert
            base.OnExit(e);
        }
    }
}
