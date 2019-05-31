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
        if (BeforeObjectDies == null) BeforeObjectDies = () => { Debug.Log("Object " + gameObject.name + " is dead"); };
        if (OnObjectTookDamage == null) OnObjectTookDamage = () => { Debug.Log("Object " + gameObject.name + " Too damage"); };
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Calculate damage
        if (collision.GetComponent<LaserComponent>() != null)
        {
            Health -= collision.GetComponent<LaserComponent>().LaserDamage;
        }
        else if(gameObject.tag == "Player")
        {
            Health--;
        }
        // Invoke the relevent event
        if(Health <= 0)
        {
            BeforeObjectDies.Invoke();
            Destroy(this.gameObject);
        }
        else
        {
            OnObjectTookDamage.Invoke();
        }
    }
}
