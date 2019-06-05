using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    [SerializeField]
    public Waypoint startingPoint;

    [SerializeField]
    [Range(0, 0.4f)]
    public float accelerator;

    [SerializeField]
    public Vector2 velocity;

    public Rigidbody2D Rigidbody2D { get { return this.GetComponent<Rigidbody2D>(); } }

    void Start()
    {
        transform.position = startingPoint.WaypointGlobalPosition;
        if (velocity == Vector2.zero) { velocity = Vector2.down; }
        velocity.y = velocity.y * -1;
        Rigidbody2D.velocity = velocity * Time.deltaTime;
    }

    void Update()
    {
        velocity.y = (velocity.y * (1 + accelerator));
        Rigidbody2D.velocity = velocity * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject); // OPTIONAL TODO: Explosion should happen
    }
}
