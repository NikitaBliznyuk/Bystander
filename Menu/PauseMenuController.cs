using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    private bool isEnabled = false;
    private GameObject menu;

    private void Start()
    {
        menu = GetComponentsInChildren<RectTransform>()[1].gameObject;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isEnabled = !isEnabled;
        }

        menu.SetActive(isEnabled);
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
