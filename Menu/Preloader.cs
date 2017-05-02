using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    public GameObject audioController;

    [SerializeField]
    private float fadeTime = 2.0f;

    private void Start()
    {
        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        var currentTime = 0.0f;

        while(currentTime < fadeTime)
        {
            yield return null;
            currentTime += Time.deltaTime;
        }
        
        Instantiate(audioController);
        SceneManager.LoadScene("Main menu");

        yield return null;
    }
}
