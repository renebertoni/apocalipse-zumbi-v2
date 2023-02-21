using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    Transform _bulletPoint;
    GameObject _bullet;
    
    void Start()
    {
        _bulletPoint = transform.Find(Constants.Get.BULLET_POSITION);
        _bullet = Resources.Load<GameObject>(Constants.Get.BULLET);
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
            var newBullet = GameObject.Instantiate(_bullet, _bulletPoint.position, _bulletPoint.rotation);
        }
    }
}
