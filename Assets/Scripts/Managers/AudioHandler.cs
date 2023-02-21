using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    List<AudioSource> _audioSources = new List<AudioSource>();

    void OnEnable()
    {
        EnemyHealth.InsertAudio += OnInsertAudio;
        GameHandler.GameOver += DoGameOver;
    }

    void OnDisable()
    {
        EnemyHealth.InsertAudio -= OnInsertAudio;
        GameHandler.GameOver -= DoGameOver;
    }

    void OnInsertAudio(AudioSource audioSource)
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
