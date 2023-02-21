using System.Collections;
using UnityEngine;
using System;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float _speed;
    [SerializeField]
    float lifeTime;
    AudioSource _audioSource;

    public static Action<string> PlayAudio;

    void Start()
    {
        PlayAudio?.Invoke(Constants.Get.WEAPON_SHOOT);
        StartCoroutine(DestroyBullet());
    }

    void FixedUpdate()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime, Space.World);
    }
    
    void OnCollisionEnter(Collision other)
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().detectCollisions = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }
}
