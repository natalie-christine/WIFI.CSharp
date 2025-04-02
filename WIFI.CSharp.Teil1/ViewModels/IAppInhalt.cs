using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.CSharp.Teil1.ViewModels
{
    /// <summary>
    /// Stellt Mitglieder bereit,
    /// die ein Objekt, das als AktuellerInhalt
    /// benutzt werden möchte, kennen muss
    /// </summary>
    public interface IAppInhalt
    {
        /// <summary>
        /// Ruft den Titel des
        /// aktuellen Inhalts ab
        /// </summary>
        string Titel { get; }

        /// <summary>
        /// Ruft das Steuerelement zum Darstellen
        /// des aktuellen Inhalts ab
        /// </summary>
        System.Windows.Controls.UserControl View { get; }
    }
}
