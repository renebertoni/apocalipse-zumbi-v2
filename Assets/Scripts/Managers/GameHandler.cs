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
        UI_Handler.Restart += RestartScene;
    }

    void OnDisable()
    {
        PlayerHealth.OnDead -= DoGameOver;
        UI_Handler.Restart -= RestartScene;
    }

    void RestartScene()
    {
        SceneManager.LoadScene(Constants.LEVEL_01);
    }

    void DoGameOver()
    {
        Time.timeScale = 0;
        GameOver?.Invoke();
    }
}
