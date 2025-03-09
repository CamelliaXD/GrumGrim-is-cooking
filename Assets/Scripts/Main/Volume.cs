using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;

    private SoundManager soundManager;

        private void Start()
        {
            
            soundManager = FindObjectOfType<SoundManager>();

            if (soundManager == null)
            {
                Debug.LogError("SoundManager not found in the scene!");
                return;
            }


            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

            
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }

        public void SetMusicVolume(float volume)
        {
            if (soundManager != null)
            {
                soundManager.SetMusicVolume(volume);
            }
        }

        public void SetSFXVolume(float volume)
        {
            if (soundManager != null)
            {
                soundManager.SetSFXVolume(volume);
            }
        }
}
