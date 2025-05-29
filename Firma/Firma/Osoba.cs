using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    abstract class Osoba
    {
        private string imie;
        private string nazwisko;
        private DateTime dataUrodzenia;
        private string PESEL;
        private Plcie plec;
        private string telefon;

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }
        public DateTime Dataurodzenia
        {
            get { return dataUrodzenia; }
            set { dataUrodzenia = value; }
        }
        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }
        public string Pesel
        {
            get { return PESEL; }
            set { PESEL = value; }
        }
        public Plcie Plec
        {
            get { return plec; }
            set { plec = value; }
        }
        public Osoba()
        {
            imie = "Mateusz";
            nazwisko = "Przewrot";
            dataUrodzenia = DateTime.Parse("13.03.2007");
            PESEL = "00000000000";
        }
        public Osoba(string Imie, string Nazwisko)
        {
            imie = Imie;
            nazwisko = Nazwisko;
        }
        public Osoba(string Imie, string Nazwisko, string data_urodzenia, string Pesel, Plcie Plec)
        {
            imie = Imie;
            nazwisko = Nazwisko;
            DateTime.TryParseExact(data_urodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out dataUrodzenia);
            PESEL = Pesel;
            plec = Plec;
        }
        public Osoba(string Imie, string Nazwisko, string data_urodzenia, string Pesel, Plcie Plec, string Telefon)
        {
            imie = Imie;
            nazwisko = Nazwisko;
            DateTime.TryParseExact(data_urodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out dataUrodzenia);
            PESEL = Pesel;
            plec = Plec;
            telefon = Telefon;
        }
        public int Wiek()
        {
            DateTime today = DateTime.Today;
            return (today - dataUrodzenia).Days/365;
        }
        /*public new void ToString()
        {
            Console.Writeline(PESEL + imie + nazwisko);
        }*/
        public override string ToString()
        {
            return PESEL + " " + imie + " " + nazwisko + " " + "(" + Wiek() + ")";
        }
        public string Format()
        {
            return (Char.ToUpper(imie[0]).ToString() + (imie.Substring(1)).ToLower()) + " " + (Char.ToUpper(nazwisko[0]).ToString() + (nazwisko.Substring(1)).ToLower());
        }
        public int Godziny(string godzina_urodzenia)
        {
            int godzina_int = int.Parse(godzina_urodzenia);
            int days;
            DateTime today = DateTime.Today;
            days = (today - dataUrodzenia).Days;
            return days * 24 + godzina_int;
        }
        public void checkPESEL()
        {
            string year = dataUrodzenia.Year.ToString();
            string day = dataUrodzenia.Day.ToString();
            string month = dataUrodzenia.Month.ToString();
            string millenial = (dataUrodzenia.Month + 20).ToString();
            int gender = Convert.ToInt32(PESEL[9]);
            int counter = 0;
            int sum = 0;
            string control;

            for (int i = 0; i < 10; i++)
            {
                if(counter == 0)
                {
                    sum += (int.Parse(PESEL[i].ToString()) * 1) % 10;
                    counter++;
                    continue;
                }
                if(counter == 1)
                {
                    sum += (int.Parse(PESEL[i].ToString()) * 3) % 10;
                    counter++;
                    continue;
                }
                if(counter == 2)
                {
                    sum += (int.Parse(PESEL[i].ToString()) * 7) % 10;
                    counter++;
                    continue;
                }
                if(counter == 3)
                {
                    sum += (int.Parse(PESEL[i].ToString()) * 9) % 10;
                    counter = 0;
                    continue;
                }
            }
            sum = 10 - (sum % 10);
            control = sum.ToString();
            if(PESEL.Length != 11 || PESEL[0] != year[2] || PESEL[1] != year[3] || PESEL[4] != day[0] || PESEL[5] != day[1] || (plec == Plcie.K && gender % 2 != 0) || (plec == Plcie.M && gender % 2 == 0) || PESEL[10] != control[0] || (PESEL[1] == '9' && (PESEL[2] != month[0] || PESEL[3] != month[1])) || (PESEL[1] == '0' && PESEL.Substring(2, 2) != millenial))
            {
                Console.WriteLine("Bledny PESEL!");
                return;
            }
            else
            {
                Console.WriteLine("PESEL zgadza sie.");
                return;
            }
        }
    }
}
