using System;
using System.Collections.Generic;
using System.Collections;
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
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace Main
{
    /// <summary>
    /// Логика взаимодействия для LabOne.xaml
    /// </summary>
    public partial class LabOne : Window
    {
        OpenGL g1;//Opengl контрол
        MethodSteepestDescent methodSteepestDescent = new MethodSteepestDescent();
        ArrayList points;//
        Alphabet alphabet = new Alphabet();
        
        double size;
        
        

        public LabOne()
        {
            InitializeComponent();
            g1 = OpenGLControl.OpenGL;
            alphabet.CreateAlphabet();



        }

        double scale = 30;
        double a, b, c, d, x1, x2;
        string str = "";
        
        private void DrawXY(ArrayList points)
        {
            g1.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            g1.MatrixMode(OpenGL.GL_PROJECTION);
            g1.LoadIdentity();
            g1.Ortho2D(-1 * scale, scale, -1 * scale, scale);

           
            g1.Color(0, 0, 0, 0);


            g1.Begin(OpenGL.GL_LINES);

            g1.Vertex(0, scale);
            g1.Vertex(0, -1 * scale);

            g1.End();

            g1.Begin(OpenGL.GL_LINES);

            g1.Vertex(scale, 0);
            g1.Vertex(-1 * scale, 0);

            g1.End();


            for (double i = scale * -1; i <= scale; i++)
            {
                g1.PointSize(3);
                g1.Color(1.0, 0.0, 0.0);
                g1.Begin(OpenGL.GL_POINTS);


                g1.Vertex(i, 0);

                g1.End();

                g1.Begin(OpenGL.GL_POINTS);

                g1.Vertex(0, i);

                g1.End();



            }


            

            double x = 0;
            double y = 0;
            double[] tempPoint;
           
            

            //Элипс
            g1.Begin(OpenGL.GL_LINE_LOOP);
            g1.Color(0.0, 0.0, 0.0);
            

            for (int k = 0; k < points.Count; k++)
            {
                tempPoint = (double[])points[k];
                size = a * (Math.Pow((tempPoint[0] - b), 2)) + c * (Math.Pow((tempPoint[1] + d), 2));
                

                for (int j = 0; j < 2; j++)
                {

                    int aa = 1;

                    for (double i = -scale; i <= scale; i += 0.001)
                    {
                        if (j == 1)
                            aa = -1;
                        x = i;
                        y = (size - a * (x-b) * (x-b)) / c;

                        g1.Vertex(x, aa* Math.Sqrt(y)-d);

                    }
                }
                

           

            }
            g1.End();
            


        }

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            
        }

        private void OpenGLControl_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            var gl = args.OpenGL;
            gl.ClearColor(1, 1, 1, 1);

            //gl.Ortho2D(-10, 10, -10, 10);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            a = alphabet.GetNumber(tbSName.Text[0]);
            b = alphabet.GetNumber(tbSName.Text[1]);
            c = alphabet.GetNumber(tbName.Text[0]);
            d = alphabet.GetNumber(tbName.Text[1]);


            g1.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            g1.MatrixMode(OpenGL.GL_PROJECTION);
            g1.LoadIdentity();
            g1.Ortho2D(-1 * scale, scale, -1 * scale, scale);


            g1.Color(0, 0, 0, 0);


            g1.Begin(OpenGL.GL_LINES);

            g1.Vertex(0, scale);
            g1.Vertex(0, -1 * scale);

            g1.End();

            g1.Begin(OpenGL.GL_LINES);

            g1.Vertex(scale, 0);
            g1.Vertex(-1 * scale, 0);

            g1.End();

         
            for (double i = scale * -1; i <= scale; i++)
            {
                g1.PointSize(3);
                g1.Color(1.0, 0.0, 0.0);
                g1.Begin(OpenGL.GL_POINTS);


                g1.Vertex(i, 0);

                g1.End();

                g1.Begin(OpenGL.GL_POINTS);

                g1.Vertex(0, i);

                g1.End();



            }


            //линия уровня
            g1.Begin(OpenGL.GL_LINE_LOOP);
            g1.Color(0.0, 0.0, 0.0);
            double x, y;
            
                
                for (int j = 0; j < 2; j++)
                {
                    int aa = 1;

                    for (double i = -scale; i <= scale; i += 0.001)
                    {
                        if (j == 1)
                            aa = -1;
                        x = i;
                        y = (a*c - a * (x - b) * (x - b)) / c;
                        
                       



                        g1.Vertex(x, aa * Math.Sqrt(y) - d);

                    }
                }




            
            g1.End();


            double lineX;
            double lineY;
            g1.Begin(OpenGL.GL_LINE_LOOP);

            //биссектриса первого координатного угла
            for (lineX = b; lineX < scale;  lineX+=0.001)
            {
                lineY = lineX - b - d;
                

                g1.Vertex(lineX, lineY);

            }

            g1.End();
                


        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                str = "";
                //массив для хранения точек для построениея
                points = new ArrayList();
                //ввод искходных даннх
                a = alphabet.GetNumber(tbSName.Text[0]);
                b = alphabet.GetNumber(tbSName.Text[1]);
                c = alphabet.GetNumber(tbName.Text[0]);
                d = alphabet.GetNumber(tbName.Text[1]);
                x1 = Double.Parse(tbX1.Text);
                x2 = Double.Parse(tbX2.Text);               
                                

                double[] input = { a, -1*b, c, d };
                double[] point = { x1, x2 };

                double[] grad = methodSteepestDescent.Grad(point, input);


                int i = 0;
               // цикл выполняющий поиск
                while (!(methodSteepestDescent.Stop(grad)))
                {
                    
                    points.Add(point);
                    grad = methodSteepestDescent.Grad(point, input);
                    double lambda = methodSteepestDescent.Step(grad, point, input);
                   
                    str = str + "X" + i + "(" + Math.Round(point[0], 6) + "; " + Math.Round(point[1], 6) + ")  " + "grad(X" + i + ") = " + "(" + Math.Round(grad[0], 6) + "; " + Math.Round(grad[1], 6) + ")  " + "lambda = " + lambda + "\n";
                                        
                    point = methodSteepestDescent.NextPoint(point, grad, lambda);

                    i++;
                }

                tb.Text = str;

                //рисование графика
                DrawXY(points);

                point = (double[])points[points.Count-1];
                
                funcLabel.Content = "F(X) = "+a+"(X1-"+b+")^2+"+c+"(X2+"+d+")^2";
                XminLabel.Content = "Xmin( " + Math.Round(point[0], 6) + "; " + Math.Round(point[1], 6) + " )";

            }
            catch
            {
                MessageBox.Show("Данные введены неверно!");
            }
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {

          
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            
        }
    }
}