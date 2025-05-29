using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    class Zespol : ICloneable
    {
        private int liczbaCzlonkow;
        string nazwa;
        KierownikZespolu kierownik;
        List<CzlonekZespolu> czlonkowie;

        public Zespol()
        {
            liczbaCzlonkow = 0;
            nazwa = null;
            kierownik = null;
            czlonkowie = new List<CzlonekZespolu>();
        }
        public Zespol(string Nazwa, KierownikZespolu Kierownik) : this()
        {
            nazwa = Nazwa;
            kierownik = Kierownik;
        }
        public int LiczbaCzlonkow
        {
            get { return LiczbaCzlonkow; }
            set { liczbaCzlonkow = value; }
        }
        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }
        public KierownikZespolu Kierownik
        {
            get { return kierownik; }
            set { kierownik = value; }
        }
        public void DodajCzlonka(CzlonekZespolu c)
        {
            czlonkowie.Add(c);
            liczbaCzlonkow++;
        }
        public new string ToString()
        {
            StringBuilder sb = new StringBuilder();
            czlonkowie.ForEach(czlonek => sb.Append(czlonek.ToString() + "\n"));
            return nazwa + "\nKierownik: " + kierownik + "\nCzlonkowie: \n" + sb;
        }
        public bool jestCzlonkiem(string Pesel)
        {
            foreach(CzlonekZespolu czlonek in czlonkowie)
            {
                if(czlonek.Pesel == Pesel)
                {
                    return true;
                }
            }
            return false;
        }
        public bool jestCzlonkiem(string Imie, string Nazwisko)
        {
            foreach(CzlonekZespolu czlonek in czlonkowie)
            {
                if(czlonek.Imie == Imie && czlonek.Nazwisko == Nazwisko)
                {
                    return true;
                }
            }
            return false;
        }
        public void usunCzlonka(string Pesel)
        {
            liczbaCzlonkow -= czlonkowie.RemoveAll(czlonek => czlonek.Pesel == Pesel);
        }
        public void usunCzlonka(string Imie, string Nazwisko)
        {
            liczbaCzlonkow -= czlonkowie.RemoveAll(czlonek => (czlonek.Imie == Imie && czlonek.Nazwisko == Nazwisko));
        }
        public void usunWszystkich()
        {
            czlonkowie.Clear();
            liczbaCzlonkow = 0;
        }
        public List<CzlonekZespolu> wyszukajCzlonkow(string funkcja)
        {
            return czlonkowie.FindAll(czlonek => czlonek.Funkcja == funkcja);
        }
        public List<CzlonekZespolu> wyszukajCzlonkow(int miesiac)
        {
            return czlonkowie.FindAll(czlonek => czlonek.DataZapisu.Month == miesiac);
        }
        public object Clone()
        {
            Zespol temp = new Zespol(Nazwa, Kierownik);
            foreach(CzlonekZespolu czlonek in czlonkowie)
            {
                temp.DodajCzlonka(czlonek);
            }
            return temp;
        }
    }
}
