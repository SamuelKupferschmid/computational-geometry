using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2D
{
    public struct Vector: IGeometricElement
    {
        public readonly double X;
        public readonly double Y;

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector Null = new Vector(0,0);

        public double Length => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y,2));

        /// <summary>
        /// Gets the manhattan distance relative to the 0-Point
        /// </summary>
        /// <returns></returns>
        public double MhnDist => Math.Abs(X) + Math.Abs(Y);

        public bool IsMultiple(Vector v) => v == this || (X/v.X) - (Y/v.Y) < double.Epsilon;

        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);

        public static Vector operator *(Vector v, double factor) => new Vector(v.X * factor, v.Y * factor);
        public static Vector operator /(Vector v, double factor) => new Vector(v.X / factor, v.Y / factor);

        public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.X - v2.X, v1.Y - v2.Y);

        public static bool operator ==(Vector v1, Vector v2) => v1.X - v2.X < double.Epsilon && v1.Y - v2.Y < double.Epsilon;
        public static bool operator !=(Vector v1, Vector v2) => v1.X - v2.X > double.Epsilon || v1.Y - v2.Y > double.Epsilon;


        public bool Equals(Vector other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector && Equals((Vector)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }
    }
}
