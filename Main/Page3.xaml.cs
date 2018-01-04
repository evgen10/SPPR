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
using SharpGL.WPF;
using SharpGL;

namespace Main
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {

        OpenGL g1;
        int scale = 1;
        LossMatrix matrix = new LossMatrix();


        public Page3()
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

            for (double i = 0; i <= scale; i+=0.1)
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


        private void Button_Click_Draw(object sender, RoutedEventArgs e)
        {
            try
            {
                DrawXY();
                g1.Begin(OpenGL.GL_LINE_LOOP);

                g1.Vertex(matrix.Matrix[0, 0], matrix.Matrix[0, 1]);
                g1.Vertex(matrix.Matrix[4, 0], matrix.Matrix[4, 1]);
                g1.Vertex(matrix.Matrix[3, 0], matrix.Matrix[3, 1]);
                g1.Vertex(matrix.Matrix[2, 0], matrix.Matrix[2, 1]);
                g1.Vertex(matrix.Matrix[5, 0], matrix.Matrix[5, 1]);
                g1.Vertex(matrix.Matrix[0, 0], matrix.Matrix[0, 1]);

                g1.End();


                //g1.Begin(OpenGL.GL_POLYGON);
                //for (int i = 0; i < LossMatrix.RowCount; i++)
                //{
                //    g1.Vertex(matrix.Matrix[i, 0], matrix.Matrix[i, 1]);
                //}

                //g1.End();

                g1.Color(0.0, 0.0, 1.0);
                g1.Begin(OpenGL.GL_POINTS);
                for (int i = 0; i < LossMatrix.RowCount; i++)
                {
                    g1.Vertex(matrix.Matrix[i, 0], matrix.Matrix[i, 1]);
                }

                g1.End();
            }
            catch
            {
                MessageBox.Show("!");
            }

        }

        private void OpenGLControl_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

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
    }
}
