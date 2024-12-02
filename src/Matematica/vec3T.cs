namespace Matematica;

public struct vec3T<T> where T : struct
{
    public f32 x, y, z;

    #region constructors
    public vec3T(f32 x, f32 y, f32 z) => (this.x, this.y, this.z) = (x, y, z);
    #endregion

    #region accessors
    public f32 r => x;
    public f32 g => y;
    public f32 b => z;

    public vec2T<T> xy => new(x, y);
    public vec2T<T> yx => new(y, x);

    public vec3T<T> xyz => this;
    public vec3T<T> xzy => new(x, z, y);
    public vec3T<T> yxz => new(y, x, z);
    public vec3T<T> yzx => new(y, z, x);
    public vec3T<T> zyx => new(z, y, x);
    public vec3T<T> zxy => new(z, x, y);

    public vec2T<T> rg => new(r, g);
    public vec2T<T> gr => new(g, r);

    public vec3T<T> rgb => this;
    public vec3T<T> rbg => new(r, b, g);
    public vec3T<T> grb => new(g, r, b);
    public vec3T<T> gbr => new(g, b, r);
    public vec3T<T> bgr => new(b, g, r);
    public vec3T<T> brg => new(b, r, g);
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