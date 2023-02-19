using UnityEngine;

public class UIHandler : MonoBehaviour
{
    GameObject gameOver;

    void Awake()
    {
        gameOver = GameObject.Find(Constants.Get.GAME_OVER_BACKGROUND);
        gameOver.SetActive(false);
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
        gameOver.SetActive(true);
    }
}
