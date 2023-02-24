using UnityEngine;
using System.Collections;
using System;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] Vector2 _timeToSpawn;
    [SerializeField] float _spawnRadius;
    [SerializeField] SpawnType _spawnType;
    [SerializeField] LayerMask _layerMask;
    Helper _helper;

    public static Action<string, Vector3, Quaternion> SpawnObject;

    void Start()
    {
        StartCoroutine(SpawnController());
        _helper = new Helper();
    }

    IEnumerator SpawnController()
    {
        var time = UnityEngine.Random.Range(_timeToSpawn.x, _timeToSpawn.y);
        yield return new WaitForSeconds(time);

        SpawnObject(Constants.ENEMY, FindPoisitionAround(), transform.rotation);

        StartCoroutine(SpawnController());
    }

    Vector3 FindPoisitionAround()
    {
        var position = _helper.RandomPosition(transform, _spawnRadius);
        Collider[] collider = Physics.OverlapSphere(position, 2f, _layerMask);
        return collider.Length > 0 ? FindPoisitionAround() : position;
    }

    void OnDrawGizmos() {
        Gizmos.color = new Color(1,1,0,0.5f);
        Gizmos.DrawSphere(transform.position, _spawnRadius);
    }
}
