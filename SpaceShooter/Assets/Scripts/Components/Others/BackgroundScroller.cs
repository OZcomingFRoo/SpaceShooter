using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] private float verticalbackgroundScrollingSpeed;
    [SerializeField] private float horizontalbackgroundScrollingSpeed;

    private Vector2 Offset { get; set; }
    private Material BackgroundMaterial { get; set; }

    /// <summary>
    /// Use this property to add cool transitions, for example:  when player wins , or to boss phase, going into slow-motion etc... ;D
    /// </summary>
    public float HorizontolScrolling
    {
        get
        {
            return horizontalbackgroundScrollingSpeed;
        }
        set
        {
            horizontalbackgroundScrollingSpeed = Mathf.Clamp(value, 0, 15);
            Offset = new Vector2(horizontalbackgroundScrollingSpeed, verticalbackgroundScrollingSpeed);
        }
    }

    /// <summary>
    /// Use this property to add cool transitions, for example:  when player wins , or to boss phase, going into slow-motion etc... ;D
    /// </summary>
    public float VerticalScrolling
    {
        get
        {
            return verticalbackgroundScrollingSpeed;
        }
        set
        {
            verticalbackgroundScrollingSpeed = Mathf.Clamp(value,0,15);
            Offset = new Vector2(horizontalbackgroundScrollingSpeed, verticalbackgroundScrollingSpeed);
        }
    }

    private void LoopBackgroundXYOffset()
    {
        float x, y;
        x = BackgroundMaterial.mainTextureOffset.x >= 10 ? 0 : BackgroundMaterial.mainTextureOffset.x;
        y = BackgroundMaterial.mainTextureOffset.y >= 10 ? 0 : BackgroundMaterial.mainTextureOffset.y;
        BackgroundMaterial.mainTextureOffset = new Vector2(x, y);
    }

    private IEnumerator UpdateOffsetCoroutine()
    {
        while(true)
        {
            HorizontolScrolling = horizontalbackgroundScrollingSpeed;
            VerticalScrolling = verticalbackgroundScrollingSpeed;
            yield return new WaitForSeconds(2.2f);
        }
    }

    void Start()
    {
        BackgroundMaterial =  GetComponent<Renderer>().material;
        Offset = new Vector2(horizontalbackgroundScrollingSpeed, verticalbackgroundScrollingSpeed);
        StartCoroutine(UpdateOffsetCoroutine());
    }

    void Update()
    {
        BackgroundMaterial.mainTextureOffset += Offset * Time.deltaTime;
        LoopBackgroundXYOffset();
    }
}
