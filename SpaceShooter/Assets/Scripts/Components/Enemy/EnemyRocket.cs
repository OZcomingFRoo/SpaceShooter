using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    [SerializeField]
    Waypoint startingPoint;

    [SerializeField]
    Vector2 velocity;
    
    void Start()
    {
        if (velocity == Vector2.zero) { velocity = Vector2.down; }
    }

    void Update()
    {
        
    }
}
