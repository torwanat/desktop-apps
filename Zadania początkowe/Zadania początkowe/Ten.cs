using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_początkowe
{
    class Ten
    {
        private int a;
        private int b;
        private int c;

        public void d()
        {
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

            if(a % b == 0)
            {
                Console.WriteLine(b);
            }
            else
            {
                while(a % b != 0)
                {
                    c = a % b;
                    a = b;
                    b = c;
                }
                Console.WriteLine(b);
            }
        }
    }
}
