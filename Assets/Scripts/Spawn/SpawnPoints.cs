using UnityEngine;
using System.Collections;
using System;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField]
    Vector2 _timeToSpawn;
    [SerializeField]
    SpawnType _spawnType;

    public static Action<string, Transform> SpawnObject;

    void Start()
    {
        StartCoroutine(SpawnController());
    }

    IEnumerator SpawnController()
    {
        var time = UnityEngine.Random.Range(_timeToSpawn.x, _timeToSpawn.y);
        yield return new WaitForSeconds(time);
        SpawnObject(Constants.Get.ENEMY, transform);

        StartCoroutine(SpawnController());
    }
}
