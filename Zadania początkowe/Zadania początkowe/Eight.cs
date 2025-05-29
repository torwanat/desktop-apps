using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_początkowe
{
    class Eight
    {
        private int[] tab = new int[100];
        Random random = new Random();
        private int b;

        public void le()
        {
            for(int i = 0; i < 100; i++)
            {
                tab[i] = random.Next(101);
            }
            for(int i = 0; i < 100; i++)
            {
                for(int j = 0; j < 99; j++)
                {
                    if(tab[j] > tab[j + 1])
                    {
                        b = tab[j + 1];
                        tab[j + 1] = tab[j];
                        tab[j] = b;
                    }
                }
            }
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(tab[i]);
            }
        }
    }
}
