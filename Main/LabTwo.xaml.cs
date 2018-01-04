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
using SharpGL.WPF;
using SharpGL;

namespace Main
{
    /// <summary>
    /// Логика взаимодействия для LabTwo.xaml
    /// </summary>
    public partial class LabTwo : Window
    {
        OpenGL gL;
        Simplex simplex;
        Alphabet alphabet = new Alphabet();
        int scale = 10;
        double[] data = new double[11];
        int max = 15;     
                        

        public LabTwo()
        {
            InitializeComponent();
           
            gL = OpenGLControl.OpenGL;
            alphabet.CreateAlphabet();



        }

    

        private void DrawFun()
        {
            double x, y;
            gL.PointSize(3);
            gL.Begin(OpenGL.GL_LINE_LOOP);
            gL.Color(0.0, 1.0, 0.0);
            
            for (int i = -scale; i < scale; i++)
            {
                for (int j = -scale; j < scale; j++)
                {
                    x = i;
                    y = (data[2] - data[0] * x) / data[1];
                    gL.Vertex(x, y);
                }
            }
            gL.End();

            gL.Begin(OpenGL.GL_LINE_LOOP);
            gL.Color(1.0, 0.0, 0.0);
            for (int i = -scale; i < scale; i++)
            {
                for (int j = -scale; j < scale; j++)
                {
                    x = i;
                    y = (data[5] - data[3] * x) / data[4];
                    gL.Vertex(x, y);
                }
            }
            gL.End();

            gL.Begin(OpenGL.GL_LINE_LOOP);
            gL.Color(0.0, 0.0, 1.0);
            for (int i = -scale; i < scale; i++)
            {
                for (int j = -scale; j < scale; j++)
                {
                    x = i;
                    y = (data[8] - data[6] * x) / data[7];
                    gL.Vertex(x, y);
                }
            }
            gL.End();
        }

        private string CreateSystem()
        {
            string str = "";
            str+=data[0]+"X1 + "+data[1]+"X2 <=" +data[2]+"\n";
            str += data[3] + "X1 + " + data[4] + "X2 <=" + data[5] + "\n";
            str += data[6] + "X1 + " + data[7] + "X2 <=" + data[8] + "\n";
            str += data[9] + "X1 + " + data[10] + "X2 -->MAX"+"\n";
            return str;

        }

        private void DrawLine(double max)
        {

            double x, y;
            gL.PointSize(3);
            gL.Begin(OpenGL.GL_LINE_LOOP);
            gL.Color(0.0, 0.0, 0.0);

            for (int i = -scale; i < scale; i++)
            {
                for (int j = -scale; j < scale; j++)
                {
                    x = i;
                    y = (max - data[9] * x) / data[10];
                    gL.Vertex(x, y);
                }
            }
            gL.End();
        }

        private void ChangeData()
        {            
            data[9] = int.Parse(tbC1.Text);
            data[10] = int.Parse(tbC2.Text);
            data[8] = int.Parse(tbB3.Text );
            data[5] = int.Parse(tbB2.Text);
            data[2] = int.Parse(tbB1.Text);
            data[0] = int.Parse(tbA11.Text);
            data[1] = int.Parse(tbA12.Text);
            data[3] = int.Parse(tbA21.Text);
            data[4] = int.Parse(tbA22.Text);
            data[6] = int.Parse(tbA31.Text);
            data[7] = int.Parse(tbA32.Text);
        }

        private void DrawXY()     
        {
            gL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gL.MatrixMode(OpenGL.GL_PROJECTION);
            gL.LoadIdentity();

            gL.Ortho2D(-0.3, scale, -0.5, scale);
            //gL.Ortho2D( -1*scale, scale, -1 * scale, scale);

            gL.Color(0, 0, 0, 0);

            gL.Begin(OpenGL.GL_LINES);

            gL.Vertex(0, scale);
            gL.Vertex(0, -1 * scale);

            gL.End();

            gL.Begin(OpenGL.GL_LINES);

            gL.Vertex(scale, 0);
            gL.Vertex(-1 * scale, 0);

            gL.End();

            for (double i = 0; i <= scale; i++)
            {
                gL.PointSize(3);
                gL.Color(1.0, 0.0, 0.0);
                gL.Begin(OpenGL.GL_POINTS);


                gL.Vertex(i, 0);

                gL.End();

                gL.Begin(OpenGL.GL_POINTS);

                gL.Vertex(0, i);

                gL.End();

            }
        }

        private void GetData()
        {
            string str = tbSName.Text + tbName.Text;
           

            data[9] = int.Parse(tbC1.Text = alphabet.GetNumber(str[0]).ToString());
            data[10] = int.Parse(tbC2.Text = alphabet.GetNumber(str[1]).ToString());
            data[8] = int.Parse(tbB3.Text = (10 * alphabet.GetNumber(str[4])).ToString());
            data[5] = int.Parse(tbB2.Text = (10 * alphabet.GetNumber(str[3])).ToString());
            data[2] = int.Parse(tbB1.Text = (10 * alphabet.GetNumber(str[2])).ToString());
            data[0] = int.Parse(tbA11.Text = alphabet.GetNumber(str[5]).ToString());
            data[1] = int.Parse(tbA12.Text = alphabet.GetNumber(str[6]).ToString());
            data[3] = int.Parse(tbA21.Text = alphabet.GetNumber(str[7]).ToString());
            data[4] = int.Parse(tbA22.Text = alphabet.GetNumber(str[8]).ToString());
            data[6] = int.Parse(tbA31.Text = alphabet.GetNumber(str[9]).ToString());
            data[7] = int.Parse(tbA32.Text = alphabet.GetNumber(str[10]).ToString());

            simplex = new Simplex(data);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = "";
                ChangeData();
                simplex = new Simplex(data);
                while (simplex.Stop())
                {
                    simplex.GetNewTable();
                }



                str += data[0] + "X1 + " + data[1] + "X2" + " + X3 = " + data[2] + "\n";
                str += data[3] + "X1 + " + data[4] + "X2" + " + X4 = " + data[5] + "\n";
                str += data[6] + "X1 + " + data[7] + "X2" + " + X5 = " + data[8] + "\n";

                lbSimplex.Content = str;
                gridTable.ItemsSource = simplex.Table;

                double[] result = simplex.GetValues();

                lbX1.Content = "X1: " + result[0];
                lbX2.Content = "X2: " + result[1];
                lbFx.Content = "План выпуска: " + result[2];
            }
            catch
            {
                MessageBox.Show("Считайте данные");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                max = 15;
                ChangeData();
                lbFunc.Content = CreateSystem();
                DrawXY();
                DrawFun();
                DrawLine(max);
            }
            catch
            {
                MessageBox.Show("Считайте данные");
            }
        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            var gl = args.OpenGL;
            gl.ClearColor(1, 1, 1, 1);
            
        }

        private void OpenGLControl_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

        }

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

        }

        private void OpenGLControl_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            max++;
            DrawXY();
            DrawFun();
            DrawLine(max);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            max--;
            DrawXY();
            DrawFun();
            DrawLine(max);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            GetData();
            lbFunc.Content = CreateSystem();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            scale--;
            DrawXY();
            DrawFun();
            DrawLine(max);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            scale++;
            DrawXY();
            DrawFun();
            DrawLine(max);
        }
    }
}
