using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Script : MonoBehaviour
{
    [Header("Wave")]
    [SerializeField] List<Wave> waves;
    [Header("Other settings to fill")]
    [SerializeField] bool SkipLevel = false;
    [SerializeField] HealthComponent playerHealth;

    void Start()
    {
        playerHealth.BeforeObjectDies += () => { Debug.Log("Player KIA"); SpaceShooterSceneManager.LoadGameOverScene(); };
    }

    
    void Update()
    {
        
    }
}
