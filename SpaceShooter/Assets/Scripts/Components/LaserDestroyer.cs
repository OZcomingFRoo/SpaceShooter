using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Destroy");
        Object.Destroy(collision.gameObject);
    }
}
