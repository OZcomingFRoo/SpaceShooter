using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HighlightedButtonAnimationScript : MonoBehaviour
{
    [SerializeField] Color BlickingColor = new Color(0, 0, 255);
    [SerializeField] float BlinkingRate = 0.1f;

    private Color DefaultColor { get; set; }
    private Color TextFontColor { get { return this.GetComponent<Text>().color; } set { this.GetComponent<Text>().color = value; } }

    void Start()
    {
        DefaultColor = TextFontColor;
    }

    public void StartAnimation()
    {
        StartCoroutine(HighlightButton());
    }
    public void StopAnimation()
    {
        StopAllCoroutines();
        TextFontColor = DefaultColor;
    }

    private IEnumerator HighlightButton()
    {
        while (true)
        {
            var nextColor = TextFontColor == BlickingColor ? DefaultColor : BlickingColor;
            yield return new WaitForSeconds(BlinkingRate);
            TextFontColor = nextColor;
            yield return new WaitForSeconds(BlinkingRate);
        }
    }
}
