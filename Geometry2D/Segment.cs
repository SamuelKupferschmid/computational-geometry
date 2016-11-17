using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2D
{
    public struct Segment : IGeometricElement
    {
        public double X1 { get; private set; }
        public double Y1 { get; private set; }
        public double X2 { get; private set; }
        public double Y2 { get; private set; }

        public Segment(Point start, Point end)
        {
            X1 = start.X;
            Y1 = start.Y;
            X2 = end.X;
            Y2 = end.Y;
        }
    }
}
