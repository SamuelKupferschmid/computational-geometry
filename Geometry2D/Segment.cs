using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2D
{
    public struct Segment : IGeometricElement
    {
        public readonly Vector Start;
        public readonly Vector End;

        public double X1 => Start.X;
        public double Y1 => Start.Y;
        public double X2 => End.X;
        public double Y2 => End.Y;

        public double X => End.X - Start.X;
        public double Y => End.Y - Start.Y;

        public Segment(Vector start, Vector end)
        {
            Start = start;
            End = end;
        }

        public static explicit operator Line(Segment s) => new Line(s.Start,s.End - s.Start);

        public static Segment operator +(Segment s, Vector v) => new Segment(s.Start + v, s.End + v);
    }
}
