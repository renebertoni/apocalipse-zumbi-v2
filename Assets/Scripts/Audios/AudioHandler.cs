using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioStorage))]
public class AudioHandler : MonoBehaviour
{
    List<AudioSource> _audioSources = new List<AudioSource>();
    AudioSource _sfxAudioSource;
    AudioStorage _audioStorage;

    void Awake()
    {
        _audioStorage = GetComponent<AudioStorage>();
    }

    void Start()
    {
        _sfxAudioSource = GameObject.Find("SFX")?.GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        EnemyHealth.InsertAudio += OnInsertAudio;
        GameHandler.GameOver += DoGameOver;
        EnemyAttack.PlayAudio += PlayAudio;
        BulletMovement.PlayAudio += PlayAudio;
    }

    void OnDisable()
    {
        EnemyHealth.InsertAudio -= OnInsertAudio;
        GameHandler.GameOver -= DoGameOver;
        EnemyAttack.PlayAudio -= PlayAudio;
        BulletMovement.PlayAudio += PlayAudio;
    }

    void PlayAudio(string audioName)
    {
        var audio = _audioStorage.GetAudio(audioName);

        if(_sfxAudioSource != null && audio != null)
        {
            _sfxAudioSource.PlayOneShot(audio);
        } 
    }

    void OnInsertAudio(AudioSource audioSource)
    {
        if(audioSource != null)
        {
            if(!_audioSources.Contains(audioSource))
            {
                _audioSources.Add(audioSource);
            }
            else
            {
                _audioSources.Remove(audioSource);
                ClearVoidsFromList();
            }
        }
    }

    void ClearVoidsFromList()
    {
        _audioSources.RemoveAll(item => !item);
    }

    void DoGameOver()
    {
        foreach (var item in _audioSources)
        {
            item.Stop();
        }
    }
}
