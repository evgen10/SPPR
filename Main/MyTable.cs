using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class MyTable
    {
        public string Basis { get; }
        public double x1 { get; }
        public double x2 { get; }
        public double x3 { get; }
        public double x4 { get; }
        public double x5 { get; }
        public double P { get;  }
       
       


        public MyTable( string basis ,double[] data)
        {
            this.Basis = basis;
            this.x1 = data[0];
            this.x2 = data[1];
            this.x3 = data[2];
            this.x4 = data[3];
            this.x5 = data[4];
            this.P = data[5];
            
        }
    }
}
