using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShot : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    GameObject LaserPrefab;
    [SerializeField]
    float LaserSpeed;
    [SerializeField]
    float LaserDamage;
    [SerializeField]
    [Range(0.001f, 1)]
    float LaserFireRate; 
    #endregion

    public float LaserFireRateCoroutine { get { return LaserFireRate; } }
    private List<Coroutine> FireCorotines { get; set; }

    void Start()
    {
        if (LaserSpeed <= 0) LaserSpeed = 3;
        if (LaserDamage <= 0) LaserDamage = 2;
        FireCorotines = new List<Coroutine>();
    }

    void Update()
    {
        if (Input.GetButtonDown(AxesUtils.DoubleShot))
        {
            FireCorotines.Add(StartCoroutine(Fire()));
        }
        else if (Input.GetButtonUp(AxesUtils.DoubleShot))
        {
            FireCorotines.ForEach(fireCoroutine => StopCoroutine(fireCoroutine));
        }
    }

    IEnumerator Fire()
    {
        while (true)
        {
            // Spawn 2 lasers
            var Laser1 = Instantiate(LaserPrefab, this.transform.position, Quaternion.identity);
            var Laser2 = Instantiate(LaserPrefab, this.transform.position, Quaternion.identity);
            // Set lasers position side by side
            Laser1.transform.position = new Vector3(Laser1.transform.position.x - 0.5f, Laser1.transform.position.y,1);
            Laser2.transform.position = new Vector3(Laser2.transform.position.x + 0.5f, Laser2.transform.position.y,1);
            // Shoot 2 lasers
            Laser1.GetComponent<Rigidbody2D>().velocity = Vector2.up * LaserSpeed;
            Laser2.GetComponent<Rigidbody2D>().velocity = Vector2.up * LaserSpeed;
            yield return new WaitForSeconds(this.LaserFireRateCoroutine);
        }
    }
}
