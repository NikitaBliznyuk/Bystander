using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject baseMenu;
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private Slider backgroundMusic;

    private AudioManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<AudioManager>();

        backgroundMusic.value = manager.BackgroundMusic;
    }

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

    public void OpenSettings(bool on)
    {
        baseMenu.SetActive(!on);
        settings.SetActive(on);
    }

    public void ChangeMusicVolume()
    {
        manager.BackgroundMusic = backgroundMusic.value;
    }
}
