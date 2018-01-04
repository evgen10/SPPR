using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class TableLossMatrix
    {
        public string Alpha { get; }
        public double Beta1 { get; }
        public double Beta2 { get; }

        public TableLossMatrix(string alpha, double beta1, double beta2)
        {
            Alpha = alpha;
            Beta1 = beta1;
            Beta2 = beta2;
        }
    }
}
