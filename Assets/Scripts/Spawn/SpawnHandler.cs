using UnityEngine;

[RequireComponent(typeof(SpawnStorage))]
public class SpawnHandler : MonoBehaviour
{
    [SerializeField]
    int _maxEnemies;
    int _enemyCount = 0;
    SpawnStorage _spawnStorage;

    void Awake()
    {
        _spawnStorage = GetComponent<SpawnStorage>();
    }

    void OnEnable()
    {
        EnemyHealth.EnemyDead += OnEnemyDead;
        SpawnPoints.SpawnObject += OnSpawnObject;
        WeaponShoot.SpawnObject += OnSpawnObject;
        EnemyHealth.SpawnObject += OnSpawnObject;
    }

    void OnDisable()
    {
        EnemyHealth.EnemyDead -= OnEnemyDead;
        SpawnPoints.SpawnObject -= OnSpawnObject;
        WeaponShoot.SpawnObject -= OnSpawnObject;
        EnemyHealth.SpawnObject -= OnSpawnObject;
    }

    void OnEnemyDead()
    {
        _enemyCount--;
    }

    public bool CanSpawnEnemy()
    {
        return _enemyCount < _maxEnemies;
    }

    void OnSpawnObject(string objectName, Vector3 position , Quaternion rotation){
        var objectToSpawn = _spawnStorage.GetObject(objectName);

        if(objectToSpawn != null)
        {
            if(objectToSpawn.CompareTag(Constants.ENEMY) && CanSpawnEnemy())
            {
                _enemyCount++;
                Instantiate(objectToSpawn, position, rotation);
            }
            else if(!objectToSpawn.CompareTag(Constants.ENEMY))
            {
                Instantiate(objectToSpawn, position, rotation);
            }
        }
    }
}
