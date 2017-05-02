using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public bool IsEnabled { private set; get; }
    private GameObject menu;

    private void Start()
    {
        IsEnabled = false;
        menu = GetComponentsInChildren<RectTransform>()[1].gameObject;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsEnabled = !IsEnabled;
        }

        menu.SetActive(IsEnabled);
    }

    public void Continue()
    {
        IsEnabled = false;
        menu.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
