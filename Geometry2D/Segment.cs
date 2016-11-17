using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2D
{
    public struct Segment : IGeometricElement
    {
        public double X1 => Start.X;
        public double Y1 => Start.Y;
        public double X2 => End.X;
        public double Y2 => End.Y;

        public Vector Start { get; set; }
        public Vector End { get; set; }

        public Segment(Vector start, Vector end)
        {
            Start = start;
            End = end;
        }
    }
}
