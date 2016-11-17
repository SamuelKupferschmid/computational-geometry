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

        public static Vector Null = new Vector(0,0);

        public double Length => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y,2));

        /// <summary>
        /// Gets the manhattan distance to the 0-Point
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double MhDist => Math.Abs(X) + Math.Abs(Y);

        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);

        public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.X - v2.X, v1.Y - v2.Y);
    }
}
