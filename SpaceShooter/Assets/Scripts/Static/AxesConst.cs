using UnityEngine;

public static class AxesUtils 
{
    public const string Vertical = "Vertical";
    public const string Horizontal = "Horizontal";

    public const string DoubleShot = "DoubleShot";
    public const string BurstFire = "BurstFire";
    public const string LaserBeam = "LaserBeam";

    public static float GetXAxes()
    {
        return Input.GetAxis(AxesUtils.Horizontal);
    }

    public static float GetYAxes()
    {
        return Input.GetAxis(AxesUtils.Vertical);
    }
}
