namespace Matematica;

public struct vec2T<T> where T : struct
{
    public float x, y;

    #region constructors
    public vec2T(float x, float y) => (this.x, this.y) = (x, y);
    #endregion

    #region accessors
    public float r => x;
    public float g => y;

    public vec2T<T> xy => this;
    public vec2T<T> yx => new(y, x);

    public vec2T<T> rg => new(x, y);
    public vec2T<T> gr => new(y, x);
    #endregion

    #region operators
    public static vec2T<T> operator +(vec2T<T> a, vec2T<T> b) => new(a.x + b.x, a.y + b.y);
    public static vec2T<T> operator -(vec2T<T> a, vec2T<T> b) => new(a.x - b.x, a.y - b.y);
    public static vec2T<T> operator -(vec2T<T> a) => new(-a.x, -a.y);

    public static vec2T<T> operator *(vec2T<T> a, float b) => new(a.x * b, a.y * b);
    public static vec2T<T> operator *(float b, vec2T<T> a) => new(a.x * b, a.y * b);
    public static vec2T<T> operator /(vec2T<T> a, float b) => new(a.x / b, a.y / b);

    public static vec2T<T> operator *(vec2T<T> a, vec2T<T> b) => new(a.x * b.x, a.y * b.y);
    public static vec2T<T> operator /(vec2T<T> a, vec2T<T> b) => new(a.x / b.x, a.y / b.y);

    public static bool operator ==(vec2T<T> a, vec2T<T> b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(vec2T<T> a, vec2T<T> b) => a.x != b.x || a.y != b.y;

    public static implicit operator vec2T<T>(float v) => new(v, v);
    #endregion

    #region methods
    public override readonly bool Equals(object obj) => obj is vec2T<T> other && this == other;
    public override readonly int GetHashCode() => x.GetHashCode() ^ y.GetHashCode();
    public override readonly string ToString() => $"({x},{y})";
    #endregion
}