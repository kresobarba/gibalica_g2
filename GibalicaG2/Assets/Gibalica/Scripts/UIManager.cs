using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

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
    SceneManager.LoadScene("Pose Tracking");
  }

  public void LoadFreeMode()
  {
    SceneManager.LoadScene("FreeModeScene");
  }

  public void LoadTimedMode()
  {
    SceneManager.LoadScene("FreeModeScene");
  }

  public void LoadDayNight()
  {
    SceneManager.LoadScene("DayNightScene");
  }

  public async void BackToMenu()
  {
    //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    SceneManager.LoadScene("WelcomeScene");
  }

  public void LoadScores()
    {
    SceneManager.LoadScene("ScoreScene");
  }

}
