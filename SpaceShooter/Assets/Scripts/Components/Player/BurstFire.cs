using System.Collections;
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
    [Range(2, 4)]
    byte numberOfBurstShots;

    [Range(0.0001f, 0.3f)]
    [SerializeField]
    float burstFireRate;

    [Range(0.1f, 0.5f)]
    [SerializeField]
    float burstRate;
    #endregion
    private float BurstRateCooldown { get; set; }

    void Start()
    {
        SetDefaultValues();
    }

    /// <summary>
    /// Sets default valeus for serialized fields that weren't set by Developer
    /// </summary>
    private void SetDefaultValues()
    {
        if (LaserSpeed <= 0) LaserSpeed = 3;
        if (numberOfBurstShots <= 1) numberOfBurstShots = 3;
        if (burstFireRate <= 0) burstFireRate = 0.1f;
        if (burstRate <= 0) burstRate = 0.4f;
    }

    void Update()
    {
        if (Input.GetButtonDown(AxesUtils.BurstFire) && BurstRateCooldown == 0)
        {
            StartCoroutine(BurstShots());
            BurstRateCooldown = burstRate;
        }
        // The time between each burst shot was not done yet, thus no shot was fired 
        // i.e. if player tried to shoot, if now then "BurstRateCooldown" will remain 0, meaning player can shoot at any given time
        else
        {
            BurstRateCooldown = Mathf.Clamp01(BurstRateCooldown - Time.deltaTime);
        }
    }

    IEnumerator BurstShots()
    {
        for (int i = 0; i < numberOfBurstShots; i++)
        {
            var Laser = Instantiate(LaserPrefab, this.transform.position, Quaternion.identity);
            Laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * LaserSpeed;
            Laser.GetComponent<LaserComponent>().LaserDamage = this.LaserDamage;
            yield return new WaitForSeconds(burstFireRate);
        }
    }
}
