using UnityEngine;
using System;

public class WeaponShoot : MonoBehaviour
{
    Transform _bulletPoint;
    
    public static Action<string, Transform> SpawnObject;
    
    void Start()
    {
        _bulletPoint = transform.Find(Constants.Get.BULLET_POSITION);
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
            SpawnObject?.Invoke(Constants.Get.BULLET, _bulletPoint);
        }
    }
}
