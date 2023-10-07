namespace Terra
{
    public struct Number
    {
        public float Mantissa { get; set; } // 32 bits = 4 bytes
        public sbyte Exponent { get; set; } // 8 bits = 1 byte
        
        public Number(float mantissa, sbyte exponent)
        {
            Mantissa = mantissa;
            Exponent = exponent;
        }
    }
}