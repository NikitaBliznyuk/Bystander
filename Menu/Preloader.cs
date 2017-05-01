using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    public GameObject audioController;

    private float fadeTime = 2.0f;
    private float currentTime = 0.0f;
    
    private void Update()
    {
        if (currentTime < fadeTime)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            Instantiate(audioController);
            SceneManager.LoadScene("Main menu");
        }
    }
}
