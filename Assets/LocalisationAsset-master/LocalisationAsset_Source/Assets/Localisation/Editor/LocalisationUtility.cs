/// <summary Created by:>
/// Semionov Alexey; Qplaze; 2021;
/// </summary>

using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;


public static class LocalisationUtility
{
#if UNITY_EDITOR
	//public static List<string> texts = new List<string>();

  //  public static void AddTextToList(string txt)
  //  {
  //      if(string.IsNullOrEmpty(txt)) return;

		//if(texts.Contains(txt))
  //      {
		//	Debug.Log("Повтор текста: " + txt);
		//	return;
		//}

  //      texts.Add(txt);

  //      if(texts.Count >= 124)//Количество элементов
  //      {
  //          AddAliasAndLocalisationToXML(texts.ToArray(), SystemLanguage.Russian);
  //          texts.Clear();
  //      }
  //  }

    public static void AddAliasAndLocalisationToXML(string[] sourceTexts, SystemLanguage lang)
	{
		//ВАЖНО!! Возможна ошибка когда на один и тот же алиас имеются разные текста.

		//Загружаем имеющийся документ
		XmlDocument xmlDoc = new XmlDocument();
		TextAsset langAsset = Resources.Load<TextAsset>("Localisation/" + lang);
		xmlDoc.LoadXml(langAsset.text);

		//Добавляем все имеющиеся в документе алиасы в HashSet. Нужно что бы не добавлять имеющиеся алиасы.
		XmlElement root = xmlDoc.DocumentElement;
		XmlNodeList nodes = root.SelectNodes("//string"); //ignore all nodes but <string> 
		HashSet<string> dict = new HashSet<string>();

		foreach(XmlNode node in nodes)
		{
			string key = node.Attributes["name"].Value;
			if(!dict.Contains(key))
			{
				dict.Add(key);
			}

		}

		XmlNode rootNode = xmlDoc.GetElementsByTagName("document")[0];

		//int i = 0;//Нужно для более краткого наименования
		foreach(var txt in sourceTexts)//Добавляем новые алиасы и текст в загруженый документ
		{
			if(!dict.Contains(txt))//Проверяем что бы не доавлялись алиасы которые уже есть
			{
				XmlNode node = xmlDoc.CreateElement("string");
				XmlAttribute attribute = xmlDoc.CreateAttribute("name");
				//attribute.Value = "ID"+i;
				attribute.Value = txt;
				node.Attributes.Append(attribute);
				var value = txt;
				node.InnerText = value;
				rootNode.AppendChild(node);
				//i++;

				dict.Add(txt);//Добавляем новый алиас в словарь, что бы избижать повторений
							  //ВАЖНО!! Возможна ошибка когда на один и тот же алиас имеются разные текста.
			}
			else
			{
				Debug.Log("Повтор текста: " + txt);
			}
		}

		//Перезаписываем докупент, сохраняем и обновляем ассеты.
		string path = AssetDatabase.GetAssetPath(langAsset);
		xmlDoc.Save(path);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		Debug.Log("Сохранено в " + path);

	}
	public static void AddAliasAndLocalisationToXML(string sourceText, SystemLanguage lang)
	{
		//ВАЖНО!! Возможна ошибка когда на один и тот же алиас имеются разные текста.

		//Загружаем имеющийся документ
		XmlDocument xmlDoc = new XmlDocument();
		TextAsset langAsset = Resources.Load<TextAsset>("Localisation/" + lang);
		xmlDoc.LoadXml(langAsset.text);

		//Добавляем все имеющиеся в документе алиасы в HashSet. Нужно что бы не добавлять имеющиеся алиасы.
		XmlElement root = xmlDoc.DocumentElement;
		XmlNodeList nodes = root.SelectNodes("//string"); //ignore all nodes but <string> 
		HashSet<string> dict = new HashSet<string>();

		foreach(XmlNode node in nodes)
		{
			string key = node.Attributes["name"].Value;
			if(!dict.Contains(key))
			{
				dict.Add(key);
			}


		}

		XmlNode rootNode = xmlDoc.GetElementsByTagName("document")[0];

		if(!dict.Contains(sourceText))//Проверяем что бы не доавлялись алиасы которые уже есть
		{
			XmlNode node = xmlDoc.CreateElement("string");
			XmlAttribute attribute = xmlDoc.CreateAttribute("name");
			//attribute.Value = "ID"+i;
			attribute.Value = sourceText;
			node.Attributes.Append(attribute);
			var value = sourceText;
			node.InnerText = value;
			rootNode.AppendChild(node);
			//i++;

			dict.Add(sourceText);//Добавляем новый алиас в словарь, что бы избижать повторений
								 //ВАЖНО!! Возможна ошибка когда на один и тот же алиас имеются разные текста.
		}
		else
		{
			Debug.Log("Повтор текста: " + sourceText);
		}

		//Перезаписываем докупент, сохраняем и обновляем ассеты.
		string path = AssetDatabase.GetAssetPath(langAsset);
		xmlDoc.Save(path);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		Debug.Log("Сохранено в " + path);

	}
	
#endif
}
