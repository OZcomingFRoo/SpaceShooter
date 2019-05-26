using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    List<Wave> enemyWaves = new List<Wave>();

    void Start()
    {
        foreach (var wave in enemyWaves)
        {
            StartCoroutine(wave.StartWave());
        }
    }
    
    void Update()
    {
        
    }
}
