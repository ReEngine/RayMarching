using System;
using System.Collections.Generic;
using System.Text;

namespace RayMarching
{
    public struct Vector3D
    {
        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public Vector3D Normalize()
        {
            double length = this.Length();
            double inv_length = (1 / length);
            Vector3D vector = new Vector3D(X * inv_length, Y * inv_length, Z * inv_length);
            return vector;
        }
        public double Length()
        {
            double length = Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
            return length;
        }
        public static  double Length(Vector3D vector)
        {
            double length = Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y) + (vector.Z * vector.Z));
            return length;
        }
        public static Vector3D Subtract(Vector3D vector1, Vector3D vector2)
        {
            Vector3D result = new Vector3D(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
            return result;
        }

        public static Vector3D Add(Vector3D vector1, Vector3D vector2)
        {
            Vector3D result = new Vector3D(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
            return result;
        }
        public static Vector3D Multiply(Vector3D vector, double scalar)
        {
            Vector3D result = new Vector3D(vector.X*scalar, vector.Y * scalar, vector.Z * scalar);
            return result;
        }
    }
}
