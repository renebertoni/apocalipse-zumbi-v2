using UnityEngine;
using System;

public class EnemyHealth : CharacterHealthBase
{
    [SerializeField]
    private ParticleSystem _bloodParticle;
    private AudioSource _audioSource;

    public static Action<AudioSource> InsertAudio;
    public static Action EnemySpawned;
    public static Action EnemyDead;

    private void Start(){
        ChosenEnemy();
        _audioSource = GetComponent<AudioSource>();
        EnemySpawned?.Invoke();
        InsertAudio?.Invoke(_audioSource);
    }

    public override void Die(){
        EnemyDead?.Invoke();
        InsertAudio?.Invoke(_audioSource);

        Destroy(this.gameObject);
    }

    private void ChosenEnemy(){
       int enemyTypes = transform.childCount;
       var chosenEnemy = transform.GetChild(UnityEngine.Random.Range(1, enemyTypes));
       chosenEnemy.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag(Constants.Get.BULLET)){
            Instantiate(_bloodParticle, transform.position, Quaternion.identity);
            ReceiveDamage(1);
        }
    }
}
