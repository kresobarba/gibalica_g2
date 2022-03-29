using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

  private int font = 0;

  public void StartGibalica()
  {
    SceneManager.LoadScene("ExerciseScene");
  }

  public void LoadAboutUs()
  {
    SceneManager.LoadScene("AboutScene");
  }

  public void LoadWelcome()
  {
    SceneManager.LoadScene("WelcomeScene");
  }

  public void LoadTracker()
  {
    SceneManager.LoadScene("Start Scene");
  }

  public void ChangeTheme()
  {
    SaveData.ChangeTheme();
  }

  public void ChangeFont()
  {
    SaveData.ChangeFont();
  }

  public void ChangeSound()
  {
    SaveData.ChangeSound();
  }

}
