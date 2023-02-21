using UnityEngine;
using System;

public class EnemyHealth : CharacterHealthBase
{
    [SerializeField]
    ParticleSystem _bloodParticle;
    AudioSource _audioSource;

    public static Action<AudioSource> InsertAudio;
    public static Action EnemySpawned;
    public static Action EnemyDead;

    void Start()
    {
        ChosenEnemy();
        _audioSource = GetComponent<AudioSource>();
        EnemySpawned?.Invoke();
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
        if(other.gameObject.CompareTag(Constants.Get.BULLET))
        {
            Instantiate(_bloodParticle, transform.position, Quaternion.identity);
            ReceiveDamage(1);
        }
    }
}
