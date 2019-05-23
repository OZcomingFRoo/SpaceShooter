using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFire : MonoBehaviour
{
    #region SerializeField
    [SerializeField]
    GameObject LaserPrefab;

    [SerializeField]
    float LaserSpeed;

    [SerializeField]
    float LaserDamage;

    [SerializeField]
    [Range(2,4)]
    byte numberOfBurstShots;

    [Range(0.0001f,0.3f)]
    [SerializeField]
    float burstFireRate;
    #endregion

    void Start()
    {
        if (LaserSpeed <= 0) LaserSpeed = 3;
        if (numberOfBurstShots <= 1) numberOfBurstShots = 3;
        if (burstFireRate <= 0) burstFireRate = 0.1f;
    }

    void Update()
    {
        if (Input.GetButtonDown(AxesUtils.BurstFire))
        {
            StartCoroutine(BurstShots());
        }
    }

    IEnumerator BurstShots()
    {
        for (int i = 0; i < numberOfBurstShots; i++)
        {
            var Laser = Instantiate(LaserPrefab, this.transform.position, Quaternion.identity);
            Laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * LaserSpeed;
            yield return new WaitForSeconds(burstFireRate);
        }
    }
}
