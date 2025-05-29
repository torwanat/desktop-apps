using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_początkowe
{
    class Four
    {
        private string a;

        public void wint()
        {
            a = Console.ReadLine();
            if(a.Contains("3")){
                Console.WriteLine("Znaleziono 3");
            }
            else
            {
                Console.WriteLine("Nie znaleziono 3");
            }
        }
    }
}
