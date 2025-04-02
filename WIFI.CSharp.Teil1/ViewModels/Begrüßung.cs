using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using WIFI.Anwendung.Erweiterungen;

namespace WIFI.CSharp.Teil1.ViewModels
{
    /// <summary>
    /// Wird als erster Inhalt in
    /// der Anwendung benutzt
    /// </summary>
    public class Begrüßung
        : WIFI.Anwendung.AppObjekt, IAppInhalt
    {
        /// <summary>
        /// Ruft den Copyright Text
        /// aus den Projekteigenschaften ab
        /// </summary>
        public string Copyright => this.HoleCopyright();

        /// <summary>
        /// Ruft den Anwendungstitel
        /// zweizeilig ab
        /// </summary>
        /// <remarks>Für den Zeilenumbruch
        /// wird " - " ersetzt</remarks>
        public string Überschrift
            => Views.Texte.Titel.Replace(" - ", "\r\n");

        /// <summary>
        /// Ruft den Willkommens Text ab
        /// </summary>
        public string Titel => Views.Texte.Willkommen;

        /// <summary>
        /// Ruft das Objekt ab, welches
        /// zur Visualisierung der Begrüßung 
        /// benutzt werden soll
        /// </summary>
        /// <remarks>Es kann über die Anwendungskonfiguration
        /// mit der Einstellung BegrüßungViewerTyp gesteuert werden</remarks>
        public UserControl View
        {
            get
            {
                try
                {
                    return (System.Activator.CreateInstance(
                                Type.GetType(
                                    Properties.Settings.Default.BegrüßungViewerTyp
                                    )!
                                )
                        as System.Windows.Controls.UserControl)!;
                }
                catch (System.Exception ex)
                {
                    this.OnFehlerAufgetreten(
                        new WIFI.Anwendung.FehlerAufgetretenEventArgs(ex)
                        );
                    return new System.Windows.Controls.UserControl();
                }

            }
        }
    }
}
