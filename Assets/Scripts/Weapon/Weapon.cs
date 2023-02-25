using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    Transform _bulletPoint;
    
    public static Action<string, Vector3, Quaternion> SpawnObject;
    
    void Start()
    {
        _bulletPoint = transform.Find(Constants.BULLET_POSITION);
    }

    void OnEnable()
    {
        PlayerInputs.Shoot += OnShoot;
    }

    void OnDisable()
    {
        PlayerInputs.Shoot -= OnShoot;
    }

    void OnShoot()
    {
        if(_bulletPoint)
        {
            SpawnObject?.Invoke(Constants.BULLET, _bulletPoint.position, _bulletPoint.rotation);
        }
    }
}
