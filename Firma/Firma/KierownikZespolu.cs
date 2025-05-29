using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    class KierownikZespolu : Osoba, ICloneable
    {
        private int doswiadczenie;

        public int Doswiadczenie
        {
            get { return doswiadczenie; }
            set { doswiadczenie = value; }
        }
        public KierownikZespolu(string Imie, string Nazwisko, string data_urodzenia, string Pesel, Plcie Plec, int Doswiadczenie) : base(Imie, Nazwisko, data_urodzenia, Pesel, Plec)
        {
            doswiadczenie = Doswiadczenie;
        }
        public KierownikZespolu(string Imie, string Nazwisko, string data_urodzenia, string Pesel, Plcie Plec, string Telefon, int Doswiadczenie) : base(Imie, Nazwisko, data_urodzenia, Pesel, Plec, Telefon)
        {
            doswiadczenie = Doswiadczenie;
        }
        public new string ToString()
        {
            return base.ToString() + " " + doswiadczenie.ToString();
        }
        public object Clone()
        {
            KierownikZespolu temp = new KierownikZespolu(Imie, Nazwisko, Dataurodzenia.ToString(), Pesel, Plec, Doswiadczenie);
            return temp;
        }
    }
}
