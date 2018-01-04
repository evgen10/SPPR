using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class HurwiczCriterion
    {
        private double[,] matrix;
        List<HurwiczTable> result = new List<HurwiczTable>();

        public HurwiczCriterion(LossMatrix matrix)
        {
            this.matrix = matrix.Matrix;
        }
        

        private double FindMaxElements(double a,  double b, ref double min)
        {
            double max;
            if (a < b)
            {
                max = b;
                min = a;
            }
            else
            {
                max = a;
                min = b;
            }

            return max;
        }

        public List<HurwiczTable> FindDecision(double indexOfOptimism, out string HNum,out double value)
        {
            double[] temp = new double[LossMatrix.RowCount];
            double min = 0;
            double max = 0;
            
            int tempCount = 0;
            for (int i = 0; i < LossMatrix.RowCount; i++)
            {
                string str = "H";
                max = FindMaxElements(matrix[i, 0], matrix[i, 1], ref min);
                temp[i] = indexOfOptimism * min + (1 - indexOfOptimism) * max;
                tempCount = i + 1;
                result.Add(new HurwiczTable(str + tempCount, temp[i]));
            }

            double minn = temp[0];
            int indexMin = 0;
            for (int i = 1; i < temp.Length; i++)
            {
                if (temp[i] < minn)
                {
                    min = temp[i];
                    indexMin = i;
                }
            }
            value= temp.Min();
            HNum = "По критерию Гурвица с показателем оптимизма λ = "+indexOfOptimism+"\n оптимально решение α" + (indexMin + 1)+"=";        


            return result;
        }


    }
}
