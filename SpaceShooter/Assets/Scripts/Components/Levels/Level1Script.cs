using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Script : MonoBehaviour
{
    [SerializeField] MissleBarrage SimpleMissleBarrage;
    [SerializeField] bool SkipLevel;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SimpleMissleBarrage.StartWave());
    }

    // Update is called once per frame
    void Update()
    {
        if(SkipLevel && Input.GetKeyDown(KeyCode.V))
        {
            SpaceShooterSceneManager.LoadLevelCompletedScene();
        }
    }
}
