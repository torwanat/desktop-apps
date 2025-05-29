using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_początkowe
{
    class One
    {
        private decimal a;
        private float b, c;

        public void Aaaa()
        {
            a = decimal.Parse(Console.ReadLine());
            b = float.Parse(Console.ReadLine());
            c = decimal.ToSingle(a);

            Console.WriteLine(Math.Round(b + c,2));
            Console.WriteLine(Math.Round(b * c,2));
            Console.WriteLine(Math.Round(b - c,2));
            Console.WriteLine(Math.Round(b / c,2));
        }
    }
}
