using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField]
    int maxEnemies;

    public static int MaxEnemies;
    public static int EnemyCount = 0;

    void Start()
    {
        MaxEnemies = maxEnemies;
    }

    void OnEnable()
    {
        EnemySpawn.EnemySpawned += OnEnemySpawned;
        EnemyHealth.EnemyDead += OnEnemyDead;
    }

    void OnDisable()
    {
        EnemySpawn.EnemySpawned -= OnEnemySpawned;
        EnemyHealth.EnemyDead -= OnEnemyDead;
    }

    void OnEnemySpawned()
    {
        EnemyCount++;
    }

    void OnEnemyDead()
    {
        EnemyCount--;
    }

    public static bool CanSpawnEnemy()
    {
        return EnemyCount <= MaxEnemies;
    }
}
