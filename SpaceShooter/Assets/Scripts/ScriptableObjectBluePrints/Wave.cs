using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Create contstant config of enemy waves that can be used in multiple levels
/// </summary>
[CreateAssetMenu(fileName = "Wave", menuName = "Wave")]
public class Wave : ScriptableObject
{
    /// <summary>
    /// Path the enemies will take
    /// </summary>
    [SerializeField] private Path wavePath;

    /// <summary>
    /// The enemy prefab object to spawn
    /// </summary>
    [SerializeField] private GameObject enemyPrafab;

    /// <summary>
    /// Sets enemy speed when moving  (optional)
    /// </summary>
    [SerializeField] private float enemySpeed;

    /// <summary>
    /// Sets enemy's main propeties
    /// </summary>
    /// <param name="enemy">The enemy to set</param>
    /// <param name="path">The path which enemy must takes </param>
    /// <param name="enemySpeed">OPTIONAL, sets enemy's speed</param>
    private void SetEnemyMovementComponent(GameObject enemy)
    {
        EnemyMovement EnemyMovementComponent = enemy.GetComponent<EnemyMovement>();
        EnemyMovementComponent.enemyPath = wavePath;
        if (EnemySpeed > 0) EnemyMovementComponent.stepSpeed = EnemySpeed;
    }

    /// <summary>
    /// Amount of enemies 
    /// </summary>
    [Min(1)]
    [SerializeField] private int numberOfEnemiesToSpawn;

    /// <summary>
    /// The time it takes for enemies to spawn after one and another 
    /// </summary>
    [Range(0.01f, 3)]
    [SerializeField] private float spawnTimeBetweenEnemies;

    [SerializeField] private bool LoopBackAndFourth = false;

    public List<GameObject> EnemyReferences { get; private set; }
    public float SpawnTimeBetweenEnemies { get; set; }
    public int NumberOfEnemiesToSpawn { get; set; }
    public float EnemySpeed { get; set; }

    public IEnumerator StartWave()
    {
        EnemyReferences = new List<GameObject>();
        if (SpawnTimeBetweenEnemies <= 0) SpawnTimeBetweenEnemies = spawnTimeBetweenEnemies;
        if (NumberOfEnemiesToSpawn <= 0) NumberOfEnemiesToSpawn = numberOfEnemiesToSpawn;
        if (EnemySpeed <= 0) EnemySpeed = enemySpeed;
        return SpawnEnemies();
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < NumberOfEnemiesToSpawn; i++)
        {
            var enemy = Object.Instantiate(enemyPrafab); // Create Enemy
            enemy.SetActive(false); // Disable enemy to set first
            EnemyReferences.Add(enemy); // Set enemy's path and speed
            SetEnemyMovementComponent(enemy);
            enemy.SetActive(true); // Enable enemy to start moving
            yield return new WaitForSeconds(SpawnTimeBetweenEnemies); // Wait a little before spawn the next enemy
        }
    }
}
