using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class StatisticalDecisionFunction
    {

        List<TableStatistical> list = new List<TableStatistical>();
        LossMatrix lossMatrix = new LossMatrix();
        int m = (int)Math.Pow(LossMatrix.RowCount, 2);
        double[,] generalizedMatrix;
        int [,] a;

        public StatisticalDecisionFunction()
        {            
            generalizedMatrix = new double[m, 2];
            a = new int [2, m];            
        }


        public List<TableStatistical> GetTable()
        {
            string str;
            int temp = 0;
            for (int i = 0; i < m; i++)
            {
                str = "";
                temp = i;
                    str += "S" + ++temp;

                list.Add(new TableStatistical(str, generalizedMatrix[i, 0], generalizedMatrix[i, 1]));
                
            }

            return list;
        }

        public double[,]  CreateGeneralizedMatrix(double[,] matrix)
        {
            IndexMatrix();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    generalizedMatrix[i, j] = generalizedMatrix[i, j] + (matrix[0, j] * lossMatrix.Matrix[a[0, i], j]);
                    generalizedMatrix[i, j] = generalizedMatrix[i, j] + (matrix[1, j] * lossMatrix.Matrix[a[1, i], j]);

                }
            }
            return generalizedMatrix;
        }

        private void IndexMatrix()
        {            
            for (int i = 0; i < LossMatrix.RowCount; i++)
            {
                for (int j = 0; j < LossMatrix.RowCount; j++)
                {
                    a[0, (i * LossMatrix.RowCount + j)] = i;
                    a[1, (i * LossMatrix.RowCount + j)] = j;
                }

            }
        }               

    }
}
