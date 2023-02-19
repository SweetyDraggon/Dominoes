/// <summary Created by:>
/// Semionov Alexey; Qplaze; 2021;
/// </summary>

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LocalisedUIText))]
public class LocalisedUITextEditor : Editor
{
    bool isRussian = false;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LocalisedUIText localisedUI = (LocalisedUIText)target;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Добавление в: " + (isRussian ? SystemLanguage.Russian : SystemLanguage.English));//Изначально доступны только эти 2, да и врядли когда то понадобится использовать другие языки
        if(GUILayout.Button("Поменять язык"))
        {
            isRussian = !isRussian;
        }

        EditorGUILayout.EndHorizontal();


        string text = localisedUI.GetText();
        if(Event.current.type != EventType.DragPerform && !string.IsNullOrEmpty(text))
        {
            if(GUILayout.Button("Добавить текст в xml"))
            {
                LocalisationUtility.AddAliasAndLocalisationToXML(text, isRussian ? SystemLanguage.Russian : SystemLanguage.English);
            }
        }
    }	
}
