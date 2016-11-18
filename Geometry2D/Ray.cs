using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2D
{
    public struct Ray : IGeometricElement
    {
        public readonly Vector Support;
        public readonly Vector Direction;

        public Ray(Vector support, Vector direction)
        {
            Support = support;
            Direction = direction;
        }
    }
}
