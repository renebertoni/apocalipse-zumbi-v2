using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(Constants.LEVEL_01);
    }
}
