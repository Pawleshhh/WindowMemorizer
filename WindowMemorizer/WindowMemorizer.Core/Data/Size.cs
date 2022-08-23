using System.Diagnostics.CodeAnalysis;

namespace WindowMemorizer.Core
{
    public readonly struct Size : IEquatable<Size>
    {

        public int Width { get; }
        public int Height { get; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool Equals(Size other)
        {
            return Width == other.Width && Height == other.Height;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Size point)
            {
                return Equals(point);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Width, Height);
        }

        public override string ToString()
        {
            return $"({Width}, {Height})";
        }
    }
}
