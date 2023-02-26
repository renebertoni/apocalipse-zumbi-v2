using UnityEngine;
using System;
using UnityEngine.AI;

public class EnemyHealth : CharacterHealthBase
{
    // float _timeTODestroy = 6f;
    AudioSource _audioSource;

    public static Action EnemyDead;
    public static Action<AudioSource> InsertAudio;
    public static Action<string, Vector3, Quaternion> SpawnObject;

    void Start()
    {
        ChosenEnemy();
        _audioSource = GetComponent<AudioSource>();
        InsertAudio?.Invoke(_audioSource);
    }

    public override void Die()
    {
        EnemyDead?.Invoke();
        InsertAudio?.Invoke(_audioSource);
        _animator.SetInteger(Constants.DIE_ANIMATION, UnityEngine.Random.Range(1,3));
        _animator.SetTrigger(Constants.DIE);
        DisableAllComponents();
        // Destroy(this.gameObject, _timeTODestroy);
    }

    void ChosenEnemy()
    {
       int enemyTypes = transform.childCount;
       var chosenEnemy = transform.GetChild(UnityEngine.Random.Range(1, enemyTypes));
       chosenEnemy.gameObject.SetActive(true);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag(Constants.BULLET))
        {
            SpawnObject?.Invoke(Constants.BLOOD, transform.position, transform.rotation);
            ReceiveDamage(1);
        }
    }

    void DisableAllComponents()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        GetComponent<AudioSource>().enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
    }
}
