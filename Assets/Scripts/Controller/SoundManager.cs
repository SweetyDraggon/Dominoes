﻿using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    public List<AudioSource> AllSound = new List<AudioSource>();
    public enum SoundIngame
    {
        FlipCard,
        MatchCard,
        MatchJoker,
        AddStar,
        OpenPopup,
        NoMatch,
        Win,
        Lose,
        Click
    }

    public float currentSound = 1f;
    public float currentMusic = 1f;

    public void SoundOn(SoundIngame soundEnum)
    {
        int index = (int)soundEnum;
        if (index <= AllSound.Count)
        {
            if (AllSound[index].isPlaying)
                AllSound[index].Stop();

            AllSound[index].volume = currentSound;
            AllSound[index].Play();
        }
    }

    public string MUSIC_VOLUME = "MUSIC_VOLUME";
    public string SOUND_VOLUME = "SOUND_VOLUME";
    public AudioSource BgMusic, ClickBtn;

    public static SoundManager instance;
    void Awake()
    {
        SoundManager.instance = this;
     //   SetInitData();
    }

    void Start()
    {
        IsOnMusic();
    }

    public void IsOnMusic()
    {
        BgMusic.Play();
        if (PlayerPrefs.GetInt("MUSIK", 1) != 1)
        {
            BgMusic.mute = true;
        }
    }

    //private void SetInitData()
    //{
    //    if (!PlayerPrefs.HasKey(MUSIC_VOLUME))
    //    {
    //        PlayerPrefs.SetFloat(MUSIC_VOLUME, 1);
    //    }

    //    if (!PlayerPrefs.HasKey(SOUND_VOLUME))
    //    {
    //        PlayerPrefs.SetFloat(SOUND_VOLUME, 1);
    //    }
    //    currentSound = PlayerPrefs.GetFloat(SOUND_VOLUME);
    //    currentMusic = PlayerPrefs.GetFloat(MUSIC_VOLUME);
    //}

    //public void SetMusic(float value)
    //{
    //    PlayerPrefs.SetFloat(MUSIC_VOLUME, value);
    //    currentMusic = value;
    //    BgMusic.volume = 1;
    //}

    //public void SetSound(float value)
    //{
    //    PlayerPrefs.SetFloat(SOUND_VOLUME, 1);
    //    currentSound = 1;
    //}
}
