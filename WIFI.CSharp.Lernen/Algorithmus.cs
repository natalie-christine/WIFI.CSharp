namespace WIFI.CSharp.Lernen
{
    /// <summary>
    /// Enthält für jeden Algorithmen Baustein
    /// ein Beispiel getippt in C#
    /// </summary>
    internal class Algorithmus : Entwicklungsbasis
    {
        /// <summary>
        /// Gibt am Bildschirm den
        /// Text "Hallo Welt!" aus.
        /// </summary>
        public void ZeigeSequenz()
        {
            Algorithmus.Ausgeben(
                "ZeigeSequenz startet...",
                AusgabeModus.Debug);

            //Unbedingte Texte für die Oberfläche
            //aus Ressourcen, damit die
            //Anwendung lokalisiert werden kann.
            Algorithmus.Ausgeben(Texte.Hallo);

            Algorithmus.Ausgeben(
                "ZeigeSequenz beendet.",
                AusgabeModus.Debug);

        }

        /// <summary>
        /// Ermittelt in einem gegebenen
        /// Interfall eine zufällige Ganzzahl
        /// und gibt die Meldung aus, ob
        /// die Zahl unter oder über 
        /// einer Grenze liegt.
        /// </summary>
        /// <remarks>Beispiel für die 
        /// C# if - Anweisung</remarks>
        // 20241029 Die Grenze wird jetzt genau gemeldet
        public void ZeigeBinär()
        {
            Algorithmus.Ausgeben(
                "ZeigeBinär startet...",
                AusgabeModus.Debug);

            //Zufällige Zahl in
            //einem gegebenen Intervall
            //berechnen
            const int Untergrenze = 1;
            const int Obergrenze = 100;
            const int Grenze = 50;

            int Zufallszahl
                = this.Zufallsgenerator
                    .Next(
                        Untergrenze,    //Laut Handbuch inklusiv
                        Obergrenze + 1  //Laut Handbuch exklusiv
                        );

            //20241029 - Grenze genau melden
            //string Ergebnis = Texte.BinärGrößerGleich;
            string Ergebnis = Texte.BinärGleich;

            //Prüfen ob die Zahl
            //unter oder über einer Grenze ist
            if (Zufallszahl < Grenze)
            {
                Ergebnis = Texte.BinärKleiner;
            }
            //20241029 - Grenze genau melden
            else if (Zufallszahl > Grenze)
            {
                Ergebnis = Texte.BinärGrößer;
            }

            //Das Ergebnis mitteilen
            Algorithmus.Ausgeben(
                string.Format(
                    Ergebnis,       //mit {0} und {1}
                    Zufallszahl,    //für {0}
                    Grenze          //für {1}
                    )
                );

            Algorithmus.Ausgeben(
                "ZeigeBinär beendet.",
                AusgabeModus.Debug);

        }

        /// <summary>
        /// Präsentiert die Beispiele
        /// zum Lernen der objektorientierten
        /// Programmierung mit C# und .Net
        /// </summary>
        public static void Arbeite()
        {
            Algorithmus.Ausgeben(
                "Algorithmus.Arbeite startet...",
                AusgabeModus.Debug);

            Algorithmus.Ausgeben(Texte.Programmpunkte);

            // Eine Objektinstanz initialisieren
            var AlgoObjekt = new Algorithmus();

            // In einer Durchlaufe-Schleife
            // solange arbeiten, bis der Wunsch
            // 9 = Beenden eingegeben wird
            var Eingabe = string.Empty; //=""

            do
            {
                Algorithmus.Ausgeben(
                                Texte.Prompt,
                                AusgabeModus.NormalBleibeInZeile);
                Eingabe = System.Console
                    .ReadLine()?.Trim();

                // Mit einer Fallentscheidung
                // die Eingabe zuordnen und
                // die jeweilige Methode aufrufen
                switch (Eingabe)
                {
                    case "1":
                        AlgoObjekt.ZeigeSequenz();
                        break;
                    case "2":
                        AlgoObjekt.ZeigeBinär();
                        break;
                    case "3":
                        AlgoObjekt.ZeigeFall();
                        break;
                    case "4":
                        AlgoObjekt.ZeigeZählen();
                        break;
                    case "5":
                        AlgoObjekt.ZeigeAbweisen();
                        break;
                    case "6":
                        AlgoObjekt.ZeigeDurchlaufen();
                        break;

                    case "9" or "":
                        //Leerer Fall, damit kein
                        //Fehler angezeigt wird
                        //beim Beenden oder keiner Eingabe
                        break;

                    default:
                        Algorithmus.Ausgeben(
                            Texte.Eingabefehler,
                            AusgabeModus.Fehler);
                        break;
                }

            } while (Eingabe != "9");

            /*
            // Die nicht statischen
            // Mitglieder benutzen
            AlgoObjekt.ZeigeSequenz();
            AlgoObjekt.ZeigeBinär();
            AlgoObjekt.ZeigeFall();
            AlgoObjekt.ZeigeZählen();
            */

            // Das Objekt freigeben,
            // d.h. der Garbage Collection helfen
            AlgoObjekt = null!;

            Algorithmus.Ausgeben(
                "Algorithmus.Arbeite beendet.",
                AusgabeModus.Debug);
        }

        /// <summary>
        /// Gibt passend zu einer zufälligen
        /// Stunde einen Begrüßungstext aus
        /// </summary>
        /// <remarks>Beispiel für die
        /// C# switch - Anweisung</remarks>
        public void ZeigeFall()
        {
            Algorithmus.Ausgeben(
                "ZeigeFall startet...",
                AusgabeModus.Debug);

            int ZufälligeStunde
                = this.Zufallsgenerator.Next(24);

            Algorithmus.Ausgeben(
                $"Stunde {ZufälligeStunde}",
                AusgabeModus.Debug);
            Algorithmus.Ausgeben(
                string.Format(
                    Texte.Begrüßung,
                    Algorithmus.ErmittleBegrüßung(
                                    ZufälligeStunde),
                    ZufälligeStunde)
                );

            Algorithmus.Ausgeben(
                "ZeigeFall beendet.",
                AusgabeModus.Debug);

        }

        /// <summary>
        /// Internes Feld zum Zwischenspeichern
        /// des ZeigeZählen Ergebnisses
        /// </summary>
        private string? _ZeigeZählenCache = null;

        /// <summary>
        /// Testet die Begrüßung aus der
        /// Fallentscheidung für jede 
        /// mögliche Stunde von 0 bis 23
        /// </summary>
        /// <remarks>Beispiel für die
        /// C# for - Anweisung</remarks>
        public void ZeigeZählen()
        {
            Algorithmus.Ausgeben(
                "ZeigeZählen startet...",
                AusgabeModus.Debug);

            if (this._ZeigeZählenCache == null)
            {
                //Zum Verketten einer größeren
                //Textmenge in einer Schleife
                //Objekt deklarieren und initalisieren
                var Text = new System.Text.StringBuilder();

                for (int i = 0; i < 24; i++)
                {
                    //Objekt benutzen
                    Text.AppendLine(
                        string.Format(
                            Texte.Begrüßung,
                            Algorithmus.ErmittleBegrüßung(i),
                            i));
                }

                this._ZeigeZählenCache = Text.ToString();
                Algorithmus.Ausgeben(
                    "ZeigeZählen hat das Ergebnis gecachet...",
                    AusgabeModus.Debug);

                //Dem Garbage Collector sagen,
                //dass das Objekt nicht mehr benötigt
                //wird und aus dem Speicher entfernt
                //werden kann...
                Text = null;

            } // <- Hier würde Text implizit null

            Algorithmus.Ausgeben(this._ZeigeZählenCache);

            Algorithmus.Ausgeben(
                "ZeigeZählen beendet.",
                AusgabeModus.Debug);

        }

        /// <summary>
        /// Liest einer unformatierte Textdatei
        /// und gibt den Inhalt als Fließtext aus
        /// </summary>
        /// <remarks>Beispiel für die
        /// C# while - Anweisung. Die Datei
        /// muss "Wörter.txt" heißen und im
        /// Anwendungsverzeichnis liegen.</remarks>
        public void ZeigeAbweisen()
        {
            Algorithmus.Ausgeben(
                "ZeigeAbweisen startet...",
                AusgabeModus.Debug);

            const string Datei = "Wörter.txt";
            var Dateipfad = System.IO.Path
                .Combine(
                    Algorithmus.Anwendungspfad,
                    Datei);
#if DEBUG
            //Zum Testen des eigenen Ereignisses
            //in 20 % der Aufrufe eine falsche Datei benutzen
            if (this.Zufallsgenerator.Next(100) < 20)
            {
                Dateipfad = "Falsch zum Testen des Ereignisses";
            }
#endif
            /*
            var Text = new Textdatei();
            Text.Pfad = Dateipfad;
            */
            var Text = new Textdatei { Pfad = Dateipfad };
            // Einen Ereignis-Behandler anhängen,
            // damit eine Meldung ausgegeben wird,
            // dass ein Problem aufgetreten ist
            Text.LeseFehlerAufgetreten += LesefehlerMelden;

            //NIE SO!!!
            //Algorithmus.Ausgeben(Text.HoleFließtext(60));
            //Benannte Parameter nutzen!
            //Algorithmus.Ausgeben(Text.HoleFließtext(maxZeilenlänge: 60));

            var Zeilenbreite
                = this.Zufallsgenerator.Next(33, 68) / 100.0
                            * System.Console.WindowWidth;

            Algorithmus.Ausgeben(Text.HoleFließtext((int)Zeilenbreite));

            Algorithmus.Ausgeben(
                "ZeigeAbweisen beendet.",
                AusgabeModus.Debug);

        }

        /// <summary>
        /// Schreibt eine Fehlermeldung
        /// in die Konsole, dass beim
        /// Lesen des Fließtextes ein Problem
        /// aufgetreten ist
        /// </summary>
        private void LesefehlerMelden(object? sender, EventArgs e)
        {
            Algorithmus.Ausgeben(
                "Nur zum Testen des eigenen Ereignisses!",
                AusgabeModus.Fehler);
        }

        /// <summary>
        /// Berechnet für ein unterstütztes 
        /// Land einen Lottoquicktipp und 
        /// zeigt diesen an
        /// </summary>
        /// <remarks>Beispiel für die
        /// C# do - Anweisung</remarks>
        public void ZeigeDurchlaufen()
        {
            Algorithmus.Ausgeben(
                "ZeigeDurchlaufen startet...",
                AusgabeModus.Debug);

            int ZufälligerIndex
                = this.Zufallsgenerator.Next(
                    Lottoland.UnterstützteLänder.Length);

            var Land = Lottoland.UnterstützteLänder[ZufälligerIndex];
            var Tipp =
                $"Lotto {Land.Name} {Land.AnzahlZahlen} aus {Land.HöchsteZahl}\r\n";

            // Die Zahlen des Tipps an das Ergebnis anhängen
            foreach (int Zahl in Land.BerechneTipp())
            {
                Tipp += Zahl.ToString().PadLeft(3);
            }

            // Den Tipp ausgeben
            Algorithmus.Ausgeben(Tipp);

            Algorithmus.Ausgeben(
                "ZeigeDurchlaufen beendet.",
                AusgabeModus.Debug);

        }

        /// <summary>
        /// Gibt passend zur Stunde einen
        /// lokalisierten Begrüßungstext zurück
        /// </summary>
        /// <param name="zuStunde">Ein ganzzahliger
        /// Wert zwischen 0 und 23</param>
        /// <remarks>Hier handelt es sich um
        /// das eigentliche Beispiel für die
        /// Fallentscheidung getippt mit C# switch</remarks>
        public static string ErmittleBegrüßung(
                                int zuStunde
                        )
        {
            switch (zuStunde)
            {
                case var s when s >= 5 && s <= 10:
                    return Texte.GrußAmMorgen;
                case var s when s >= 11 && s <= 14:
                    return Texte.GrußZuMittag;
                case var s when s >= 17 && s <= 22:
                    return Texte.GrußAmAbend;
                default:
                    return Texte.GrußStandard;
            }
        }
    }
}
