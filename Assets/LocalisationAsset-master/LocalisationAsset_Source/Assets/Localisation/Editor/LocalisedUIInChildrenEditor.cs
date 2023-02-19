/// <summary Created by:>
/// Semionov Alexey; Qplaze; 2020;
/// </summary>

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LocalisedUIInChildren))]
public class LocalisedUIInChildrenEditor : Editor
{
    bool isRussian = false;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LocalisedUIInChildren localisedUI = (LocalisedUIInChildren)target;
        
        if(GUILayout.Button("Добавить дочеркние текста"))
        {
            localisedUI.AddChildTexts();
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Добавление в: " + (isRussian ? SystemLanguage.Russian : SystemLanguage.English));//Изначально доступны только эти 2, да и врядли когда то понадобится использовать другие языки
		if(GUILayout.Button("Поменять язык"))
        {
            isRussian = !isRussian;
        }

        EditorGUILayout.EndHorizontal();


		string[] texts = localisedUI.GetTexts();
		if(Event.current.type != EventType.DragPerform && texts.Length > 0)
		{
			if(GUILayout.Button("Добавить текста в xml"))
			{
                LocalisationUtility.AddAliasAndLocalisationToXML(texts, isRussian ? SystemLanguage.Russian : SystemLanguage.English);
			}
		}
	}
	
}
