using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField]
    GameObject LaserPrefab;
    [SerializeField]
    float LaserSpeed;
    [SerializeField]
    float LaserDamage;

    // TODO: Use this to implament limit to how much the laser used 
    [SerializeField]
    float LaserCanonHeatLimit;
    float LaserCanonHeatStatus;

    void Start()
    {
        if (LaserSpeed <= 0) LaserSpeed = 3;
    }

    void Update()
    {
        if (Input.GetButton(AxesUtils.LaserBeam))
        {
            print(AxesUtils.LaserBeam);
            var Laser = Instantiate(LaserPrefab, this.transform.position, Quaternion.identity);
            Laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * LaserSpeed;
        }
    }
}
