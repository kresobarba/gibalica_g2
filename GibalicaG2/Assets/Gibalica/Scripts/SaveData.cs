using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
  [SerializeField] 
  public static SettingsFile settingsFile = new SettingsFile();
  public static Font normalFont;
  public static Font specialFont;

  public void Start()
   {
    normalFont = Resources.Load("Fonts/FredokaOne-Regular") as Font;
    specialFont = Resources.Load("Fonts/Raleway-Bold") as Font;
    ReadFromJson();
   }

  public static void SaveIntoJson()
  {
    string settingsJson = JsonUtility.ToJson(settingsFile);
    System.IO.File.WriteAllText(Application.persistentDataPath + "/Settings.json", settingsJson);
  }

  public static void ReadFromJson()
  {
    if (System.IO.File.Exists(Application.persistentDataPath + "/Settings.json"))
    {
      string savedSettings = System.IO.File.ReadAllText(Application.persistentDataPath + "/Settings.json");
      var settingsFilgge = JsonUtility.FromJson<SettingsFile>(savedSettings);
    }

    GameObject canvas = GameObject.Find("Canvas");
    for (int i = 0; i < canvas.transform.childCount; i++)
    {
      GameObject child = canvas.transform.GetChild(i).gameObject;

      if (child.GetComponent<Text>() != null || child.name.EndsWith("Button"))
      {
        Text targetText;
        if (child.GetComponent<Text>() == null)
        {
          targetText = child.transform.GetChild(0).GetComponent<Text>();
        } else
        { 
          targetText = child.GetComponent<Text>();
        }

        if (settingsFile.specialFont) {
           targetText.font = specialFont;
        } else {
           targetText.font = normalFont;
        }
      }
    }
  }

  public static void ChangeTheme()
  {
    settingsFile.darkTheme = settingsFile.darkTheme == true ? false : true;
    SaveIntoJson();
    ReadFromJson();
  }

  public static void ChangeFont()
  {
    settingsFile.specialFont = settingsFile.specialFont == true ? false : true;
    SaveIntoJson();
    ReadFromJson();
  }

  public static void ChangeSound()
  {
    settingsFile.soundOff = settingsFile.darkTheme == true ? false : true;
    SaveIntoJson();
    ReadFromJson();
  }
}


[System.Serializable]
public class SettingsFile
{
  public bool darkTheme = false;
  public bool specialFont = false;
  public bool soundOff = false;
}

