using UnityEngine;
using System;

public class UI_Handler : MonoBehaviour
{
    GameObject _gameOver;
    public static Action Restart;

    void Awake()
    {
        _gameOver = GameObject.Find(Constants.GAME_OVER_BACKGROUND);
        _gameOver.SetActive(false);
    }

    void OnEnable()
    {
        GameHandler.GameOver += DoGameOver;
    }
    void OnDisable()
    {
        GameHandler.GameOver -= DoGameOver;
    }

    void DoGameOver()
    {
        _gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        Restart?.Invoke();
    }
}
