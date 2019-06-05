using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Barrage", menuName = "Missle Barrage")]
public class MissleBarrage : ScriptableObject
{
    [Header("Asset Propeties")]
    [SerializeField] private GameObject enemyPrafab;

    [Header("Movement Setting")]
    [SerializeField] private Vector2 velocity;
    [SerializeField] [Range(0, 0.4f)] private float accelerator;

    [Header("Spawn Setting")]
    [SerializeField] private Waypoint startingPoint;
    [SerializeField] [Min(1)] private int numberOfEnemiesToSpawn;
    [SerializeField] [Range(0.01f, 10)] private float spawnTimeBetweenEnemies;

    public List<GameObject> RocketReferences { get; private set; }
    public Action WhenEnemyRocketDiesDelegate { get; set; }
    public event Action OnWaveEnded;
    public float SpawnTimeBetweenEnemies { get; set; }
    private int _numberOfEnemiesToSpawn;
    public int NumberOfEnemiesToSpawn
    {
        get
        {
            if (_numberOfEnemiesToSpawn <= 0) NumberOfEnemiesToSpawn = numberOfEnemiesToSpawn;
            return _numberOfEnemiesToSpawn;
        }
        set
        {
            _numberOfEnemiesToSpawn = value;
        }
    }

    private void SetRocket(GameObject rocket)
    {
        EnemyMissile missle = rocket.GetComponent<EnemyMissile>();
        missle.startingPoint = startingPoint;
        missle.startingPoint = startingPoint;
        missle.velocity = velocity;
        if (WhenEnemyRocketDiesDelegate != null) rocket.GetComponent<HealthComponent>().BeforeObjectDies += WhenEnemyRocketDiesDelegate;
        if (accelerator > 0) missle.accelerator = accelerator;
    }

    public IEnumerator StartWave()
    {
        RocketReferences = new List<GameObject>();
        if (SpawnTimeBetweenEnemies <= 0) SpawnTimeBetweenEnemies = spawnTimeBetweenEnemies;
        if (NumberOfEnemiesToSpawn <= 0) NumberOfEnemiesToSpawn = numberOfEnemiesToSpawn;
        accelerator = Mathf.Clamp(accelerator, 0, 0.4f); // In case the accelerator was set in runtime, make sure it doesn't go above the limit
        return SpawnEnemies();
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < NumberOfEnemiesToSpawn; i++)
        {
            var rocket = UnityEngine.Object.Instantiate(enemyPrafab); // Create Enemy
            rocket.SetActive(false); // Disable enemy to set first
            RocketReferences.Add(rocket); // Set enemy's path and speed
            SetRocket(rocket);
            rocket.SetActive(true); // Enable enemy to start moving
            yield return new WaitForSeconds(SpawnTimeBetweenEnemies); // Wait a little before spawn the next enemy
        }
        if(OnWaveEnded != null) OnWaveEnded.Invoke();
    }
}
