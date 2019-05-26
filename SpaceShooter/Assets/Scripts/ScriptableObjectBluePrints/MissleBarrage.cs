using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Barrage", menuName = "Missle Barrage")]
public class MissleBarrage : ScriptableObject
{
    [SerializeField] private Waypoint startingPoint;

    [SerializeField] private GameObject enemyPrafab;

    [SerializeField] private Vector2 velocity;

    [SerializeField] [Range(0, 0.4f)] private float accelerator;

    private void SetRocket(GameObject rocket)
    {
        EnemyRocket rocketScript = rocket.GetComponent<EnemyRocket>();
        rocketScript.startingPoint = startingPoint;
        rocketScript.velocity = velocity;
        if (accelerator > 0) rocketScript.accelerator = accelerator;
    }

    [SerializeField] [Min(1)] private int numberOfEnemiesToSpawn;

    [SerializeField] [Range(0.01f, 3)] private float spawnTimeBetweenEnemies;

    public List<GameObject> RocketReferences { get; private set; }
    public int NumberOfEnemiesToSpawn { get; set; }
    public float SpawnTimeBetweenEnemies { get; set; }

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
            var rocket = Object.Instantiate(enemyPrafab); // Create Enemy
            rocket.SetActive(false); // Disable enemy to set first
            RocketReferences.Add(rocket); // Set enemy's path and speed
            SetRocket(rocket);
            rocket.SetActive(true); // Enable enemy to start moving
            yield return new WaitForSeconds(SpawnTimeBetweenEnemies * 10); // Wait a little before spawn the next enemy
        }
    }
}
