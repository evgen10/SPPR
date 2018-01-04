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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private LabOne labOneWin;
        private LabTwo labTwoWin;
        private LabThree labThreeWin;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFormLabOne(object sender, RoutedEventArgs e)
        {
            labOneWin = new LabOne();
            labOneWin.Show();

            
        }

        private void OpenFormLabTwo(object sender, RoutedEventArgs e)
        {
            labTwoWin = new LabTwo();
            labTwoWin.Show();

        }

        private void OpenFormLabThree(object sender, RoutedEventArgs e)
        {
            labThreeWin = new LabThree();
            labThreeWin.Show();
           
        }
    }
}
