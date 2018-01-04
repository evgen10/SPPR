using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Main
{
    /// <summary>
    /// Логика взаимодействия для LabThree.xaml
    /// </summary>
    public partial class LabThree : Window
    {
        
        List<TableLossMatrix> sourceMatrix;
        double[,] data;
        int column = 2;
        int row;
        Alphabet alphabet = new Alphabet();
        LossMatrix matrix;

        public LabThree()
        {
            InitializeComponent();
            alphabet.CreateAlphabet();
        }

        private void GetData()
        {
            sourceMatrix = new List<TableLossMatrix>();
            string str = ""; 
            str = tbSNume.Text + tbName.Text;

            if (str.Length % 2 == 0)
                row = str.Length / column;
            else
            {
                str += "И";
                row = str.Length/ column;
            }

                matrix = new LossMatrix(row,column);

            data = new double[LossMatrix.RowCount,LossMatrix.ColumnCount];
            
            int strStep = 0;
            int temp;
            for (int i = 0; i < LossMatrix.RowCount; i++)
            {              
                for (int j = 0; j < LossMatrix.ColumnCount; j++)
                {
                    if ((alphabet.GetNumber(str[strStep]).ToString().Length == 2))
                        data[i, j] = ((alphabet.GetNumber(str[strStep])) % 10);
                    else data[i, j] = alphabet.GetNumber(str[strStep]);
                    data[i, j] /= 10;
                    strStep++;
                }
                temp = i;
                sourceMatrix.Add(new TableLossMatrix("α" + ++temp, data[i, 0], data[i, 1]));
            }

            matrix.Matrix = data;
            gridSourceMatrix.ItemsSource = sourceMatrix;
        }

        private void openPageOne(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("LabThreePage.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetData();            
        }

        private void Button_Click_OpenPage2(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("Page2.xaml", UriKind.Relative));
        }

        private void Button_Click_OpenPage3(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("Page3.xaml", UriKind.Relative));
        }

        private void Button_Click_OpenPage4(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("Page4.xaml", UriKind.Relative));
        }
    }
}
