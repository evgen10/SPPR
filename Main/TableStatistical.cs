using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class TableStatistical
    {
        public string Sigma { get; }
        public double Beta1 { get; }
        public double Beta2 { get; }

        public TableStatistical(string sigma, double b1, double b2)
        {
            Sigma = sigma;
            Beta1 = b1;
            Beta2 = b2;
        }

    }
}
