using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ButtonManagerScript : MonoBehaviour
{
    [SerializeField] [Range(0,255)] short StartIndex = 0;
    public List<int> Buttons { get; set; }
    private int ButtonIndex { get; set; }

    void Start()
    {
        Buttons = new List<int>();
        foreach (Transform item in transform)
        {
            if(item.tag == "Button") AddButtonIndex(item.GetSiblingIndex());
        }
        ButtonIndex = Mathf.Clamp(StartIndex, 0, Buttons.Count - 1);
        HighlightButton();
    }

    void Update()
    {
        float axis = Input.GetAxis("Vertical");
        if(axis != 0) // User pressed a button
        {
            UnHighlightButton();
            if (axis > 0) // Press up button
            {
                ButtonIndex = Mathf.Clamp(ButtonIndex + 1, 0, Buttons.Count - 1);
            }
            else // Press down button
            {
                ButtonIndex = Mathf.Clamp(ButtonIndex - 1, 0, Buttons.Count - 1);
            }
            HighlightButton();
        }
        if(Input.GetKey(KeyCode.Return) || Input.GetButtonDown("DoubleShot") || Input.GetButtonDown("BurstFire"))
        {
            PressButton();
        }
    }

    /// <summary>
    /// Utility function for easier reading
    /// </summary>
    /// <param name="index">The current button to un/highlight</param>
    /// <returns>The current highlighted button's script component (used to turn on/off the animation) </returns>
    private HighlightedButtonAnimationScript GetButtonAnimationScript(int index)
    {
        return transform.GetChild(Buttons[index]).GetComponentInChildren<HighlightedButtonAnimationScript>();
    }

    void AddButtonIndex(int index)
    {
        Buttons.Add(index);
    }

    private void PressButton()
    {
        transform.GetChild(Buttons[ButtonIndex]).GetComponent<Button>().onClick.Invoke();
    }
    private void UnHighlightButton()
    {
        GetButtonAnimationScript(ButtonIndex).StopAnimation();
    }
    private void HighlightButton()
    {
        GetButtonAnimationScript(ButtonIndex).StartAnimation();
    }   
}
