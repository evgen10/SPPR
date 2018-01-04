using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRad
{
    class Program
    {
        static void Main(string[] args)
        {
            //Alphabet alphabet = new Alphabet();
            //int c;
            //alphabet.CreateAlphabet();

            //c = alphabet.GetNumber('E');

            //Console.WriteLine(c);


            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            int a = 1;
            for (char i = 'А'; i < 'Я'; a++,i++)
            {
                dictionary.Add(i, a);
                
            }



            for (char i = 'А'; i < 'Я'; a++, i++)
            {
                Console.WriteLine(i+" "+dictionary[i]);

            }



        }
    }
}
