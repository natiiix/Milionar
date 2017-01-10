using System;

namespace Milionar
{
    class Program
    {
        static void Main(string[] args)
        {
            // urceni kolik penez bude hrac mit po zodpovezeni daneho mnozstvi otazek
            int[] mnozstviPenez =
            {
                0,
                100, 200, 300, 500, 1000,
                2000, 4000, 8000, 16000, 32000,
                64000, 125000, 250000, 500000, 1000000
            };
            Otazka[] otazky =
            {
                // vysvetleni syntaxe:
                // 1. retezec otazky, musi byt v uvozovkach
                // 2. cislo spravne odpovedi (A => 0, B => 1, C => 2, D => 3,..)
                // 3. jednotlive otazky, pocet muze byt libovolny, musi byt v uvozovkach
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3"),
                new Otazka("Kolik měsíců má Země?", 1, "žádný", "1", "2", "3")
            };
            int maxMnozstviOtazek = 15;
            int pocetSpravnychOdpovedi = 0;
            Random rand = new Random();

            // dokud uzivatel nezodpovedel urceny pocet otazek spravne, budou mu pokladany dalsi otazky
            while (pocetSpravnychOdpovedi < maxMnozstviOtazek)
            {
                // vygenerovani otazky, ktera jeste nebyla polozena
                int vybranaOtazka = 0;
                while (otazky[(vybranaOtazka = rand.Next(otazky.Length))].Polozena) ;

                // vycisti se obrazovka
                Console.Clear();

                // vypise se aktualni stav hracova konta
                Console.WriteLine("Aktuálně máte ${0}.", mnozstviPenez[pocetSpravnychOdpovedi]);

                // vypise se otazka
                Console.WriteLine(Environment.NewLine + "Otázka:");
                Console.WriteLine(otazky[vybranaOtazka].ToString());
                Console.Write(Environment.NewLine + "Vaše odpověď: ");

                // pokud hrac odpovedel spatne, je o tom informovan a hra konci
                if (!otazky[vybranaOtazka].JeSpravnaOdpoved(Console.ReadLine()))
                {
                    ZobrazitZpravuOOdpovedi(false);
                    break;
                }

                // pokud odpovedel spravne, zvysi se pocet spravnych odpovedi,
                // je informovan o spravne odpovedi a hra pokracuje
                pocetSpravnychOdpovedi++;
                ZobrazitZpravuOOdpovedi(true);
            }

            // vypsani vyhraneho mnozstvi penez
            Console.Clear();
            Console.WriteLine("Vyhrál jste ${0}!", mnozstviPenez[pocetSpravnychOdpovedi]);
            Console.ReadKey();
        }

        private static void ZobrazitZpravuOOdpovedi(bool _spravnaOdpoved)
        {
            Console.WriteLine(Environment.NewLine + (_spravnaOdpoved ? "Správná" : "Špatná") + " odpověď!");
            Console.WriteLine("Pokračujte stiskem libovolné klávesy.");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Trida ktera uchovava jednotlive otazky vcetne vsech odpovedi a oznaceni spravne odpovedi
    /// </summary>
    class Otazka
    {
        public string Text { get; private set; }
        public int SpravnaOdpoved { get; private set; }
        public string[] Odpovedi { get; private set; }
        public bool Polozena { get; private set; }

        /// <summary>
        /// Vytvori objekt tridy Otazka
        /// </summary>
        /// <param name="_text">Text otazky</param>
        /// <param name="_spravnaOdpoved">ID spravne odpovedi</param>
        /// <param name="_odpovedi">Vsechny dostupne odpovedi</param>
        public Otazka(string _text, int _spravnaOdpoved, params string[] _odpovedi)
        {
            Text = _text;
            SpravnaOdpoved = _spravnaOdpoved;
            Odpovedi = _odpovedi;
            Polozena = false;
        }

        /// <summary>
        /// Vyhodnoti vstup uzivatele
        /// </summary>
        /// <returns>Vraci true pokud bylo odpoved spravna, jinak vraci false</returns>
        public bool JeSpravnaOdpoved(string input)
        {
            return (input.ToUpper() == ((char)('A' + SpravnaOdpoved)).ToString());
        }

        /// <summary>
        /// Prevede otazku do vystupniho formatu
        /// </summary>
        /// <returns>Vraci retezec obsahujici otazku a odpovedi</returns>
        public override string ToString()
        {
            string strOdpovedi = string.Empty;

            for (int i = 0; i < Odpovedi.Length; i++)
                // postupne se pripisou vsechny otazky do retezce
                // kazde se priradi prislusne pismeno a za kazdou krome posledni se udela novy radek
                strOdpovedi += (char)('A' + i) + ") " + Odpovedi[i] + (i + 1 < Odpovedi.Length ? Environment.NewLine : string.Empty);

            // ulozi se informace o tom ze otazka uz byla polozena
            Polozena = true;

            return Text + Environment.NewLine + strOdpovedi;
        }
    }
}
