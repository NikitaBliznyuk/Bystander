using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
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
            SceneManager.LoadScene("Main menu");
        }
    }
}
