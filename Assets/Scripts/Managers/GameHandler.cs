using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static Action GameOver;

    void Start()
    {
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        PlayerHealth.OnDead += DoGameOver;
        PlayerInputs.DontShoot += RestartScene;
    }

    void OnDisable()
    {
        PlayerHealth.OnDead -= DoGameOver;
        PlayerInputs.DontShoot -= RestartScene;
    }

    void RestartScene()
    {
        SceneManager.LoadScene(Constants.LEVEL_01);
    }

    void DoGameOver()
    {
        GameOver?.Invoke();
        Time.timeScale = 0;
    }
}
