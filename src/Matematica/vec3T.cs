namespace Matematica;

public struct vec3T<T> where T : struct
{
    public f32 x, y, z;

    #region constructors
    public vec3T(f32 x, f32 y, f32 z) => (this.x, this.y, this.z) = (x, y, z);
    #endregion

    #region operators
    public static vec3T<T> operator +(vec3T<T> a, vec3T<T> b) => new(a.x + b.x, a.y + b.y);
    public static vec3T<T> operator -(vec3T<T> a, vec3T<T> b) => new(a.x - b.x, a.y - b.y);
    public static vec3T<T> operator -(vec3T<T> a) => new(-a.x, -a.y);

    public static vec3T<T> operator *(vec3T<T> a, f32 b) => new(a.x * b, a.y * b);
    public static vec3T<T> operator *(f32 b, vec3T<T> a) => new(a.x * b, a.y * b);
    public static vec3T<T> operator /(vec3T<T> a, f32 b) => new(a.x / b, a.y / b);

    public static vec3T<T> operator *(vec3T<T> a, vec3T<T> b) => new(a.x * b.x, a.y * b.y);
    public static vec3T<T> operator /(vec3T<T> a, vec3T<T> b) => new(a.x / b.x, a.y / b.y);

    public static bool operator ==(vec3T<T> a, vec3T<T> b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(vec3T<T> a, vec3T<T> b) => a.x != b.x || a.y != b.y;

    public static implicit operator vec3T<T>(f32 v) => new(v, v);
    #endregion

    #region methods
    public override readonly bool Equals(object obj) => obj is vec3T<T> other && this == other;
    public override readonly int GetHashCode() => x.GetHashCode() ^ y.GetHashCode();
    public override readonly string ToString() => $"({x},{y})";
    #endregion
}