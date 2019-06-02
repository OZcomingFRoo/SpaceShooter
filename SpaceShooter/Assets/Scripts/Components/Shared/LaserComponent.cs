using UnityEngine;

public class LaserComponent : MonoBehaviour
{
    [SerializeField]
    [Min(0.000000001f)]
    float laserDamage;

    [SerializeField]
    LaserType laserType;

    public float LaserDamage { get; set; }
    public LaserType LaserType { get { return laserType; } }

    void Start()
    {
        if (LaserDamage <= 0) LaserDamage = this.laserDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
