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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Main
{
    /// <summary>
    /// Логика взаимодействия для LabThreePage.xaml
    /// </summary>
    public partial class LabThreePage : Page
    {

        LossMatrix matrix;
        Minimax minimax;
              

        public LabThreePage()
        {
            InitializeComponent();

        }    
           
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double min;
            string str;
            matrix = new LossMatrix();           
            minimax = new Minimax(matrix);
            minimaxGrid.ItemsSource = minimax.FindDecision(out str,out min);
            minimaxLable.Content = "Минимаксный критерий: "+ str +": "+min;

        }
    }
}
