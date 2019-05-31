using System;
using System.Collections.Generic;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        // ------ Calculate damage ------ //
        bool didObjectTakeDamage = false;
        LaserComponent projectile = collision.gameObject.GetComponent<LaserComponent>();
        if (projectile != null)
        {
            // The condition is standalone to avoid a corner case scenario where player gets hit by his own lasers
            if (isLaserFiredByTheOpposition(projectile.LaserType))
            {
                Health -= projectile.LaserDamage;
                didObjectTakeDamage = true; 
            }
        }
        else if(this.gameObject.tag == GameConstants.PLAYER_TAG)
        {
            Health--;
            didObjectTakeDamage = true;
        }

        // ------ Invoke the relevent event ------ //
        if (Health <= 0)
        {
            BeforeObjectDies.Invoke();
            Destroy(this.gameObject);
        }
        else if(didObjectTakeDamage)
        {
            OnObjectTookDamage.Invoke();
        }
    }

    private bool isLaserFiredByTheOpposition(LaserType laserType)
    {
        string tag = this.gameObject.tag;
        return
            tag == GameConstants.PLAYER_TAG && laserType == LaserType.EnemyLaser ||
            tag == GameConstants.ENEMY_TAG && laserType == LaserType.PlayerLaser;
    }
}
