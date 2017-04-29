using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("Island");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
