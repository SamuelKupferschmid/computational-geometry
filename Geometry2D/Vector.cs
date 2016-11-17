using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2D
{
    public struct Vector: IGeometricElement
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y,2));
    }
}
