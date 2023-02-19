using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalisationString : MonoBehaviour
{
    [TextArea(3, 9)] public string rawString = null;

    public Text thistext;



    void Start()
    {
        thistext = this.gameObject.GetComponent<Text>();

    }

    void LateUpdate()
    {
        thistext.text = Localisation.GetString(rawString, gameObject); ;
    
    }
}
