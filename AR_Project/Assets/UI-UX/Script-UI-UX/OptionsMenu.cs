using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public static bool OptionIsOpen = false;
    public static float volumeMusic = .5f;
    public static float volumeFx = .5f;
    public GameObject OptionMenuUI;
    public GameObject StartMenuUI;
    public Slider SliderMusic;
    public Slider SliderFx;
    public static OptionsMenu instance;

    public void Start() {
        // Debug.Log("GameStats.volumeMusic" + GameStats.volumeMusic);
        volumeMusic = GameStats.volumeMusic;
        volumeFx = GameStats.volumeFx;
        SetVolumeMusic(volumeMusic);
        SetVolumeFx(volumeFx);

        
        SliderMusic.value = volumeMusic;
        SliderFx.value = volumeFx;
       // DontDestroyOnLoad(this);

    }

    public float GetVolumeMusic()
    {
        return SliderMusic.value;
    }
    public float GetVolumeFx()
    {
        return SliderFx.value;
    }

    public void OpenOptionMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click1");
        OptionMenuUI.SetActive(true);
        StartMenuUI.SetActive(false);

        FindObjectOfType<AudioManager>().Pause("Minecraft theme");
        FindObjectOfType<AudioManager>().Play("Mii theme");
        Time.timeScale = 0f;
        OptionIsOpen = true;
    }
    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("Click2");
        OptionMenuUI.SetActive(false);
        StartMenuUI.SetActive(true);

        FindObjectOfType<AudioManager>().Play("Minecraft theme");
        FindObjectOfType<AudioManager>().Pause("Mii theme");

        Time.timeScale = 1f;
        OptionIsOpen = false;
        PauseMenu.GameIsPaused = true;
    }

    public void SetVolumeMusic( float volume) {
        volumeMusic = volume;
        SliderMusic.value = volume;
        GameStats.setVolumeMusic(volume);
        Sounds[] sounds = FindObjectOfType<AudioManager>().getAllSounds();
        foreach (Sounds s in sounds)
        {
            if (!s.fx)
            {
                s.source.volume = volume;
            }
        }
    }

    public void SetVolumeFx(float volume)
    {
        volumeFx = volume;
        SliderFx.value = volumeFx;
        GameStats.setVolumeFx(volume);
        Sounds[] sounds = FindObjectOfType<AudioManager>().getAllSounds();
        foreach (Sounds s in sounds)
        {
            if (s.fx)
            {
                s.source.volume = volume;
            }
        }
    }
}
