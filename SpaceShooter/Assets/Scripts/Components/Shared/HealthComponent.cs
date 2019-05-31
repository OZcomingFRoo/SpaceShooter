﻿using System;
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
        if (collision.gameObject.GetComponent<LaserComponent>() != null)
        {
            Health -= collision.GetComponent<LaserComponent>().LaserDamage;
            didObjectTakeDamage = true;
        }
        else if(this.gameObject.tag == "Player")
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
}
