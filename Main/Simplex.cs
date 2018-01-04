using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Simplex
    {
        private int column = 6;
        private int row = 4;
        private double resolvingElement;
        int indexR = 0;
        int indexC = 0;
        int[] basis = { 3, 4, 5 };
        double[,] simplexTable;

        List<MyTable> result = new List<MyTable>();

        public List<MyTable> Table
        {
            get { return result; }
        }

        //возврашает результат вычислений
        public double[] GetValues()
        {
            double[] data = new double[3];
            for (int i = result.Count-4; i < result.Count; i++)
            {
                if (result[i].Basis[1] == '1')
                    data[0] = result[i].P;
                if (result[i].Basis[1] == '2')
                    data[1] = result[i].P;
                if (result[i].Basis[0] == 'F')
                    data[2] = result[i].P;
            }

            return data;
        }
        
        //конструктор забивате исходную матрицу
        public Simplex(double[] data)
        {
            double[,] tempTable = 
                {

            { data[0],data[1],1,0,0,data[2]},
            { data[3],data[4],0,1,0,data[5] },
            { data[6],data[7],0,0,1,data[8] },
            { -1*data[9],-1*data[10],0,0,0,0}

                 };
            simplexTable = tempTable;
            ParseToTable();
        }

     
        //измният значени базица                
        private void ChangeBasis()
        {
            basis[indexR] = indexC+1;
        }

        //переводит получене данные в таблицу
        private void ParseToTable()
        {
            double[] data = new double[6];
            string tempBasis="";
            for (int i = 0; i < row; i++)
            {                
                for (int j = 0; j < column; j++)
                {
                    data[j] = simplexTable[i, j];                   
                    
                }

                if (i != row - 1)
                    tempBasis = "X" + basis[i];
                else tempBasis = "F(X)";

                result.Add(new MyTable(tempBasis,data));
            }           
        }
        
        //создает симплек таблицу
        public void GetNewTable()
        {
            double[,] tempSimplexTable = (double[,])simplexTable.Clone();
            FindResolvingElement();

            //изменяем разрещающий столбец
            for (int i = 0; i < row; i++)
            {
                if(i!=indexR)
                {
                    simplexTable[i, indexC] = 0;
                }
            }

            //изменяем разрещающаю строку
            for (int i = 0; i < column; i++)
            {
                simplexTable[indexR, i] = tempSimplexTable[indexR, i] / resolvingElement;
            }

            //изменяем остальные элементы
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if(i!=indexC&&j!=indexR)
                    {
                        simplexTable[j, i] = tempSimplexTable[j, i] - (tempSimplexTable[j, indexC] * tempSimplexTable[indexR, i] / tempSimplexTable[indexR, indexC]);
                    }
                    
                }
            }

            ChangeBasis();
            ParseToTable();         

        }

        //критерий остановки
        public bool Stop()
        {
           
            for (int i = 0; i < column; i++)
            {
                if (simplexTable[row - 1, i] < 0)
                    return true;
            }

            return false;

        }        

        //найти разр элемент
        void FindResolvingElement()
        {
            double min = 1000000;
            
            for (int i = 0; i < column; i++)
            {
                if (simplexTable[row - 1, i] < min)
                {
                    min = simplexTable[row - 1, i];
                    indexC = i;
                }
            }

            double minElm ;
            min = 100000;
            for (int i = 0; i < row-1; i++)
            {
                minElm = simplexTable[i, column-1]/ simplexTable[i, indexC];
                if (minElm<min)
                {
                    min = minElm;
                    indexR = i;
                }

            }
            resolvingElement = simplexTable[indexR, indexC];

        }

    }
}
