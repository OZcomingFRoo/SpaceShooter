using System.Collections;   
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    public Path enemyPath;
    [SerializeField]
    float stepSpeed;

    //Properties
    public int NextWaypoint { get; set; }
    public Vector3 Position { get { return transform.position; } set { transform.position = value; } }
    public Vector3[] EnemyPathPosition { get; set; }


    private void Start()
    {
        if (stepSpeed <= 0) stepSpeed = 3;
        transform.position = enemyPath[0];
        NextWaypoint = 1;
    }

    private void Update()
    {
        if (NextWaypoint < enemyPath.Length)
        {
            if ((Vector2)Position == (Vector2)enemyPath[NextWaypoint]) NextWaypoint++; // Goto to the next point if reached the current one
            var step = stepSpeed * Time.deltaTime;
            Position = Vector2.MoveTowards(Position, enemyPath[NextWaypoint], step);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
