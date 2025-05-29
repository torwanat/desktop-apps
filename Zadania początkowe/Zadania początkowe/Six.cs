using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_początkowe
{
    class Six
    {
        private int a;
        private int b = 0;
        private int counter = 0;

        public void polsat()
        {
            a = int.Parse(Console.ReadLine());
            while (counter == 0)
            {
                while (a != 0)
                {
                    b += a % 10;
                    a = a / 10;
                }
                if (b / 10 == 0)
                {
                    Console.WriteLine(b);
                    counter++;
                }
                else
                {
                    a = b;
                    b = 0;
                }
            }
        }
    }
}
