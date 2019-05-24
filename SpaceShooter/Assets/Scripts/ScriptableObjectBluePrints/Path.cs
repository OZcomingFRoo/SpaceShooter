using System.Linq;
using UnityEngine;

/// <summary>
/// A path is a set of waypoints that the enemy will use to move around
/// </summary>
[CreateAssetMenu(fileName = "Path", menuName = "Path")]
public class Path : ScriptableObject
{
    [SerializeField]
    private Waypoint[] waypoints;
    /// <summary>
    /// Save the initial value evaluated from 'select' Linq
    /// </summary>
    private Vector3[] GlobalVectors { get; set; }

    public int Length { get { return waypoints.Length; } }

    public Vector3 this[int index]
    {
        get { return index < this.Length ? waypoints[index].WaypointGlobalPosition : Vector3.zero; }
    }

    /// <summary>
    /// Returns a NEW array of Vectors made from the waypoints set
    /// </summary>
    /// <returns>Global position</returns>
    public Vector3[] Waypoints()
    {
        return GlobalVectors = waypoints.Select(waypoint => waypoint.WaypointGlobalPosition).ToArray();
    }
}
