using System;
using UnityEngine;

namespace Terra
{
    public struct Vector : IEquatable<Vector>
    {
        public Number X { get; set; }
        public Number Y { get; set; }
        public Number Z { get; set; }
        
        public Vector(Vector3 vector)
        {
            X = new Number(vector.x);
            Y = new Number(vector.y);
            Z = new Number(vector.z);
        }
        public Vector(Number x, Number y, Number z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public static Vector Zero => new(0, 0, 0);
        public static Vector One => new(1, 1, 1);

        public static Number Distance(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z).Magnitude;

        public Number SquareMagnitude => X * X + Y * Y + Z * Z;
        public Number Magnitude => SquareMagnitude.Sqrt;
        
        public Vector Normalized => this * (1 / SquareMagnitude.Sqrt);
        
        public override string ToString() => $"({X.ToString()} | {Y.ToString()} | {Z.ToString()})";

        public bool Equals(Vector other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        public override bool Equals(object obj) => obj is Vector other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public static Vector operator +(Vector a, Vector b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector operator -(Vector a, Vector b) => a + -b;
        public static Vector operator -(Vector v) => new(-v.X, -v.Y, -v.Z);
        public static Vector operator *(Vector v, Number n) => new(v.X * n, v.Y * n, v.Z * n);
        public static Vector operator *(Number n, Vector v) => v * n;
        public static Vector operator /(Vector v, Number n) => new(v.X / n, v.Y / n, v.Z / n);
        
        public static bool operator ==(Vector left, Vector right) => left.Equals(right);
        public static bool operator !=(Vector left, Vector right) => !(left == right);
    }
}