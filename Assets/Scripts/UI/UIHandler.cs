using UnityEngine;

public class UIHandler : MonoBehaviour
{
    GameObject _gameOver;

    void Awake()
    {
        _gameOver = GameObject.Find(Constants.Get.GAME_OVER_BACKGROUND);
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
}
