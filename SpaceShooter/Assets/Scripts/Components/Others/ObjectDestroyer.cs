using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var healthScript = collision.gameObject.GetComponent<HealthComponent>();
        if(healthScript)
        {
            healthScript.GetHit(9999);
        }
        Destroy(collision.gameObject);
    }
}
