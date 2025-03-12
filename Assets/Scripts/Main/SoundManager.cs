using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f;
}

    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ทำให้ SoundManager คงอยู่ตลอดเกม
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp(volume, 0f, 1f);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp(volume, 0f, 1f);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
}

