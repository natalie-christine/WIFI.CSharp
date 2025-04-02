using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung
{
    /// <summary>
    /// Stellt den Anwendungskontext
    /// für eine WIFI Anwendung bereit
    /// </summary>
    /// <remarks>Diese Klasse muss beim Starten
    /// der Anwendung als erste initialisiert 
    /// und an alle anderen Anwendungsobjekte
    /// übergeben werden. Dazu am einfachsten
    /// die Produzier&lt;T&gt; Methode verwenden.</remarks>
    public class Infrastruktur : System.Object
    {

        #region Objektfabrik

        /// <summary>
        /// Gibt ein initalisiertes
        /// Anwendungsobjekt zurück
        /// </summary>
        /// <typeparam name="T">Ein Typ, der die Kontext Eigenschaft besitzt</typeparam>
        /// <returns>Ein Anwendungsobjekt mit 
        /// voreingestellter Kontext Eigenschaft</returns>
        public T Produziere<T>() where T : AppObjekt, new()
        {
            //Neues Objekt initialisieren...
            var Anwendungsobjekt = new T();

            //Im neuen Objekt die Kontext Eigenschaft
            //mit der aktuellen Infrastruktur initialisieren
            Anwendungsobjekt.Kontext = this;

            Anwendungsobjekt.FehlerAufgetreten 
                += (sender, e) 
                => System.Diagnostics.Debug.WriteLine(
                    $"FEHLER! Ausnahme in {Anwendungsobjekt}\r\n{e.Ausnahme.Message}");

#if DEBUG
            System.Diagnostics.Debug.WriteLine(
                $"--> {Anwendungsobjekt} wurde initialisiert...");
#endif

            //Weitere Vorbereitungsarbeiten ergänzen

            return Anwendungsobjekt;
        }

        #endregion Objektfabrik

        #region Anwendungssprachen

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private SprachenManager? _Sprachen = null;

        /// <summary>
        /// Ruft den Dienst zum Verwalten
        /// der Anwendungssprachen ab.
        /// </summary>
        public SprachenManager Sprachen
        {
            get
            {
                //Beim ersten Mal initialisieren und cachen
                if (this._Sprachen == null)
                {
                    this._Sprachen = this.Produziere<SprachenManager>();

                    //Die Objektfabrik Produziere versteckt, kapselt...
                    /*
                    this._Sprachen = new SprachenManager();
                    this._Sprachen.Kontext = this;
                    */
                }

                return this._Sprachen;
            }
        }

        #endregion Anwendungssprachen

        #region Fensterverwaltung

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private FensterManager? _Fenster = null;

        /// <summary>
        /// Ruft den Dienst zum Verwalten
        /// der Anwendungsfensterpositionen
        /// bzw. -zustände ab
        /// </summary>
        public FensterManager Fenster
        {
            get
            {
                if (this._Fenster == null)
                {
                    this._Fenster = this
                        .Produziere<FensterManager>();
                }

                return this._Fenster;
            }
        }

        #endregion Fensterverwaltung
    }
}
