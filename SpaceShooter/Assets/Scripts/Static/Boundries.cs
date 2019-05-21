using UnityEngine;

public static class CameraBoundries
{
    private static Camera MainCamera { get { return Camera.main; } }
    
    public static float XMin()
    {
        return MainCamera.ViewportToWorldPoint(Vector3.zero).x;
    }

    public static float XMax()
    {
        return MainCamera.ViewportToWorldPoint(Vector3.one).x;
    }

    public static float YMax()
    {
        return MainCamera.ViewportToWorldPoint(Vector3.one).y;
    }

    public static float YMin()
    {
        return MainCamera.ViewportToWorldPoint(Vector3.zero).y;
    }
}
