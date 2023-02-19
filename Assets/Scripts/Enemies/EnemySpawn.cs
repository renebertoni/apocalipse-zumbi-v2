using UnityEngine;
using System;

public class EnemySpawn : MonoBehaviour
{
    public static Action<AudioSource> SetAudioSource;
    public static Action EnemySpawned;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        EnemySpawned?.Invoke();
        SetAudioSource?.Invoke(audioSource);
    }

    void OnEnable() {
        EnemyHealth.EnemyDead += OnEnemyDead;
    }

    void OnDisable() {
        EnemyHealth.EnemyDead -= OnEnemyDead;
    }

    void OnEnemyDead(){
        SetAudioSource?.Invoke(audioSource);
    }
}
