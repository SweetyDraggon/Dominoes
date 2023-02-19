using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalisedUIText : MonoBehaviour {

	private void Start ()
	{
		Text text = GetComponent<Text>();
		if (text != null)
		{
			text.text = Localisation.GetString(text.text, gameObject);
		}
    }
#if UNITY_EDITOR

    string text;

    private void OnValidate()
    {
        text = GetComponent<Text>().text;
        if(string.IsNullOrEmpty(text))
        {
            Debug.LogError("Пустой текст! ", this);
        }        
    }
    public string GetText()
    {        
        return text;
    }
#endif
}

