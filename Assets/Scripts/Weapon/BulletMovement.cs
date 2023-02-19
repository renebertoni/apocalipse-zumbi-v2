using System.Collections;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 10;
    Collider bulletCollider;
    AudioSource audioSource;
    Rigidbody bulletRigidbody;
    MeshRenderer mesh;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        StartCoroutine(DestroyBullet());
    }

    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
    
    void OnCollisionEnter(Collision other)
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().detectCollisions = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitUntil(() => !audioSource.isPlaying );
        Destroy(this.gameObject);
    }
}
