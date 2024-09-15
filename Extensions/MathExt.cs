using System;
using Godot;

public static class MathExt {
    public static float Abs(this float x) => Math.Abs(x);

    public static float Pow(this float x, float pow) => (float)Math.Pow(x, pow);

    public static Vector2 Pow(this Vector2 v,float pow) =>
        new(v.X.Pow(pow), v.Y.Pow(pow));

    /// <summary>
    /// Limit movement in either direction
    /// 12f.Limit(10f) => 10 <br/>
    /// 12f.Limit(15f) => 12 <br/>
    /// -12f.Limit(10f) => -10f <br/>
    /// </summary>
    public static float Limit(this float x,float limit) =>
        x > 0
            ? (x > limit ? limit : x)
            : (x < -limit ? -limit : x);

    /// <summary>
    /// Limit movement in either direction <br/>
    /// (100,-50).Limit(20) => (20,-20)
    /// </summary>
    public static Vector2 Limit(this Vector2 v,float limit) =>
        new(
            v.X.Limit(limit),
            v.Y.Limit(limit)
        );
}
