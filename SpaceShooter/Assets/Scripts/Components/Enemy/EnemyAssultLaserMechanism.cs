using UnityEngine;

public class EnemyAssultLaserMechanism : MonoBehaviour
{
    [SerializeField]
    GameObject LaserPrefab;

    [SerializeField]
    [Range(1, 10)]
    float FireRate = 1;

    [SerializeField]
    bool consistantRate = true;

    [SerializeField]
    float laserSpeed = 20;

    [SerializeField]
    float LaserOffset = 2;

    public Vector2 Position { get { return transform.position; } }

    private float TimeLapse { get; set; }

    void Start()
    {
        TimeLapse = 0;
    }

    void Update()
    {
        TimeLapse += Time.deltaTime;
        if (TimeLapse >= FireRate)
        {
            TimeLapse = 0;
            Debug.Log("FIRE");
            FireLaser();
        }
    }

    void FireLaser()
    {
        var laser = Instantiate(LaserPrefab, new Vector3(Position.x, Position.y - LaserOffset, 1), Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = Vector2.down * laserSpeed;
    }
}
