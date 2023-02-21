using System.Collections;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float _speed;
    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
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
        yield return new WaitUntil(() => !_audioSource.isPlaying );
        Destroy(this.gameObject);
    }
}
