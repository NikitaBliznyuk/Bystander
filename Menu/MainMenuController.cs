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
    [SerializeField]
    private Slider effects;
    [SerializeField]
    private Slider general;
    [SerializeField]
    private Toggle fullscreen;

    private AudioManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<AudioManager>();

        backgroundMusic.value = manager.BackgroundMusic;
        effects.value = manager.SoundEffects;
        general.value = manager.General;
        fullscreen.isOn = Screen.fullScreen;
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
        manager.SoundEffects = effects.value;
        manager.General = general.value;
    }

    public void SetFullscreenMode(bool on)
    {
        Screen.fullScreen = on;
    }
}
