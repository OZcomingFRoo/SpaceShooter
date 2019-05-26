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
    /// The enemy prefab object to spawn
    /// </summary>
    [SerializeField] private GameObject enemyPrafab;

    /// <summary>
    /// Sets enemy's main propeties
    /// </summary>
    /// <param name="enemy">The enemy to set</param>
    /// <param name="path">The path which enemy must takes </param>
    /// <param name="enemySpeed">OPTIONAL, sets enemy's speed</param>
    private void SetEnemyMovementComponent(GameObject enemy,Path path,float enemySpeed = 0)
    {
        EnemyMovement EnemyMovementComponent = enemy.GetComponent<EnemyMovement>();
        EnemyMovementComponent.enemyPath = path;
        if (enemySpeed > 0) EnemyMovementComponent.stepSpeed = enemySpeed;
    }

    /// <summary>
    /// Path the enemies will take
    /// </summary>
    [SerializeField] private Path wavePath;

    /// <summary>
    /// Amount of enemies 
    /// </summary>
    [Range(1,100)]
    [SerializeField] private int numberOfEnemiesToSpawn;

    /// <summary>
    /// The time it takes for enemies to spawn after one and another 
    /// </summary>
    [Range(0.01f,3)]
    [SerializeField] private float SpawnTimeBetweenEnemies;

    /// <summary>
    /// Sets enemy speed when moving  (optional)
    /// </summary>
    [SerializeField] private float EnemySpeed;

    public IEnumerator StartWave()  
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            var enemy = Object.Instantiate(enemyPrafab);
            enemy.SetActive(false);
            SetEnemyMovementComponent(enemy, wavePath, EnemySpeed);
            enemy.SetActive(true);
            yield return new WaitForSeconds(SpawnTimeBetweenEnemies);
        }
        
    }
}
