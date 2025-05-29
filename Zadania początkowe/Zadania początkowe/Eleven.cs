using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_początkowe
{
    class Eleven
    {
        private int n;
        private int k;
        private int t;

        public int ton(int n, int k)
        {
            if(n == k || k == 0)
            {
                return 1;
            }

            if(n < k )
            {
                t = n;
                n = k;
                k = t;
            }

            return ton(n - 1, k - 1) + ton(n - 1, k);
        }
    }
}
