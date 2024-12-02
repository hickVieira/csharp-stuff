namespace Matematica;

public struct float2
{
    public f32 x, y;

    #region constructors
    public float2(f32 x, f32 y) => (this.x, this.y) = (x, y);
    #endregion

    #region accessors
    public f32 r => x;
    public f32 g => y;

    public float2 xy => this;
    public float2 yx => new(y, x);

    public float2 rg => this;
    public float2 gr => new(y, x);
    #endregion

    #region operators
    public static float2 operator +(float2 a, float2 b) => new(a.x + b.x, a.y + b.y);
    public static float2 operator -(float2 a, float2 b) => new(a.x - b.x, a.y - b.y);
    public static float2 operator -(float2 a) => new(-a.x, -a.y);

    public static float2 operator *(float2 a, f32 b) => new(a.x * b, a.y * b);
    public static float2 operator *(f32 b, float2 a) => new(a.x * b, a.y * b);
    public static float2 operator /(float2 a, f32 b) => new(a.x / b, a.y / b);

    public static float2 operator *(float2 a, float2 b) => new(a.x * b.x, a.y * b.y);
    public static float2 operator /(float2 a, float2 b) => new(a.x / b.x, a.y / b.y);

    public static bool operator ==(float2 a, float2 b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(float2 a, float2 b) => a.x != b.x || a.y != b.y;

    public static implicit operator float2(f32 v) => new(v, v);
    #endregion

    #region methods
    public override readonly bool Equals(object obj) => obj is float2 other && this == other;
    public override readonly int GetHashCode() => x.GetHashCode() ^ y.GetHashCode();
    public override readonly string ToString() => $"({x},{y})";
    #endregion
}