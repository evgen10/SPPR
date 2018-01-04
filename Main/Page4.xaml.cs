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
using SharpGL;

namespace Main
{
    /// <summary>
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        StatisticalDecisionFunction statisticalDecision;
        OpenGL g1;
        double scale =1 ;
        double[,] matrix;

        double f = 0.01;
        private double[,] applianceMatrix =
        {
            {0.74, 0.1 }, {0.26,0.9}
        };

        public Page4()
        {
            InitializeComponent();
            g1 = OpenGLControl.OpenGL;


        }

        
        private void DrawXY()
        {
            g1.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            g1.MatrixMode(OpenGL.GL_PROJECTION);
            g1.LoadIdentity();

            g1.Ortho2D(-0.3, scale, -0.5, scale);
            //g1.Ortho2D( -1*scale, scale, -1 * scale, scale);

            g1.Color(0, 0, 0, 0);

            g1.Begin(OpenGL.GL_LINES);

            g1.Vertex(0, scale);
            g1.Vertex(0, -1 * scale);

            g1.End();

            g1.Begin(OpenGL.GL_LINES);

            g1.Vertex(scale, 0);
            g1.Vertex(-1 * scale, 0);

            g1.End();

            for (double i = 0; i <= scale; i += 0.1)
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
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                statisticalDecision = new StatisticalDecisionFunction();
                double[,] matrix = statisticalDecision.CreateGeneralizedMatrix(applianceMatrix);
                DrawXY();

                g1.Begin(OpenGL.GL_LINE_LOOP);

                g1.Vertex(matrix[63, 0], matrix[63, 1]);
                g1.Vertex(matrix[15, 0], matrix[15, 1]);
                g1.Vertex(matrix[23, 0], matrix[23, 1]);
                g1.Vertex(matrix[17, 0], matrix[17, 1]);
                g1.Vertex(matrix[18, 0], matrix[18, 1]);
                g1.Vertex(matrix[35, 0], matrix[35, 1]);
                g1.Vertex(matrix[27, 0], matrix[27, 1]);
                g1.Vertex(matrix[59, 0], matrix[59, 1]);
                g1.Vertex(matrix[63, 0], matrix[63, 1]);


                g1.End();


                g1.Color(0.0, 0.0, 0.0);
                g1.Begin(OpenGL.GL_POINTS);
                for (int i = 0; i < matrix.Length / 2; i++)
                {
                    g1.Vertex(matrix[i, 0], matrix[i, 1]);
                }

                g1.End();

                gridTable.ItemsSource = statisticalDecision.GetTable();
            }
            catch
            {
                MessageBox.Show("!");
            }

        }

        private void OpenGLControl_Initialized(object sender, EventArgs e)
        {

        }

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            var gl = args.OpenGL;
            gl.ClearColor(1, 1, 1, 1);
        }

        private void OpenGLControl_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

        }

        private void ButtonClickMoveoOn(object sender, RoutedEventArgs e)
        {
            f += 0.01;
            g1.Color(0.0, 0.0, 0.0);
            g1.Begin(OpenGL.GL_LINE_LOOP);

            g1.Vertex(0, f);
            g1.Vertex(f, f);
            g1.Vertex(f, 0);
            g1.Vertex(0, 0);

            g1.End();
        }

      }
}
