using UnityEngine;
using System.Collections;

public class PlayerDefenceSystem : MonoBehaviour
{
    [SerializeField] [Min(1)] float temporarilyShieldDurationInSeconds = 3;
    [SerializeField] [Min(0.01f)] float SpaceShipIndestructableBlinkAnimationRate = 0.1f;

    void Start()
    {
        GetComponent<HealthComponent>().OnObjectTookDamage += ActivateShield;
    }

    void ActivateShield()
    {
        StartCoroutine(DisableBoxCollider());
    }

    /// <summary>
    /// Disables all box colliders to prevent player recieving damage for a short time
    /// </summary>
    /// <returns></returns>
    IEnumerator DisableBoxCollider()
    {
        Debug.Log("Activate Shield");
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<CapsuleCollider2D>().enabled = false;
        var blinkAnimationCoroutine = StartCoroutine(BlinkSprite());
        yield return new WaitForSeconds(temporarilyShieldDurationInSeconds);

        Debug.Log("Disable Shield");
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<CapsuleCollider2D>().enabled = true;
        StopCoroutine(blinkAnimationCoroutine);
        this.GetComponent<SpriteRenderer>().enabled = true;
    }

    IEnumerator BlinkSprite()
    {
        while(true)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(SpaceShipIndestructableBlinkAnimationRate);
            this.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(SpaceShipIndestructableBlinkAnimationRate);
        }
    }
}
