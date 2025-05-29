using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_początkowe
{
    class Seven
    {
        private string word;
        private string output;
        private int counter;

        public void win()
        {
            word = Console.ReadLine();
            for(int i = 0; i < word.Length; i++)
            {
                if(i + 1 == word.Length)
                {
                    if(word[i] == word[i - 1])
                    {
                        counter++;
                        output = output + counter + word[i];
                        counter = 0;
                        break;
                    }
                    else
                    {
                        output = output + "1" + word[i];
                        break;
                    }
                }
                if(word[i] == word[i + 1])
                {
                    counter++;
                }
                else
                {
                    counter++;
                    output = output + counter + word[i];
                    counter = 0;
                }
            }
            Console.WriteLine(output);
        }
    }
}
