using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class HurwiczTable
    {
        public string H { get;  private set; }
        public double Values {get; private set;}


        public HurwiczTable(string h, double values)
        {
            H = h;
            Values = values;
        }

        
    }
}
