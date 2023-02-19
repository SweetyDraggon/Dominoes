using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingHandler : MonoBehaviour
{

    public RectTransform settingpanel;
    public Image soundImage,musicImage, vibrationImage;
    public Sprite soundOn, soundoff;
    public Image[] tilesImages;
    public Sprite[] unSelectedTiles;
    public Sprite[] selectedTiles;
    public Image[] themesImages;
    public Sprite[] unSelectedThemes;
    public Sprite[] selectedThemes;
    public Image[] difficulityImages;
    public Sprite[] unSelectedDifficulity;
    public Sprite[] selectedDifficulity;
    public AudioSource BgMusic;
    public AudioSource ButtonClick;
    public GameObject settings;

    public Image[] tempDifficulity;
    // Start is called before the first frame update
    void Start()
    {

        updateMusicUI();
        updateSoundUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openSetting()
    {
        updateSoundUI();
        updateMusicUI();
       // updateVibrationUI();
        updateThemesUI();
        updateDifficulityUI();
        updateTempDifficulityUI();
        updateTilesUI();
        settingpanel.gameObject.SetActive(true);
    }
    public void updateSoundUI()
    {
        if (PlayerPrefs.GetInt("SOUND", 1) == 1)
        {
            soundImage.sprite = soundOn;
            ButtonClick.mute = false;
        }
        else
        {
            soundImage.sprite = soundoff;
            ButtonClick.mute = true;
        }
    }
    public void updateMusicUI()
    {
        if (PlayerPrefs.GetInt("MUSIC", 1) == 1)
        {
            musicImage.sprite = soundOn;
           
            BgMusic.mute = false;
        }
        else
        {
            musicImage.sprite = soundoff;
           
            BgMusic.mute = true;
        }
    }
    public void changeGameSound()
    {
        PlayerPrefs.SetInt("SOUND", -1 * PlayerPrefs.GetInt("SOUND", 1));
      //  SoundManager.instance.SetSound(PlayerPrefs.GetInt("SOUND", 1) ==1 ? 100f : 0f);
        updateSoundUI();
    }
    public void changeGameMusic()
    {
        PlayerPrefs.SetInt("MUSIC", -1 * PlayerPrefs.GetInt("MUSIC", 1));
       // SoundManager.instance.SetSound(PlayerPrefs.GetInt("MUSIC", 1) == 1 ? 100f : 0f);
        updateMusicUI(); 
    }
    //public void updateVibrationUI()
    //{
    //    if (PlayerPrefs.GetInt("vibration", 1) == 1)
    //    {
    //        vibrationImage.sprite = soundOn;
    //    }
    //    else
    //    {
    //        vibrationImage.sprite = soundoff;
    //    }
    //}
    //public void changeGameVibration()
    //{
    //    PlayerPrefs.SetInt("vibration", -1 * PlayerPrefs.GetInt("vibration", 1));
    //    updateVibrationUI();
    //}

    public void updateTilesUI()
    {
        for (int i = 0; i < tilesImages.Length; i++)
        {
            tilesImages[i].sprite = unSelectedTiles[i];
        }
        int value = PlayerPrefs.GetInt("TILES", 0);
        tilesImages[value].sprite = selectedTiles[value];
    }
    public void changeTile(int value)
    {
        PlayerPrefs.SetInt("TILES", value);
        updateTilesUI();
    }
    public void updateThemesUI()
    {
        
        for (int i = 0; i < themesImages.Length; i++)
        {
            themesImages[i].sprite = unSelectedThemes[i];
        }
        int value = PlayerPrefs.GetInt("BG", 0);
        themesImages[value].sprite = selectedThemes[value];
    }
    public void changeTheme(int value)
    {
        PlayerPrefs.SetInt("BG", value);
        updateThemesUI();
    }

    public void updateDifficulityUI()
    {

        for (int i = 0; i < difficulityImages.Length; i++)
        {
            difficulityImages[i].sprite = unSelectedDifficulity[i];
        }
        int value = PlayerPrefs.GetInt("ANIM", 0);
        difficulityImages[value].sprite = selectedDifficulity[value];
    }
    public void changeDifficulity(int value)
    {
        PlayerPrefs.SetInt("ANIM", value);
        if (value == 0)
        {
            PlayerPrefs.SetInt("target-score", 50);
        }
        else if (value == 1)
        {
            PlayerPrefs.SetInt("target-score", 100);
        }
        else
        {
            PlayerPrefs.SetInt("target-score", 150);
        }
        updateDifficulityUI();
    }

   

    public void updateTempDifficulityUI()
    {

        for (int i = 0; i < difficulityImages.Length; i++)
        {
            tempDifficulity[i].sprite = unSelectedDifficulity[i];
        }
        int value = PlayerPrefs.GetInt("tempDeficulity", 0);
        tempDifficulity[value].sprite = selectedDifficulity[value];
    }
    public void changeTempDifficulity(int value)
    {
        PlayerPrefs.SetInt("tempDeficulity", value);
        updateTempDifficulityUI();
    }
    public void closePanel(GameObject go)
    {
        go.SetActive(false);
    }

    
}
