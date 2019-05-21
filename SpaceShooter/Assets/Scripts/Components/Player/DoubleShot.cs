using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShot : MonoBehaviour
{
    [SerializeField]
    GameObject LaserPrefab;
    [SerializeField]
    float LaserSpeed;
    [SerializeField]
    float LaserDamage;

    void Start()
    {
        if (LaserSpeed <= 0) LaserSpeed = 3;
    }

    void Update()
    {
        if (Input.GetButtonDown(AxesUtils.DoubleShot))
        {
            print(AxesUtils.DoubleShot);
            var Laser = Instantiate(LaserPrefab, this.transform.position, Quaternion.identity);
            Laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * LaserSpeed;

        }
    }
}
