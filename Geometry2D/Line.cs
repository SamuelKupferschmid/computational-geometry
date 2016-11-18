using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2D
{
    public struct Line : IGeometricElement
    {
        public readonly Vector Support;
        public readonly Vector Direction;

        public Line(Vector support, Vector direction)
        {
            Support = support;
            Direction = direction;
        }

        public bool IsParallel(Line line) => Direction.IsMultiple(line.Direction);

        public bool Intersects(Line l, out Vector v)
        {
            v = default(Vector);

            if (IsParallel(l))
                return false;

            var x1 = Direction.X - Support.X;
            var y1 = Direction.Y - Support.Y;

            var x2 = l.Direction.X - l.Support.X;
            var y2 = l.Direction.Y - l.Support.Y;

            var x = ((l.Support.Y - Support.Y)*x1*x2 + y1*x2*Support.X - y2*x1*l.Support.X)/(y1*x2 - y2*x1);
            var y = Support.Y + (y1/x1)*(x - Support.X);
            v = new Vector(x,y);
            return true;
        }

        public bool IsOnLine(Vector v)
        {
            var relV = v - Support;
            var mx = relV.X/Direction.X;
            var my = relV.Y/Direction.Y;

            return mx - my < double.Epsilon;
        }

        public static bool operator ==(Line l1, Line l2)
        {
            if (!l1.Direction.IsMultiple(l2.Direction))
                return false;

            var mx = (l2.Direction.X - l1.Support.X)/l1.Direction.X;
            var my = (l2.Direction.Y - l1.Support.Y)/l1.Direction.Y;

            return mx - my < double.Epsilon;
        }

        public static bool operator !=(Line l1, Line l2) => !(l1 == l2);
    }
}
