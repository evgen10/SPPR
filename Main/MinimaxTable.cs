using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class MinimaxTable
    {
        public string Alpha { get; }
        public double Beta { get; }

        public MinimaxTable(string alpha, double beta)
        {
            Alpha = alpha;
            Beta = beta;
        }

    }
}
