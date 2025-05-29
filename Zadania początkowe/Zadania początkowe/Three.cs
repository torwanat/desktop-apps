using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_początkowe
{
    class Three
    {
        private int a;

        public void wink()
        {
            a = int.Parse(Console.ReadLine());
            while(a != 0)
            {
                if(a % 10 == 3)
                {
                    Console.WriteLine("Znaleziono 3");
                    break;
                }
                else
                {
                    a = a / 10;
                }
            }
            if(a == 0)
            {
                Console.WriteLine("Nie znaleziono 3");
            }
        }
    }
}
