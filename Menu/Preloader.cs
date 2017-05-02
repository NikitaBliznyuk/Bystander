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
        yield return new WaitForSeconds(fadeTime);

        Instantiate(audioController);
        SceneManager.LoadScene("Main menu");

        yield return null;
    }
}
