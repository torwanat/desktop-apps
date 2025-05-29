using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    public enum Plcie
    {
        M,
        K
    }
    class Program
    {
        static void Main(string[] args)
        {
            KierownikZespolu k1 = new KierownikZespolu("Adam", "Kowalski", "1990-07-01", "90070142412", Plcie.M, 5);
            CzlonekZespolu cz1 = new CzlonekZespolu("Witold", "Adamski", "22-10-1992", "92102266738", Plcie.M, "01-01-2020", "sekretarz");
            CzlonekZespolu cz2 = new CzlonekZespolu("Jan", "Janowski", "15-03-1992", "92031532652 ", Plcie.M, "01-01-2020" ,"programista");
            CzlonekZespolu cz3 = new CzlonekZespolu("Jan", "But", "16-05-1992", "92051613915", Plcie.M, "01-06-2019", "programista");
            CzlonekZespolu cz4 = new CzlonekZespolu("Beata", "Nowak", "22-11-1993", "93112225023", Plcie.K, "01-01-2020", "projektant");
            CzlonekZespolu cz5 = new CzlonekZespolu("Anna", "Mysza", "22-07-1991", "91072235964", Plcie.K, "31-07-2019", "projektant");
            Zespol zespol1 = new Zespol("Grupa IT", k1);
            zespol1.DodajCzlonka(cz1);
            zespol1.DodajCzlonka(cz2);
            zespol1.DodajCzlonka(cz3);
            zespol1.DodajCzlonka(cz4);
            zespol1.DodajCzlonka(cz5);
            Console.WriteLine(zespol1.ToString());
            Zespol zespol2 = (Zespol)zespol1.Clone();
            zespol2.Kierownik = new KierownikZespolu("Rafał", "Marzec", "1990-03-01", "88032112357", Plcie.M, 6);
            zespol2.Nazwa = "Nowa Grupa";
            zespol2.ToString();
            Console.ReadKey();
        }
    }
}
