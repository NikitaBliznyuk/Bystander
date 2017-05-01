using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float BackgroundMusic;

    public AudioClip[] MenuMusic;
    public AudioClip[] GameMusic;

    private AudioSource currentClip;
    private AudioClip[] currentPlaylist;
    private int currentIndex;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        currentClip = GetComponent<AudioSource>();
        currentPlaylist = MenuMusic;
        currentIndex = currentPlaylist.Length;

        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnSceneChanged(Scene previous, Scene current)
    {
        switch(current.buildIndex)
        {
            case 1:
                currentPlaylist = MenuMusic;
                break;
            case 2:
                currentPlaylist = GameMusic;
                break;
        }

        currentClip.clip = currentPlaylist[0];
        currentClip.Play();
    }

    private void Update()
    {
        foreach(var clip in currentPlaylist)
        {
            currentClip.volume = BackgroundMusic;
        }

        if(!currentClip.isPlaying)
        {
            currentIndex = currentIndex >= currentPlaylist.Length - 1 ? 0 : currentIndex + 1;
            currentClip.clip = currentPlaylist[currentIndex];
            currentClip.Play();
        }
    }
}
