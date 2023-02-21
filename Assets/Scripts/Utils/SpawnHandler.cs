using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField]
    int _maxEnemies;

    public static int MaxEnemies;
    public static int EnemyCount = 0;

    void Start()
    {
        MaxEnemies = _maxEnemies;
    }

    void OnEnable()
    {
        EnemyHealth.EnemySpawned += OnEnemySpawned;
        EnemyHealth.EnemyDead += OnEnemyDead;
    }

    void OnDisable()
    {
        EnemyHealth.EnemySpawned -= OnEnemySpawned;
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
