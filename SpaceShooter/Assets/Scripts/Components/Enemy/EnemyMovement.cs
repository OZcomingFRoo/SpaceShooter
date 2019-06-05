using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EnemyMovement : MonoBehaviour
{
    // Both can be set by developer or scriptable objects
    [SerializeField]
    public Path enemyPath;
    [SerializeField]
    public float stepSpeed;
    [SerializeField] bool LoopBackAndFourth = false;

    //Properties
    public int NextWaypoint { get; set; }
    public Vector3 Position { get { return transform.position; } set { transform.position = value; } }
    public List<Vector3> EnemyPathPosition { get; set; }

    private void Start()
    {
        if (stepSpeed <= 0) stepSpeed = 20;
        transform.position = enemyPath[0];
        NextWaypoint = 1;
        EnemyPathPosition = enemyPath.Waypoints().ToList();
    }

    private void Update()
    {
        if (NextWaypoint < EnemyPathPosition.Count)
        {
            if ((Vector2)Position == (Vector2)EnemyPathPosition[NextWaypoint]) NextWaypoint++; // Goto to the next point if reached the current one
            if (NextWaypoint < EnemyPathPosition.Count)
            {
                var step = stepSpeed * Time.deltaTime;
                Position = Vector2.MoveTowards(Position, EnemyPathPosition[NextWaypoint], step); 
            }
        }
        else if(LoopBackAndFourth)
        {
            EnemyPathPosition.Reverse();
            NextWaypoint = 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}