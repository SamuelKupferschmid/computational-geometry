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
    }
}
