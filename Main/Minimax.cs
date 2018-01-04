using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    //Находит минимаксный критерий 
    class Minimax
    {
        private double[,] matrix;
        List<MinimaxTable> result = new List<MinimaxTable>();
                

        public Minimax(LossMatrix matrix )
        {
            this.matrix = matrix.Matrix;                 
            
        }

        public List<MinimaxTable> FindDecision(out string alphaNum, out double res)
        {
            double[] maxValues = new double[LossMatrix.RowCount];
            
            for (int i = 0,temp; i < LossMatrix.RowCount; i++)
            {
                for (int j = 0; j < LossMatrix.ColumnCount-1; j++)
                {
                    if (matrix[i, j] > matrix[i, j + 1])
                        maxValues[i] = matrix[i, j];
                    else maxValues[i] = matrix[i, j+1];
                }
                temp = i;
                result.Add(new MinimaxTable("α" + ++temp, maxValues[i]));
            }

            double min = maxValues[0];
            int indexMin = 0;
            for (int i = 1; i < maxValues.Length; i++)
            {
                if(maxValues[i] < min)
                {
                    min = maxValues[i];
                    indexMin = i;
                }
            }
            res = maxValues.Min();
            alphaNum = "A"+(indexMin+1);
            return result;
        }

    }
}
