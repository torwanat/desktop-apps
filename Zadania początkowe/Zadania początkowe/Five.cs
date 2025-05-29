using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_początkowe
{
    class Five
    {
        private string a;
        private string b;
        private int index;
        private char c;

        public void tabat()
        {
            a = Console.ReadLine();
            for(int i = 0; i < a.Length; i++)
            {
                if (!(char.IsLetter(a[i])))
                {
                    c = a[i];
                    index = i;
                    break;
                }
            }
            for(int i = index + 1; i < a.Length; i++)
            {
                b = b + a[i];
            }
            b = b + c;
            for (int i = 0; i < index; i++)
            {
                b = b + a[i];
            }
            Console.WriteLine(b);
        }
    }
}
