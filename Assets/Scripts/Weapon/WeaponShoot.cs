using UnityEngine;
using System;

public class WeaponShoot : MonoBehaviour
{
    Transform _bulletPoint;
    
    public static Action<string, Vector3, Quaternion> SpawnObject;
    
    void Start()
    {
        _bulletPoint = transform.Find(Constants.BULLET_POSITION);
    }

    void OnEnable()
    {
        PlayerInputs.OnShoot += DoShoot;
    }

    void OnDisable()
    {
        PlayerInputs.OnShoot -= DoShoot;
    }

    void DoShoot()
    {
        if(_bulletPoint)
        {
            SpawnObject?.Invoke(Constants.BULLET, _bulletPoint.position, _bulletPoint.rotation);
        }
    }
}
