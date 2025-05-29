using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_początkowe
{
    class Two
    {
        private int a;
        private int counter = 0;
        private int sum = 0;

        public void Work()
        {
            for(int i = 0; i < 10; i++)
            {
                a = int.Parse(Console.ReadLine());
                if(a%3 == 0 || a%5 == 0)
                {
                    counter++;
                    sum += a;
                }
            }
            Console.WriteLine(sum);
            Console.WriteLine(sum / counter);
        }
    }
}
