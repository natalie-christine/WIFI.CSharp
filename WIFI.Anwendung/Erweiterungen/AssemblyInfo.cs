using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Erweiterungen
{
    /// <summary>
    /// Stellt Erweiterungsmethoden
    /// zum Auslesen der Metadaten
    /// der aktuellen Anwendung bereit
    /// </summary>
    /// <remarks>Damit diese Informationen
    /// richtig sind, nach dem Erstellen
    /// eines Projekts sofort in den
    /// Projekteigenschaften Firmenname,
    /// Produktname, ... ausfüllen</remarks>
    public static class AssemblyInfo
    {
        #region Firmenname

        /// <summary>
        /// Gibt die AssemblyCompany Einstellung zurück
        /// </summary>
        /// <param name="o">Bei der Benutzung unsichtbar
        /// der Verweis auf das Objekt, wo diese
        /// Erweiterung benutzt wird</param>
        public static string HoleFirma(this object o)
        {

            //Die Assembly ermitteln,
            //mit der die Anwendung gestartet wurde
            object[] Einstellungen = System.Reflection.Assembly.GetEntryAssembly()!
            //Von dieser das  AssemblyCompany Attriute auslesen
                    .GetCustomAttributes(
                        typeof(System.Reflection.AssemblyCompanyAttribute),
                        inherit: true);

            //Den Text der Einstellung zurückgeben
            if (Einstellungen.Length > 0)
            {
                return ((System.Reflection.AssemblyCompanyAttribute)
                        Einstellungen[0]).Company;
            }

            return string.Empty;
        }

        #endregion Firmenname

        #region Produktbezeichnung

        /// <summary>
        /// Gibt die AssemblyProduct Einstellung zurück
        /// </summary>
        /// <param name="o">Bei der Benutzung unsichtbar
        /// der Verweis auf das Objekt, wo diese
        /// Erweiterung benutzt wird</param>
        public static string HoleProdukt(this object o)
        {

            //Die Assembly ermitteln,
            //mit der die Anwendung gestartet wurde
            object[] Einstellungen = System.Reflection.Assembly.GetEntryAssembly()!
            //Von dieser das AssemblyProduct Attriute auslesen
                    .GetCustomAttributes(
                        typeof(System.Reflection.AssemblyProductAttribute),
                        inherit: true);

            //Den Text der Einstellung zurückgeben
            if (Einstellungen.Length > 0)
            {
                return ((System.Reflection.AssemblyProductAttribute)
                        Einstellungen[0]).Product;
            }

            return string.Empty;
        }

        #endregion Produktbezeichnung

        #region Version mit Haupt- und Nebennummer

        /// <summary>
        /// Gibt die Haupt- und Nebennummer
        /// als Text zurück
        /// </summary>
        /// <param name="o">Bei der Benutzung unsichtbar
        /// der Verweis auf das Objekt, wo diese
        /// Erweiterung benutzt wird</param>
        public static string HoleVersion(this object o)
        {

            var Version = System.Reflection.Assembly
                .GetEntryAssembly()!.GetName().Version!;

            return $"{Version.Major}.{Version.Minor}";

        }

        #endregion Version mit Haupt- und Nebennummer

        #region Copyright

        /// <summary>
        /// Gibt die AssemblyCopyright Einstellung zurück
        /// </summary>
        /// <param name="o">Bei der Benutzung unsichtbar
        /// der Verweis auf das Objekt, wo diese
        /// Erweiterung benutzt wird</param>
        public static string HoleCopyright(this object o)
        {

            //Die Assembly ermitteln,
            //mit der die Anwendung gestartet wurde
            object[] Einstellungen = System.Reflection.Assembly.GetEntryAssembly()!
            //Von dieser das  AssemblyCompany Attriute auslesen
                    .GetCustomAttributes(
                        typeof(System.Reflection.AssemblyCopyrightAttribute),
                        inherit: true);

            //Den Text der Einstellung zurückgeben
            if (Einstellungen.Length > 0)
            {
                return ((System.Reflection.AssemblyCopyrightAttribute)
                        Einstellungen[0]).Copyright;
            }

            return string.Empty;
        }

        #endregion Copyright

    }
}
