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

        public Point Start => new Point(X1,Y1);
        public Point End => new Point(X2,Y2);

        public Segment(Point start, Point end)
        {
            X1 = start.X;
            Y1 = start.Y;
            X2 = end.X;
            Y2 = end.Y;
        }
    }
}
