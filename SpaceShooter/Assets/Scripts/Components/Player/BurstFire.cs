using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFire : MonoBehaviour
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
        if (Input.GetButtonDown(AxesUtils.BurstFire))
        {
            print(AxesUtils.BurstFire);
            var Laser = Instantiate(LaserPrefab, this.transform.position, Quaternion.identity);
            Laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * LaserSpeed;
        }
    }
}
