namespace Matematica;

public static partial class math
{
    public static f32 abs(f32 v) => (f32)System.Math.Abs(v);
    public static f64 abs(f64 v) => System.Math.Abs(v);

    public static f32 sign(f32 v) => v > 0.0f ? 1.0f : v < 0.0f ? -1.0f : 0.0f;
    public static f64 sign(f64 v) => v > 0.0 ? 1.0 : v < 0.0 ? -1.0 : 0.0;

    public static f32 lerp(f32 a, f32 b, f32 t) => a + (b - a) * t;
    public static f64 lerp(f64 a, f64 b, f64 t) => a + (b - a) * t;

    public static f32 sqrt(f32 v) => (f32)System.Math.Sqrt(v);
    public static f64 sqrt(f64 v) => System.Math.Sqrt(v);

    public static f32 rsqrt(f32 v) => (f32)System.Math.ReciprocalSqrtEstimate(v);
    public static f64 rsqrt(f64 v) => System.Math.ReciprocalSqrtEstimate(v);

    public static f32 pow(f32 x, f32 y) => (f32)System.Math.Pow(x, y);
    public static f64 pow(f64 x, f64 y) => System.Math.Pow(x, y);

    public static f32 exp(f32 v) => (f32)System.Math.Exp(v);
    public static f64 exp(f64 v) => System.Math.Exp(v);

    public static f32 log(f32 v) => (f32)System.Math.Log(v);
    public static f64 log(f64 v) => System.Math.Log(v);

    public static f32 log2(f32 v) => (f32)System.Math.Log2(v);
    public static f64 log2(f64 v) => System.Math.Log2(v);

    public static f32 log10(f32 v) => (f32)System.Math.Log10(v);
    public static f64 log10(f64 v) => System.Math.Log10(v);

    public static f32 round(f32 v) => (f32)System.Math.Round(v);
    public static f64 round(f64 v) => System.Math.Round(v);

    public static f32 floor(f32 v) => (f32)System.Math.Floor(v);
    public static f64 floor(f64 v) => System.Math.Floor(v);

    public static f32 ceil(f32 v) => (f32)System.Math.Ceiling(v);
    public static f64 ceil(f64 v) => System.Math.Ceiling(v);

    public static f32 clamp(f32 v, f32 min, f32 max) => System.Math.Clamp(v, min, max);
    public static f64 clamp(f64 v, f64 min, f64 max) => System.Math.Clamp(v, min, max);

    public static f32 saturate(f32 v) => System.Math.Clamp(v, 0.0f, 1.0f);
    public static f64 saturate(f64 v) => System.Math.Clamp(v, 0.0, 1.0);

    public static f32 mod(f32 x, f32 y) => (f32)System.Math.IEEERemainder(x, y);
    public static f64 mod(f64 x, f64 y) => System.Math.IEEERemainder(x, y);

    public static u32 step(u32 x, u32 y) => y >= x ? 1u : 0u;
    public static i32 step(i32 x, i32 y) => y >= x ? 1 : 0;
    public static f32 step(f32 x, f32 y) => y >= x ? 1.0f : 0.0f;
    public static f64 step(f64 x, f64 y) => y >= x ? 1.0 : 0.0;

    public static f32 sin(f32 v) => (f32)System.Math.Sin(v);
    public static f64 sin(f64 v) => System.Math.Sin(v);

    public static f32 cos(f32 v) => (f32)System.Math.Cos(v);
    public static f64 cos(f64 v) => System.Math.Cos(v);

    public static f32 tan(f32 v) => (f32)System.Math.Tan(v);
    public static f64 tan(f64 v) => System.Math.Tan(v);

    public static f32 asin(f32 v) => (f32)System.Math.Asin(v);
    public static f64 asin(f64 v) => System.Math.Asin(v);

    public static f32 acos(f32 v) => (f32)System.Math.Acos(v);
    public static f64 acos(f64 v) => System.Math.Acos(v);

    public static f32 atan(f32 v) => (f32)System.Math.Atan(v);
    public static f64 atan(f64 v) => System.Math.Atan(v);

    public static f32 rcp(f32 v) => (f32)System.Math.ReciprocalEstimate(v);
    public static f64 rcp(f64 v) => System.Math.ReciprocalEstimate(v);

    public static f32 radians(f32 v) => v * (f32)System.Math.PI / 180.0f;
    public static f64 radians(f64 v) => v * System.Math.PI / 180.0;

    public static f32 degrees(f32 v) => v * 180.0f / (f32)System.Math.PI;
    public static f64 degrees(f64 v) => v * 180.0 / System.Math.PI;
}
