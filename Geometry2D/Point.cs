using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2D
{
    public struct Point : IGeometricElement
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets the manhattan distance to the 0-Point
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public double MhDist => Math.Abs(X) + Math.Abs(Y);
    }
}
