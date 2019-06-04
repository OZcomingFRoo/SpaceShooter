using UnityEngine;

/// <summary>
/// Set Dynamic Waypoint that is relative to ViewPort (i.e. camera) regardless of screens resolution
/// </summary>
[CreateAssetMenu(fileName = "Waypoint",menuName = "Waypoint")]
public class Waypoint : ScriptableObject
{
    [SerializeField]
    [Range(0, 1.5f)]
    private float XPoint;

    [SerializeField]
    [Range(0, 1.5f)]
    private float YPoint;

    void Awake()
    {
        if(YPoint != default)
        {
            YPointProperty = YPoint;
        }
        if (XPoint != default)
        {
            XPointProperty = XPoint;
        }
    }

    public float XPointProperty { get; set; }
    public float YPointProperty { get; set; }

    public Vector3 WaypointGlobalPosition
    {
        get
        {
            return Camera.main.ViewportToWorldPoint(new Vector3(XPointProperty, YPointProperty, 1));
        }
    }
}
