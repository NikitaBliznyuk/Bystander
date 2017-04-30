using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    private bool enabled = false;
    private GameObject menu;

    private void Start()
    {
        menu = GetComponentsInChildren<RectTransform>()[1].gameObject;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            enabled = !enabled;
        }

        menu.SetActive(enabled);
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
