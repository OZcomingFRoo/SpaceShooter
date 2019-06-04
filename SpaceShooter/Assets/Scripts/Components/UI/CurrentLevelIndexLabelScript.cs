using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CurrentLevelIndexLabelScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = SpaceShooterSceneManager.CurrentLevelCompleted.ToString();
    }
}
