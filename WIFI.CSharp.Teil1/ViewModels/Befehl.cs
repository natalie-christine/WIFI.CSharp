using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.CSharp.Teil1.ViewModels
{
    /// <summary>
    /// Kapselt eine Methode, die
    /// für die Befehlsbindung benötigt wird
    /// </summary>
    /// <remarks>TODO CanExecute und CanExecuteChanged verbessern (Teil 2)</remarks>
    public class Befehl : System.Object, System.Windows.Input.ICommand
    {
        /// <summary>
        /// Wird ausgelöst, wenn sich die
        /// Voraussetzung für den Befehl geändert hat
        /// </summary>
        /// <remarks>TODO - Muss an den 
        /// Befehlsmanager gebunden werden</remarks>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Gibt einen Wahrheitswert zurück,
        /// ob der Befehl aktuell zulässig ist oder nicht
        /// </summary>
        /// <param name="parameter">Zusatzdaten der Datenbindung</param>
        /// <remarks>Aktuell wird immer True
        /// zurückgeben. TODO - an eine Prüfmethode binden</remarks>
        public bool CanExecute(object? parameter) => true;

        /// <summary>
        /// Ruft die in diesem Befehlsobjekt
        /// gekapselte Methode auf
        /// </summary>
        /// <param name="parameter">Zusatzdaten der Datenbindung</param>
        public void Execute(object? parameter)
        {
            this._Methode.Invoke(parameter!);
        }

        /// <summary>
        /// Internes Feld für die
        /// gekapselte Methode
        /// </summary>
        private System.Action<object> _Methode = null!;

        /// <summary>
        /// Initialisiert ein Befehl-Objekt
        /// </summary>
        /// <param name="methode">Die Speicheradresse
        /// der Methode, die in diesem Objekt für
        /// die Befehlsbindung gekapselt wird</param>
        public Befehl(System.Action<object> methode)
        {
            this._Methode = methode;
        }
    }
}
