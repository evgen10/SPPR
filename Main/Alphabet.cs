using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Alphabet
    {
        private Dictionary<char, int> alphabet = new Dictionary<char,int>();

        public void CreateAlphabet()
        {
            int a = 1;

            for (char i = 'А'; i <= 'Я'; i++, a++)
            {

                alphabet.Add(i, a);
                if(i=='Е')
                {
                    alphabet.Add('Ё', ++a);
                }
                    

            }
         
        }

        public int GetNumber(char symbol)
        {

            return alphabet[symbol];
        }

    }
}
