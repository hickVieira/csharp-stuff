// namespace Matematica;

// public struct vec4T<T> where T : struct
// {
//     public f32 x, y, z, w;

//     #region constructors
//     public vec4T(f32 x, f32 y, f32 z, f32 w) => (this.x, this.y, this.z, this.w) = (x, y, z, w);
//     #endregion

//     #region operators
//     public static vec4T<T> operator +(vec4T<T> a, vec4T<T> b) => new(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
//     public static vec4T<T> operator -(vec4T<T> a, vec4T<T> b) => new(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
//     public static vec4T<T> operator -(vec4T<T> a) => new(-a.x, -a.y, -a.z);

//     public static vec4T<T> operator *(vec4T<T> a, f32 b) => new(a.x * b, a.y * b, a.z * b);
//     public static vec4T<T> operator *(f32 b, vec4T<T> a) => new(b * a.x, b * a.y, b * a.z);
//     public static vec4T<T> operator /(vec4T<T> a, f32 b) => new(a.x / b, a.y / b, a.z / b);

//     public static vec4T<T> operator *(vec4T<T> a, vec4T<T> b) => new(a.x * b.x, a.y * b.y, a.z * b.z);
//     public static vec4T<T> operator /(vec4T<T> a, vec4T<T> b) => new(a.x / b.x, a.y / b.y, a.z / b.z);

//     public static bool operator ==(vec4T<T> a, vec4T<T> b) => a.x == b.x && a.y == b.y && a.z == b.z;
//     public static bool operator !=(vec4T<T> a, vec4T<T> b) => a.x != b.x || a.y != b.y || a.z != b.z;

//     public static implicit operator vec4T<T>(f32 v) => new(v, v, v);
//     #endregion

//     #region methods
//     public override readonly bool Equals(object obj) => obj is vec4T<T> other && this == other;
//     public override readonly int GetHashCode() => x.GetHashCode() ^ y.GetHashCode();
//     public override readonly string ToString() => $"({x},{y})";
//     #endregion
// }