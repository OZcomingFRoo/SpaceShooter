using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level1Script : MonoBehaviour
{
    [Header("Wave")]
    [SerializeField] List<MissleBarrage> MissleBarrages;
    [Header("Other settings to fill")]
    [SerializeField] bool SkipLevel = false;
    [SerializeField] HealthComponent playerHealth;
    public int OverallEnemiesToSpawn { get; set; }
    public int EnemiesDestroyed { get; set; }

    void Start()
    {
        // Setup
        EnemiesDestroyed = OverallEnemiesToSpawn = 0;
        playerHealth.BeforeObjectDies += () => {
            Debug.Log("Player KIA"); SpaceShooterSceneManager.LoadGameOverScene();
        };
        foreach (var barrage in MissleBarrages)
        {
            barrage.WhenEnemyRocketDiesDelegate = () => { EnemiesDestroyed++; Debug.Log("Enemy Count = " + EnemiesDestroyed); };
            OverallEnemiesToSpawn += barrage.NumberOfEnemiesToSpawn;
        }
        Debug.Log("Count = " + OverallEnemiesToSpawn);
        
        // -------- Start Level -------- //
        StartCoroutine(StartLevel());
    }
    

    IEnumerator StartLevel()
    {
        foreach (var barrage in MissleBarrages)
        {
            StartCoroutine(barrage.StartWave());
            yield return new WaitForSeconds(3);
        }
    }

    void Update()
    {
        if(EnemiesDestroyed == OverallEnemiesToSpawn || SkipLevel)
        {
            SpaceShooterSceneManager.LoadLevelCompletedScene();
        }
    }
}
