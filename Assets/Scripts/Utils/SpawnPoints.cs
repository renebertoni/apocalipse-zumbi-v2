using UnityEngine;
using System.Collections;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField]
    Vector2 _timeToSpawn;
    [SerializeField]
    SpawnType _spawnType;
    GameObject _objetcToSpawn;
    float _time;

    void Start()
    {
        _objetcToSpawn = ChooseObject();
        StartCoroutine(SpawnController());
    }

    IEnumerator SpawnController()
    {
        _time = Random.Range(_timeToSpawn.x, _timeToSpawn.y);
        yield return new WaitForSeconds(_time);
        if(SpawnHandler.CanSpawnEnemy())
        {
            Instantiate(_objetcToSpawn, transform.position, Quaternion.identity);
        }
        StartCoroutine(SpawnController());
    }

    GameObject ChooseObject()
    {
        switch(_spawnType)
        {
            case SpawnType.Enemy:
                return Resources.Load<GameObject>(Constants.Get.ENEMY);
            default:
                return Resources.Load<GameObject>(Constants.Get.ENEMY);
        }
    }
}
