using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public float BackgroundMusic { set; get; }
    public float SoundEffects { set; get; }
    public float General { set; get; }

    public AudioClip[] MenuMusic;
    public AudioClip[] GameMusic;

    private AudioSource currentClip;
    private AudioClip[] currentPlaylist;
    private int currentIndex;

    private AudioSource steps;

    private void Awake()
    {
        BackgroundMusic = 1.0f;
        SoundEffects = 0.1f;
        General = 1.0f;
    }

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
                steps = FindObjectOfType<BaseMotor>().GetComponent<AudioSource>();
                break;
        }

        currentClip.clip = currentPlaylist[0];
        currentClip.Play();
    }

    private void Update()
    {
        currentClip.volume = BackgroundMusic * General;
        if(steps != null)
            steps.volume = SoundEffects * General;

        if (!currentClip.isPlaying)
        {
            currentIndex = currentIndex >= currentPlaylist.Length - 1 ? 0 : currentIndex + 1;
            currentClip.clip = currentPlaylist[currentIndex];
            currentClip.Play();
        }
    }
}
