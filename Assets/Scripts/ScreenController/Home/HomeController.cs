using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HomeController : MonoBehaviour {

    private CanvasGroup Home;
    public bool IsShowScreen;
    public GameObject QuitGame;
	public GameObject QuitGame2;

    void Awake()
    {
        Home = GetComponent<CanvasGroup>();
    }


    public void ShowHome()
    {
        QuitGame2.SetActive(true);
        this.transform.localScale = new Vector3(SceneManager.instance.Ratio, 1f, 1f);
        IsShowScreen = true;
        Home.alpha = 1;
        Home.blocksRaycasts = true;
        this.gameObject.transform.localPosition = Vector2.zero;
        //var IsSoundOn = !PlayerPrefs.HasKey("SOUND") || PlayerPrefs.GetInt("SOUND") == 1;
        //SoundManager.instance.SetMusic(IsSoundOn ? 100f : 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (QuitGame.activeInHierarchy == true)
            {
                SceneManager.instance.HomeController.HideQuitGame2();
            }
        }
        if (IsShowScreen)
        {
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
			//	SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
                //if (QuitGame2.gameObject.activeSelf)
                //{
                //    HideQuitGame2(); LoadMode();
                //}
                //else
            //        QuitGame2.SetActive(true);
            //}
            //if (Input.GetKeyDown(KeyCode.Escape) && QuitGame2.activeInHierarchy)
            //{

            //    HideQuitGame2();
            //}

        }
    }

   

    public void HideHome()
    {
        IsShowScreen = false;
        Home.alpha = 0;
        Home.blocksRaycasts = false;
        this.gameObject.transform.localPosition = new Vector2(10000, 10000);
    }

    public void OnPlayClick()
    {
        if (SceneManager.instance.CanShowIntertitialBanner())
        {
            SceneManager.instance.LoadToLevelScene = true;
            SceneManager.instance.ShowIntertitialBanner();
        }
        else
        {
            LoadMode();
        }
        SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
    }

    public void LoadMode()
    {
        HideHome();
        SceneManager.instance.ModeController.ShowMode();
    }

    public void OnMoreGameClick()
    {
        SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
#if UNITY_ANDROID
        Application.OpenURL("market://search?id=" + Application.companyName + "");
#endif
    }

    public void HideQuitGame()
    {
        SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
        QuitGame2.SetActive(false);

        SceneManager.instance.ModeController.ShowMode();

        if (SceneManager.instance.CanShowIntertitialBanner())
        {
            SceneManager.instance.LoadToLevelScene = true;
            SceneManager.instance.ShowIntertitialBanner();
        }
        else
        {
            LoadMode();
        }
        SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);





        //QuitGame.SetActive(false);
        //SceneManager.instance.ModeController.ShowMode();
        //if (SceneManager.instance.CanShowIntertitialBanner())
        //{
        //    SceneManager.instance.LoadToLevelScene = true;
        //    SceneManager.instance.ShowIntertitialBanner();
        //}
        //else
        //{
        //    LoadMode();
        //}
        //SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
    }

	public void HideQuitGame2()
	{
		SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
		QuitGame2.SetActive(false);

        SceneManager.instance.ModeController.ShowMode();

        if (SceneManager.instance.CanShowIntertitialBanner())
        {
            SceneManager.instance.LoadToLevelScene = true;
            SceneManager.instance.ShowIntertitialBanner();
        }
        else
        {
            LoadMode();
        }
        SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
    }

    public void OnQuitGameClick()
    {
		SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
        Application.Quit();
    }

    public void OnRuleClick()
    {
		SoundManager.instance.SoundOn(SoundManager.SoundIngame.Click);
        HideHome();
        SceneManager.instance.RulesController.ShowMode();
    }
}
