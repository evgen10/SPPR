using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRad
{
    class MethodSteepestDescent
    {

        double _lambda;
        double epsl = 0.001;
           


        public bool Stop(double[] grad)
        {
            return (Math.Sqrt(grad[0]*grad[0]+grad[1]*grad[1]))<epsl;
        }

        public double[] Grad(double[] point, int[] data)
        {
            double[] grad = new double[2];

            grad[0] = data[0] * 2 * (point[0] + data[1]);
            grad[1] = data[2] * 2 * (point[1] + data[3]);

            return grad;
        }

        public double[] NextPoint(double[] point, double[] grad, double lambda)
        {
            double[] newPoint = new double[2];
            newPoint[0] = point[0] - grad[0]*_lambda;
            newPoint[1] = point[1] - grad[1]*_lambda;

            return newPoint;
        }

        public double Step(double[] grad,double[] point, int[] data)
        {
            double a = 2 * data[0] * -1 * grad[0];
            double b = 2 * data[3] * -1 * grad[1];



            double lambda = (-1 * (a * (point[0] + data[1]) + b * (point[1] + data[3]))) / (-1 * a * grad[0] + -1 * b * grad[1]);

            _lambda = lambda;
            return lambda;
        }

       



    }
}
