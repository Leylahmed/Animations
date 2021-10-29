using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSFXManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;

    [SerializeField] private Slider soundSlider;

    [SerializeField] private AudioSource backgroundMusicSource;

    [SerializeField] private AudioSource SoundSource;

    [SerializeField] private AudioSource[] sfxSource;

    [SerializeField] private Toggle musicToggle;

    [SerializeField] private Toggle soundToggle;

    private float musicRef;
    private float soundRef;



    private void Start()
    {
        musicSlider.value = MainMenuManager.instance.playerData.musicVolume;

        soundSlider.value = MainMenuManager.instance.playerData.soundVolume;

        if(MainMenuManager.instance.playerData .isMusicOn)
        {
            backgroundMusicSource.mute = false;
            musicToggle.isOn = true;
        }
        else
        {
            musicToggle.isOn = false;
            onMusicToggleChanged(false);
        }

        if (MainMenuManager.instance.playerData.isSoundOn)
        {
            SoundSource.mute = false;
            soundToggle.isOn = true;
        }
        else
        {
            SoundSource.mute = true;
            soundToggle.isOn = false;
        }
    }

    public void onMusicVolumeChanged(float value)
    {
        MainMenuManager.instance.playerData.musicVolume = value;

        backgroundMusicSource.volume = value;
    }

    public void onSoundVolumeChanged(float value)
    {
        MainMenuManager.instance.playerData.soundVolume = value;

        foreach (AudioSource source in sfxSource)
        {
            source.volume = value;
        }
    }

    public void onMusicToggleChanged(bool toggleValue)
    {
        if (toggleValue)
        {
            backgroundMusicSource.mute = false;
        }

        else
        {
            backgroundMusicSource.mute = true;
        }

        MainMenuManager.instance.playerData.isMusicOn = toggleValue;
    }

    public void onSoundToggleChanged(bool toggleValue)
    {
        if (toggleValue)
        {
            SoundSource.mute = false;
        }

        else
        {
            SoundSource.mute = true;

        }

        MainMenuManager.instance.playerData.isSoundOn = toggleValue;
    }
}
