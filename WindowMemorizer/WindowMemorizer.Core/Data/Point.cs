using System.Diagnostics.CodeAnalysis;

namespace WindowMemorizer.Core
{
    public readonly struct Point : IEquatable<Point>
    {

        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Point point)
            {
                return Equals(point);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
