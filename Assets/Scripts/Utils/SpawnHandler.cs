using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField]
    private int _maxEnemies;

    public static int MaxEnemies;
    public static int EnemyCount = 0;

    private void Start(){
        MaxEnemies = _maxEnemies;
    }

    private void OnEnable(){
        EnemyHealth.EnemySpawned += OnEnemySpawned;
        EnemyHealth.EnemyDead += OnEnemyDead;
    }

    private void OnDisable(){
        EnemyHealth.EnemySpawned -= OnEnemySpawned;
        EnemyHealth.EnemyDead -= OnEnemyDead;
    }

    private void OnEnemySpawned(){
        EnemyCount++;
    }

    private void OnEnemyDead(){
        EnemyCount--;
    }

    public static bool CanSpawnEnemy(){
        return EnemyCount <= MaxEnemies;
    }
}
