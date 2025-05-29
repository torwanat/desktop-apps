using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    class CzlonekZespolu : Osoba, ICloneable, IComparable
    {
        private DateTime dataZapisu;
        private string funkcja;

        public string Funkcja
        {
            get { return funkcja; }
            set { funkcja = value; }
        }
        public DateTime DataZapisu
        {
            get { return dataZapisu; }
            set { dataZapisu = value; }
        }
        public CzlonekZespolu(string Imie, string Nazwisko, string data_urodzenia, string Pesel, Plcie Plec, string data_zapisu, string Funkcja) : base(Imie, Nazwisko, data_urodzenia, Pesel, Plec)
        {
            DateTime.TryParseExact(data_zapisu, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out dataZapisu);
            funkcja = Funkcja;
        }
        public CzlonekZespolu(string Imie, string Nazwisko, string data_urodzenia, string Pesel, Plcie Plec, string Telefon, string data_zapisu, string Funkcja) : base(Imie, Nazwisko, data_urodzenia, Pesel, Plec, Telefon)
        {
            DateTime.TryParseExact(data_zapisu, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy" }, null, System.Globalization.DateTimeStyles.None, out dataZapisu);
            funkcja = Funkcja;
        }
        public new string ToString()
        {
            return base.ToString() + " " + dataZapisu.ToString() + " " + funkcja;
        }
        public object Clone()
        {
            CzlonekZespolu temp = new CzlonekZespolu(Imie, Nazwisko, Dataurodzenia.ToString(), Pesel, Plec, DataZapisu.ToString(), Funkcja);
            return temp;
        }
        public object CompareTo()
        {

        }
    }
}
