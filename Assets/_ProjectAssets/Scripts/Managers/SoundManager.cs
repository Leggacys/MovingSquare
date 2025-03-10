using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{

    #region Singleton

    public static SoundManager instance;
    public bool soundOn, musicOn;

    private void Awake()
    {
        instance = FindObjectOfType<SoundManager>();
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion

    private AudioSource audioSource;
    public List<Constants.SoundClips> soundClipsList;
    public List<AudioClip> ambientSounds;
    

    private void OnEnable()
    {
        GameManager.onGameOver += PlayerDeathSound;
    }

    private void OnDisable()
    {
        GameManager.onGameOver -= PlayerDeathSound;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioSetup();
        
    }
    private void AudioSetup()
    {
        if (PlayerPrefs.GetInt("music") == 1)
        {
            musicOn = true;
            audioSource.clip = ambientSounds[Random.Range(0, ambientSounds.Count - 1)];
            GetComponent<AudioSource>().Play();
        }
        else
        {
            musicOn = false;
        }

        soundOn = PlayerPrefs.GetInt("sound") == 1;
    }

    public void PlaySoundEffect(Constants.Sounds soundName)
    {
        if (soundOn)
        {
          AudioClip clip = soundClipsList.Find(x => x.name == soundName).audioClip;
          audioSource.PlayOneShot(clip);
        }
        
    }

    public void PlayerDeathSound()
    {
        if (soundOn)
        {
            PlaySoundEffect(Constants.Sounds.PlayerDeath);
        }
    }
    
}
