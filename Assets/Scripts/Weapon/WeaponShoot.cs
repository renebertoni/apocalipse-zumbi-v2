using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    Transform bulletPoint;
    GameObject bullet;
    
    void Start()
    {
        bulletPoint = transform.Find(Constants.Get.BULLET_POSITION);
        bullet = Resources.Load<GameObject>(Constants.Get.BULLET);
    }

    void OnEnable()
    {
        PlayerInputs.Shoot += DoShoot;
    }

    void OnDisable()
    {
        PlayerInputs.Shoot -= DoShoot;
    }

    void DoShoot()
    {
        if(bulletPoint){
            var newBullet = GameObject.Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
        }
    }
}
