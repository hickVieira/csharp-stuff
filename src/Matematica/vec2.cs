namespace Matematica;

public struct vec2
{
    public float x, y;

    #region constructors
    public vec2(float x, float y) => (this.x, this.y) = (x, y);
    #endregion

    #region accessors
    public float r => x;
    public float g => y;

    public vec2 xy => this;
    public vec2 yx => new(y, x);

    public vec2 rg => new(x, y);
    public vec2 gr => new(y, x);
    #endregion

    #region operators
    public static vec2 operator +(vec2 a, vec2 b) => new(a.x + b.x, a.y + b.y);
    public static vec2 operator -(vec2 a, vec2 b) => new(a.x - b.x, a.y - b.y);
    public static vec2 operator -(vec2 a) => new(-a.x, -a.y);

    public static vec2 operator *(vec2 a, float b) => new(a.x * b, a.y * b);
    public static vec2 operator *(float b, vec2 a) => new(a.x * b, a.y * b);
    public static vec2 operator /(vec2 a, float b) => new(a.x / b, a.y / b);

    public static vec2 operator *(vec2 a, vec2 b) => new(a.x * b.x, a.y * b.y);
    public static vec2 operator /(vec2 a, vec2 b) => new(a.x / b.x, a.y / b.y);

    public static bool operator ==(vec2 a, vec2 b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(vec2 a, vec2 b) => a.x != b.x || a.y != b.y;

    public static implicit operator vec2(float v) => new(v, v);
    #endregion

    #region methods
    public override readonly bool Equals(object obj) => obj is vec2 other && this == other;
    public override readonly int GetHashCode() => x.GetHashCode() ^ y.GetHashCode();
    public override readonly string ToString() => $"({x},{y})";
    #endregion
}