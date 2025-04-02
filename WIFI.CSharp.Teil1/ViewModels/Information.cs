using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WIFI.CSharp.Teil1.ViewModels
{
    /// <summary>
    /// Stellt einen Dienst zum Verarbeiten
    /// einer Anwendungskapitel Datei bereit
    /// </summary>
    public class Information
        : WIFI.Anwendung.AppObjekt, IAppInhalt
    {
        #region Für die Datenbindung

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private string _Text = null!;

        /// <summary>
        /// Ruft den Inhalt der Datei
        /// ohne Titel ab
        /// </summary>
        public string Text
        {
            get
            {
                if (this._Text == null)
                {
                    this.Initialisieren();
                }

                return this._Text!;
            }
            private set
            {
                this._Text = value;
            }
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private string _Titel = null!;

        /// <summary>
        /// Ruft die erste Zeile
        /// der Informationsdatei ab
        /// </summary>
        public string Titel
        {
            get
            {
                if (this._Titel == null)
                {
                    this.Initialisieren();
                }

                return this._Titel!;
            }
            private set
            {
                this._Titel = value;
            }
        }

        /// <summary>
        /// Ruft ein Objekt InformationViewerTyp ab,
        /// das zum Visualisieren des Anwendungskapitels
        /// benutzt werden soll
        /// </summary>
        /// <remarks>Sollte der Typ konfiguriert
        /// in den Anwendungseinstellungen nicht gefunden werden,
        /// wird ein leeres UserControl geliefert</remarks>
        public UserControl View
        {
            get
            {
                try
                {
                    return (System.Activator.CreateInstance(
                                Type.GetType(
                                    Properties.Settings.Default
                                    .InformationViewerTyp)!)
                             as System.Windows.Controls.UserControl)!;
                }
                catch (System.Exception ex)
                {
                    this.OnFehlerAufgetreten( 
                        new WIFI.Anwendung
                            .FehlerAufgetretenEventArgs(ex));
                    return new System.Windows.Controls.UserControl();
                }

            }
        }

        #endregion Für die Datenbindung

        #region Zur Unterstützung

        /// <summary>
        /// Ruft das Objekt mit der Beschreibung
        /// des Anwendungskapitels ab oder 
        /// legt dieses fest
        /// </summary>
        public Models.Thema? Thema { get; set; }

        /// <summary>
        /// Ruft den lokalisierten Verzeichnisnamen
        /// zu den Informationsdateien ab oder
        /// legt diesen fest.
        /// </summary>
        public string? InfoPfad { get; set; }

        /// <summary>
        /// Liest den Inhalt der Thema-Datei
        /// und teilt das Ergebnis auf Titel
        /// und Text auf
        /// </summary>
        /// <remarks>Die erste Zeile ist der Titel,
        /// der Rest der Text</remarks>
        private void Initialisieren()
        {
            try
            {
                var Pfad = System.IO.Path.Combine(
                    this.InfoPfad!,
                    Thema!.Datei);
                using var Leser
                    = new System.IO.StreamReader(
                            Pfad,
                            System.Text.Encoding.Latin1
                            );

                //Die erste Zeile für den Titel
                this.Titel = Leser.ReadLine()!.Trim();

                //Der Rest für den Text
                this.Text = Leser.ReadToEnd().Trim();
                
            }
            catch (System.Exception ex)
            {
                this.OnFehlerAufgetreten(
                    new WIFI.Anwendung.FehlerAufgetretenEventArgs(ex));
            }
        }

        #endregion Zur Unterstützung
    }
}
