using UnityEngine;
using System;

public class EnemyHealth : CharacterHealthBase
{
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

        Destroy(this.gameObject);
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
}
