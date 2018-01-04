using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    //Формирует исходнуб матрицу потерь
     public class LossMatrix
    {
        public static int RowCount { get; private set; }
        public static int ColumnCount { get; private set; }
        private static double[,] matrix;

        public static int D;


        public LossMatrix()
        {

        }

        public LossMatrix(int a, int b)
        {
            RowCount = a;
            ColumnCount = b;
        }             


        public double[,] Matrix
        {
            set { matrix = value;}
            get { return matrix; }
        }

    }
}
