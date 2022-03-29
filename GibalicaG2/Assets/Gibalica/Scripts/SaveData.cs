using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
  [SerializeField] 
  public static SettingsFile settingsFile = new SettingsFile();
  public static Canvas canvas;
  public static Font normalFont;
  public static Font specialFont;

  public void Start()
   {
    ReadFromJson();
   }

  public static void SaveIntoJson()
  {
    string settingsJson = JsonUtility.ToJson(settingsFile);
    System.IO.File.WriteAllText(Application.persistentDataPath + "/Settings.json", settingsJson);
  }

  public static void ReadFromJson()
  {
    settingsFile = JsonUtility.FromJson<SettingsFile>(Application.persistentDataPath + "/Settings.json");

    for (int i = 0; i < canvas.transform.childCount; i++)
    {
      GameObject child = canvas.transform.GetChild(i).gameObject;
      if (child.name.EndsWith("Button"))
      {
        Text targetText = child.GetComponent<Text>();
        targetText.font = targetText.font == normalFont ? specialFont : normalFont;
      }
    }
  }

  public static void ChangeTheme()
  {
    settingsFile.darkTheme = true ? false : true;
    SaveIntoJson();
  }

  public static void ChangeFont()
  {
    settingsFile.specialFont = true ? false : true;
    SaveIntoJson();
  }

  public static void ChangeSound()
  {
    settingsFile.soundOff = true ? false : true;
    SaveIntoJson();
  }
}


[System.Serializable]
public class SettingsFile
{
  public bool darkTheme = false;
  public bool specialFont = false;
  public bool soundOff = false;
}

