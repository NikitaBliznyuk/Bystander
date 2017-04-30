using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene(2);

        ClearSave();
    }

    private void ClearSave()
    {
        PlayerPrefs.DeleteAll();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
