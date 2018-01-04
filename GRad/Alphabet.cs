using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRad
{
    class Alphabet
    {
        private Dictionary<char, int> alphabet = new Dictionary<char, int>();
                
        public void CreateAlphabet()
        {
            int a = 1;

            for (char i = 'А'; i <= 'Я'; i++, a++)
            {
                alphabet.Add(i, a);
            }
        }

        public int GetNumber(char symbol)
        {

            return alphabet[symbol];
        }

    }
}
