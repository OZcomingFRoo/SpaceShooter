using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private float health;

    /// <summary>
    /// Health that is set by laser shots
    /// </summary>
    public float Health { get; set; }

    public event Action BeforeObjectDies;
    public event Action OnObjectTookDamage;

    void Start()
    {
        Health = health;
        BeforeObjectDies += () => { Debug.Log("Object " + gameObject.name + " is dead"); };
        OnObjectTookDamage += () => { Debug.Log("Object " + gameObject.name + " Took damage"); };
    }

    public void GetHit(float damage)
    {
        Health -= damage;
        bool didObjectTakeDamage = damage > 0;
        
        // ------ Invoke the relevent event ------ //
        if (Health <= 0)
        {
            if (BeforeObjectDies != null) BeforeObjectDies.Invoke();
            Destroy(this.gameObject);
        }
        else if (didObjectTakeDamage)
        {
            OnObjectTookDamage.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // ------ Calculate damage ------ //
        float damageReceived = 0;
        LaserComponent projectile = collision.gameObject.GetComponent<LaserComponent>();
        if (projectile != null)
        {
            damageReceived = projectile.LaserDamage;
        }
        else if (this.gameObject.tag == GameConstants.PLAYER_TAG)
        {
            damageReceived = 1;
        }
        GetHit(damageReceived);
    }
}
