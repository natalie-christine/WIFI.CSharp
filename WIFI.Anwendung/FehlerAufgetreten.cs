using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung
{
    /// <summary>
    /// Stellt die Methode bereit, die das
    /// FehlerAufgetreten Ereignis behandelt.
    /// </summary>
    /// <param name="sender">Verweis auf das Objekt, 
    /// dass die Methode aufruft</param>
    /// <param name="e">Ereignisdaten mit der Fehlerbeschreibung</param>
    /// <remarks>Erstes eigenes Ereignis. Alle .Net Ereignisse
    /// besitzen genau diese zwei Parameter</remarks>
    public delegate void FehlerAufgetretenEventHandler(
                            object sender,
                            FehlerAufgetretenEventArgs e);

    /// <summary>
    /// Stellt die Daten für das 
    /// FehlerAufgetreten Ereignis bereit
    /// </summary>
    public class FehlerAufgetretenEventArgs : System.EventArgs
    {
        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private System.Exception _Ausnahme = null!;

        /// <summary>
        /// Initialisiert ein neues 
        /// FehlerAufgetretenEventArgs Objekt
        /// </summary>
        /// <param name="ausnahme">Exception, die den Fehler beschreibt</param>
        public FehlerAufgetretenEventArgs(System.Exception ausnahme)
        {
            this._Ausnahme = ausnahme;
        }

        /// <summary>
        /// Ruft die Ursache des Fehlers ab
        /// </summary>
        public System.Exception Ausnahme => this._Ausnahme;
    }
}
