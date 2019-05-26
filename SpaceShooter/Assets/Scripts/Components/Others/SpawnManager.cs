using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    List<Wave> enemyWaves = new List<Wave>();

    [SerializeField]
    MissleBarrage test;

    void Start()
    {
        foreach (var wave in enemyWaves)
        {
            StartCoroutine(wave.StartWave());
        }
        StartCoroutine(test.StartWave());
    }
}
