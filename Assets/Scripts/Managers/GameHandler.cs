using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static Action GameOver;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        EnemyAttackTrigger.Hit += DoGameOver;
        PlayerInputs.DontShot += RestartScene;
    }

    void OnDisable()
    {
        EnemyAttackTrigger.Hit -= DoGameOver;
        PlayerInputs.DontShot -= RestartScene;
    }

    void RestartScene()
    {
        SceneManager.LoadScene(Constants.Get.LEVEL_01);
    }

    void DoGameOver()
    {
        GameOver?.Invoke();
        Time.timeScale = 0;
    }
}
