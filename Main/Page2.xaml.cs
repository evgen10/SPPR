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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
       
        HurwiczCriterion hurwiczCriterion;


        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value;
                string H;
                double index = double.Parse(tbIndexOfOptimism.Text);


                hurwiczCriterion = new HurwiczCriterion(new LossMatrix());
                gridResult.ItemsSource = hurwiczCriterion.FindDecision(index, out H, out value);
                hurLable.Content = H + " " + value;
            }
            catch
            {
                MessageBox.Show("Ведите критерий оптимизма");
            }


        }
    }
}
