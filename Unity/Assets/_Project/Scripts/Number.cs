using System;
using System.Globalization;

namespace Sanomic
{
    [Serializable]
    public struct Number : IEquatable<Number> // 40 bits = 5 bytes = 6 Decimal Places Precision
    {
        private const sbyte EXPONENT_ROUNDING_CUTOFF = 10;

        public float Mantissa; // 32 bits = 4 bytes = 6 Decimal Places Precision
        public sbyte Exponent; // 8 bits = 1 byte = ±2^7 = ±127
        
        public Number(float mantissa, sbyte exponent = 0)
        {
            Mantissa = mantissa;
            
            if (mantissa == 0d)
            {
                Exponent = 0;
                return;
            }
            
            Exponent = exponent;
            ConvertToScientificNotation();
        }

        public Number Sqrt
        {
            get
            {
                var modulo = (sbyte)(Exponent % 2);
                var mantissa = (float)Math.Sqrt(Mantissa * Math.Pow(10f, modulo));
                var exponent = (sbyte)(Exponent / 2 + modulo);
                return new Number(mantissa, exponent);
            }
        }
        
        private Number ConvertToScientificNotation()
        {
            if (Mantissa == 0) return this;

            var absoluteMantissa = Math.Abs(Mantissa);
            var flip = Mantissa != absoluteMantissa;
            Mantissa = absoluteMantissa;

            while (Mantissa < 1)
            {
                Mantissa *= 10;
                Exponent--;
            }
            while (Mantissa >= 10)
            {
                Mantissa /= 10;
                Exponent++;
            }

            Mantissa = flip ? -Mantissa : Mantissa;

            return this;
        }
        
        public override string ToString()
        {
            var symbol = Exponent < 0 ? "" : "+";
            return $"{Mantissa.ToString(CultureInfo.InvariantCulture)}E{symbol}{Exponent.ToString()}";
        }
        
        public bool Equals(Number other) => Mantissa.Equals(other.Mantissa) && Exponent == other.Exponent;
        public override bool Equals(object obj) => obj is Number other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(Mantissa, Exponent);

        public static Number operator +(Number a, Number b)
        {
            if (a.Exponent == b.Exponent)
            {
                return new Number(a.Mantissa + b.Mantissa, a.Exponent);
            }

            var exponentDelta = (sbyte)Math.Abs(a.Exponent - b.Exponent);
            var aIsBigger = a.Exponent > b.Exponent;

            if (exponentDelta > EXPONENT_ROUNDING_CUTOFF) return aIsBigger ? a : b;

            var exponentDeltaMantissa = (float)Math.Pow(10f, exponentDelta);
            
            return aIsBigger 
                ? new Number(b.Mantissa + a.Mantissa * exponentDeltaMantissa, (sbyte)(a.Exponent - exponentDelta)) 
                : new Number(a.Mantissa + b.Mantissa * exponentDeltaMantissa, (sbyte)(b.Exponent - exponentDelta));
        }
        public static Number operator -(Number a, Number b) => a + -b;
        public static Number operator -(Number a) => new(-a.Mantissa, a.Exponent);
        public static Number operator *(Number a, Number b) => new(a.Mantissa * b.Mantissa, (sbyte)(a.Exponent + b.Exponent));
        public static Number operator /(Number a, Number b) => new(a.Mantissa / b.Mantissa, (sbyte)(a.Exponent - b.Exponent));

        public static implicit operator Number(float d) => new(d);
        
        public static bool operator ==(Number left, Number right) => left.Equals(right);
        public static bool operator !=(Number left, Number right) => !(left == right);
    }
}