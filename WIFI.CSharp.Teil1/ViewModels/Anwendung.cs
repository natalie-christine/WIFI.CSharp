using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.CSharp.Teil1.ViewModels
{
    /// <summary>
    /// Kontrolliert die Teil 1 WIFI C# MVVM Anwendung
    /// </summary>
    internal class Anwendung : WIFI.Anwendung.AppObjekt,
        System.ComponentModel.INotifyPropertyChanged
    {

        #region WPF über Änderungen informatieren

        /// <summary>
        /// Wird ausgelöst, wenn sich der
        /// Inhalt einer Eigenschaft geändert hat
        /// </summary>
        /// <remarks>Notwendig, damit die WPF Datenbindung
        /// die Oberfläche aktualisiert. WPF prüft aber
        /// nur das Interface unabhängig von diesem Ereignis</remarks>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Löst das Ereignis PropertyChanged aus
        /// </summary>
        /// <param name="eigenschaft">Die Bezeichnung
        /// der Eigenschaft, deren Inhalt geändert wurde</param>
        protected virtual void OnPropertyChanged(string eigenschaft)
        {
            var BehandlerKopie = this.PropertyChanged;
            BehandlerKopie?.Invoke(
                this,
                new PropertyChangedEventArgs(
                        eigenschaft
                        )
                );
        }

        #endregion WPF über Änderungen informatieren

        #region Hauptoberfläche kontrollieren

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private Befehl _BegrüßungZeigen = null!;

        /// <summary>
        /// Ruft den Befehl zum Anzeigen
        /// der Begrüßung ab
        /// </summary>
        public Befehl BegrüßungZeigen
        {
            get
            {
                this._BegrüßungZeigen
                    ??= new Befehl(
                        d =>
                        {
                            this.AktuellerInhalt = new Begrüßung();
                            this.IstBegrüßung = true;
                        });

                return this._BegrüßungZeigen;
            }
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private bool _IstBegrüßung = true;

        /// <summary>
        /// Ruft True ab, wenn der
        /// aktuelle Inhalt die Begrüßung enthält
        /// </summary>
        public bool IstBegrüßung
        {
            get => this._IstBegrüßung;
            set
            {
                this._IstBegrüßung = value;
                this.OnPropertyChanged("IstBegrüßung");
            }
        }

        /// <summary>
        /// Ruft einen Wahrheitswert ab,
        /// ob die Anwendung beim Beenden fragen soll,
        /// oder legt diesen fest.
        /// </summary>
        /// <remarks>Die Einstellung wird
        /// in der Anwendungskonfiguration über
        /// BeimBeendenFragen gespeichert</remarks>
        public bool BeimBeendenFragen
        {
            get => Properties.Settings.Default.BeimBeendenFragen;
            set
            {
                Properties.Settings.Default.BeimBeendenFragen = value;
                this.OnPropertyChanged("BeimBeendenFragen");
            }
        }

        /// <summary>
        /// Zeigt das gewünschte Fenster als Hauptoberfläche an
        /// </summary>
        /// <param name="view">Ein System.Windows.Window,
        /// welches für die Hauptoberfläche benutzt wird</param>
        public void Öffnen(System.Type view)
        {
            // Objekt für die View
            System.Windows.Window Fenster
                = (System.Activator.CreateInstance(view)
                    as System.Windows.Window)!;

            // Die neue View mit diesem ViewModel verbinden
            Fenster.DataContext = this;

            // Die View vorbereiten,
            // z. B. die alte Fensterposition wiederherstellen
            this.ViewInitialisieren(Fenster);

            // Die View anzeigen
            Fenster.Show();
        }

        /// <summary>
        /// Zeigt das gewünschte Fenster als Hauptfenster an
        /// </summary>
        /// <typeparam name="T">Ein System.Windows.Window,
        /// das als Hauptoberfläche benutzt werden soll</typeparam>
        public void Öffnen<T>() where T : System.Windows.Window, new()
        {
            this.Öffnen(typeof(T));
        }

        /// <summary>
        /// Bereitet ein Fenster für die Anzeige vor
        /// </summary>
        /// <param name="fenster">Ein System.Windows.Window,
        /// das für die Anzeige vorbereitet werden soll</param>
        /// <remarks>Hier wird zum Beispiel die alte
        /// Fensterposition wiederhergestellt und beim
        /// Schließen diese im FensterManager der
        /// Infrastruktur hinterlegt</remarks>
        protected virtual void ViewInitialisieren(
            System.Windows.Window fenster)
        {
            // Zum Wiederfinden muss 
            // das Fenster benannt sein
            fenster.Name = fenster.GetType().Name;

            #region Alte Position wiederherstellen

            var AlterZustand = this.Kontext
                .Fenster.Abrufen(fenster.Name);

            if (AlterZustand != null)
            {
                // Links, Oben, Breite und Höhe
                // einstellen, wenn Daten vorhanden sind
                fenster.Left = AlterZustand.Links ?? fenster.Left;
                fenster.Top = AlterZustand.Oben ?? fenster.Top;
                fenster.Width = AlterZustand.Breite ?? fenster.Width;
                fenster.Height = AlterZustand.Höhe ?? fenster.Height;

                // Beim Zustand nur Maximiert
                // Minimiert wird als Normal betrachtet,
                // weil sonst Personen beim
                // Starten die neue Anwendung übersehen
                if (AlterZustand.Zustand
                    == (int)System.Windows.WindowState.Maximized)
                {
                    fenster.WindowState
                        = System.Windows.WindowState.Maximized;
                }
                else
                {
                    //Damit Personen das Fenster nicht übersehen,
                    //alles andere (Standard seit Windows95)...
                    fenster.WindowState
                        = System.Windows.WindowState.Normal;
                }
            }

            #endregion Alte Position wiederherstellen

            #region Alte Position beim Schließen hinterlegen

            fenster.Closing += (sender, e) =>
            {

                #region Nachfragen, ob wirklich beendet werden soll

                if (this.BeimBeendenFragen)
                {
                    e.Cancel = System.Windows.MessageBox.Show(
                                    Views.Texte.BeendenFrage,
                                    Views.Texte.Titel,
                                    System.Windows.MessageBoxButton.YesNo,
                                    System.Windows.MessageBoxImage.Question)
                        == System.Windows.MessageBoxResult.No;
                }

                #endregion Nachfragen, ob wirklich beendet werden soll

                if (!e.Cancel)
                {
                    #region Fensterposition initialisieren
                    // Ein FensterInfo Objekt intialisieren
                    var Info = new WIFI.Anwendung.Daten.FensterInfo();

                    // Immer den Namen und den Zustand
                    Info.Name = fenster.Name;
                    Info.Zustand = (int)fenster.WindowState;

                    // Die Größenangaben nur,
                    // wenn das Fenster im Normalzustand ist,
                    // weil sonst die Information ungültig ist
                    if (fenster.WindowState == System.Windows.WindowState.Normal)
                    {
                        Info.Links = fenster.Left;
                        Info.Oben = fenster.Top;
                        Info.Breite = fenster.Width;
                        Info.Höhe = fenster.Height;
                    }

                    #endregion Fensterposition initialisieren

                    // Das FensterInfo Objekt
                    // an den FensterManager der Infrastruktur übergeben
                    this.Kontext.Fenster.Hinterlegen(Info);
                }
            };

            #endregion Alte Position beim Schließen hinterlegen
        }

        #endregion Hauptoberfläche kontrollieren

        #region Aktuelle Oberflächensprache

        /// <summary>
        /// Ruft die derzeit eingestellte 
        /// Oberflächensprache ab oder legt diese fest
        /// </summary>
        /// <remarks>Als Feld wird die Eigenschaft
        /// aus der Infrastruktur benutzt. Sollte
        /// die Sprache gewechselt werden, wird
        /// darauf hingewiesen, dass die Anwendung
        /// zum Übernehmen neugestartet werden muss</remarks>
        public WIFI.Anwendung.Daten.Sprache AktuelleSprache
        {
            get => this.Kontext.Sprachen.AktuelleSprache;
            set
            {
                this.Kontext.Sprachen.AktuelleSprache = value;

                //Meldung zeigen, dass neugestartet werden muss,
                //damit alle Caches gelöscht und neu 
                //in der gewählten Sprache aufgebaut werden
                System.Windows.MessageBox.Show(
                        Mitteilungen.Sprachwechsel,
                        Views.Texte.Titel,
                        System.Windows.MessageBoxButton.OK,
                        System.Windows.MessageBoxImage.Exclamation);

            }
        }

        #endregion Aktuelle Oberflächensprache

        #region Aktueller Inhalt

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private IAppInhalt _AktuellerInhalt = new Begrüßung();

        /// <summary>
        /// Ruft das Inhaltsobjekt ab, das
        /// das aktuelle Anwendungskapitel visualisiert
        /// </summary>
        /// <remarks>Standardinitialisierung 
        /// ist die Begrüßung</remarks>
        public IAppInhalt AktuellerInhalt
        {
            get => this._AktuellerInhalt;
            private set
            {
                this._AktuellerInhalt = value;
                this.OnPropertyChanged("AktuellerInhalt");
            }
        }

        #endregion Aktueller Inhalt

        #region Anwendungskapitel

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private static Models.ThemenManager? _ThemenManager = null;

        /// <summary>
        /// Ruft den Dienst zum Verwalten
        /// der Anwendungskapitel ab
        /// </summary>
        protected Models.ThemenManager ThemenManager
        {
            get
            {
                Anwendung._ThemenManager
                    ??= this.Kontext.Produziere<Models.ThemenManager>();

                return Anwendung._ThemenManager;
            }
        }

        /// <summary>
        /// Ruft die Liste mit den
        /// konfigurierten Anwendungskapitel ab
        /// </summary>
        public Models.Themen Themen
            => this.ThemenManager.Liste;

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private Models.Thema? _AktuellesThema = null;

        /// <summary>
        /// Ruft das aktuelle Anwendungskapitel
        /// ab oder legt dieses fest
        /// </summary>
        public Models.Thema AktuellesThema
        {
            get => this._AktuellesThema!;
            set
            {
                this._AktuellesThema = value;
                if (this._AktuellesThema != null)
                {
                    var NeuerInhalt = this.Kontext.Produziere<Information>();
                    NeuerInhalt.Thema = this._AktuellesThema;
                    NeuerInhalt.InfoPfad
                        = this.ThemenManager.Konfigurationspfad;

                    this.AktuellerInhalt = NeuerInhalt;
                    this.IstBegrüßung = false;
                }
            }
        }

        #endregion Anwendungskapitel
    }
}
