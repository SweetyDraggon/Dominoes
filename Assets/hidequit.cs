using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidequit : MonoBehaviour
{
    public GameObject QuitGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (QuitGame.activeInHierarchy == true)
            {
                SceneManager.instance.HomeController.HideQuitGame2();
            }
        }
    }
}
