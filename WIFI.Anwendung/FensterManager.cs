using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung
{
    /// <summary>
    /// Stellt einen Dienst zum Verwalten
    /// der Anwendungsfenster Positionen
    /// und Zustände bereit
    /// </summary>
    /// <remarks>Bekannte Schwäche - wird
    /// ein Fenster auf einem später nicht
    /// mehr vorhanden Monitor geschlossen,
    /// erscheint das Fenster außerhalb
    /// des sichtbaren Bereichs (Lösung im Teil 2)</remarks>
    public class FensterManager : AppObjekt
    {
        #region Verwaltete FensterInfo Objekte

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private Daten.FensterInfos _Liste = null!;

        /// <summary>
        /// Ruft die verwalteten FensterInfo Objekte ab
        /// </summary>
        protected Daten.FensterInfos Liste 
            => this._Liste ??= this.Lesen();

        #endregion Verwaltete FensterInfo Objekte

        #region Datencontroller

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private Controller.FensterController? _Controller = null;

        /// <summary>
        /// Ruft den Dienst zum Lesen und Schreiben
        /// von Fensterpositionen ab
        /// </summary>
        private Controller.FensterController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = this.Kontext
                        .Produziere<WIFI.Anwendung.Controller
                            .FensterController>();
                }
                return this._Controller;
            }
        }

        #endregion Datencontroller

        #region Speichern und Laden

        /// <summary>
        /// Ruft den vollständigen Pfad
        /// der Datei für die FensterInfo Objekte ab.
        /// </summary>
        /// <remarks>Er befindet sich im lokalen
        /// Datenpfad des aktuellen Benutzerprofils</remarks>
        public string Standardspeicherort
            => System.IO.Path.Combine(
                this.LokalerDatenpfad, 
                "Fenster.xml");

        /// <summary>
        /// Gibt die Liste der im Pfad
        /// gespeicherten FensterInfo Objekte zurück
        /// </summary>
        /// <returns>Eine leere Liste, falls
        /// die Datei nicht gefunden wurde oder
        /// ein anderes Problem aufgetreten ist.
        /// Als Pfad wird der Standardspeicherort benutzt</returns>
        /// <remarks>Die Datei wird im Standardspeicherort
        /// gesucht und mit der Xml Deserialisierung
        /// in den Arbeitsspeicher geholt. Sollte die
        /// Deserialisierung nicht möglich sein,
        /// z. B. bei einem neuen Benutzer, wird
        /// das Ereignis FehlerAufgetreten ausgelöst</remarks>
        protected Daten.FensterInfos Lesen()
        {
            try
            {
                return this.Controller
                    .Lesen(this.Standardspeicherort)!;
            }
            catch (System.Exception ex)
            {
                this.OnFehlerAufgetreten(
                    new FehlerAufgetretenEventArgs(ex));
                //Damit nachfolgende Bereiche
                //eine leere Liste bekommen
                return new Daten.FensterInfos();
            }
        }

        /// <summary>
        /// Schreibt die FensterInfo Ojekte
        /// in die Datei des Standardspeicherorts
        /// </summary>
        /// <remarks>Es wird die Xml Serialisierung benutzt
        /// und das Ereignis FehlerAufgetreten ausgelöst,
        /// wenn das Speichern nicht erfolgreich war</remarks>
        public void Speichern()
        {
            try
            {
                this.Controller.Speichern(
                    this.Standardspeicherort,
                    this.Liste);
            }
            catch (System.Exception ex) 
            {
                this.OnFehlerAufgetreten(
                    new FehlerAufgetretenEventArgs(ex));
            }
        }

        #endregion Speichern und Laden

        #region Hinzufügen und Abrufen

        /// <summary>
        /// Fügt der Liste mit den verwalteten Fenstern
        /// einen Eintrag hinzu bzw. aktualisiert einen Eintrag
        /// </summary>
        /// <param name="fenster">FensterInfo des Fensters,
        /// dessen Zustand gespeichert werden soll</param>
        /// <remarks>Als Schlüssel wird die Name Eigenschaft
        /// benutzt. Die Methode ist case-sensitiv</remarks>
        public void Hinterlegen(Daten.FensterInfo fenster)
        {
            // Prüfen, ob das Fenster bereits vorhanden ist
            var FensterVorhanden
                    = this.Liste.Find(
                        f => f.Name == fenster.Name
                        );

            // Falls nein, das Fenster in die Liste hinzufügen
            if (FensterVorhanden == null)
            {
                this.Liste.Add(fenster);
            }
            else
            {
                // Falls ja, den Zustand aktualisieren
                FensterVorhanden.Zustand = fenster.Zustand;

                // und die Positionsangaben nur,
                // wenn solche vorhanden sind, sonst
                // unverändert lassen
                FensterVorhanden.Links
                    = fenster.Links ?? FensterVorhanden.Links;
                FensterVorhanden.Oben
                    = fenster.Oben ?? FensterVorhanden.Oben;
                FensterVorhanden.Breite
                    = fenster.Breite ?? FensterVorhanden.Breite;
                FensterVorhanden.Höhe
                    = fenster.Höhe ?? FensterVorhanden.Höhe;
            }
        }

        /// <summary>
        /// Gibt das Objekt mit den Informationen
        /// für das gewünschte Fenster zurück
        /// </summary>
        /// <param name="name">Der interne Bezeichner
        /// des Fensters, dessen FensterInfo Objekt benötigt wird</param>
        /// <returns>Null, falls das Fenster
        /// nicht gefunden wurde</returns>
        /// <remarks>Die Methode ist case-sensitiv</remarks>
        public Daten.FensterInfo? Abrufen(string name)
            => this.Liste.Find(f => f.Name == name);


        #endregion Hinzufügen und Abrufen
    }
}
