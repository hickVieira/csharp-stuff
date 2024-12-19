namespace Matematica;

public struct vec2T<T> where T : struct
{
    public f32 x, y;

    #region constructors
    public vec2T(f32 x, f32 y) => (this.x, this.y) = (x, y);
    #endregion

    #region operators
    public static vec2T<T> operator +(vec2T<T> a, vec2T<T> b) => new(a.x + b.x, a.y + b.y);
    public static vec2T<T> operator -(vec2T<T> a, vec2T<T> b) => new(a.x - b.x, a.y - b.y);
    public static vec2T<T> operator -(vec2T<T> a) => new(-a.x, -a.y);

    public static vec2T<T> operator *(vec2T<T> a, f32 b) => new(a.x * b, a.y * b);
    public static vec2T<T> operator *(f32 b, vec2T<T> a) => new(b * a.x, b * a.y);
    public static vec2T<T> operator /(vec2T<T> a, f32 b) => new(a.x / b, a.y / b);

    public static vec2T<T> operator *(vec2T<T> a, vec2T<T> b) => new(a.x * b.x, a.y * b.y);
    public static vec2T<T> operator /(vec2T<T> a, vec2T<T> b) => new(a.x / b.x, a.y / b.y);

    public static bool operator ==(vec2T<T> a, vec2T<T> b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(vec2T<T> a, vec2T<T> b) => a.x != b.x || a.y != b.y;

    public static implicit operator vec2T<T>(f32 v) => new(v, v);
    #endregion

    #region methods
    public override readonly bool Equals(object obj) => obj is vec2T<T> other && this == other;
    public override readonly int GetHashCode() => x.GetHashCode() ^ y.GetHashCode();
    public override readonly string ToString() => $"({x},{y})";
    #endregion
}