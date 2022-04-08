using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightController : MonoBehaviour
{

  [SerializeField] UnityEngine.UI.Image dayImage;
  [SerializeField] UnityEngine.UI.Image nightImage;
  [SerializeField] Mediapipe.Unity.SquatMeter _squatMeter;
  [SerializeField] public Text scoreText;

  public double cooldown = 0;
  public bool isDay = true;
  /// <summary>
  /// Sucessful poses
  /// </summary>
  public int pass = 0;
  /// <summary>
  /// Failed poses
  /// </summary>
  public int fail = 0;

  // Start is called before the first frame update
  void Start()
  {
    cooldown = Time.timeAsDouble;
    dayImage.gameObject.SetActive(false);
    dayImage.gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    if (Time.timeAsDouble > cooldown)
    {
      TriggerNewChange();
    }
  }

  bool IsDay()
  {
    if (Random.Range(0.0f, 10.0f) > 5.0f)
    {
      return true;
    }
    return false;
  }

  ///Fade between the day and night images
  void TriggerNewChange()
  {
    cooldown += Random.Range(0f, 10.0f);
    isDay = IsDay();
    if (isDay)
    {
      FadeInDay();
      if (!_squatMeter.isSquat)
      {
        pass++;
      }
      else
      {
        fail++;
      }
    }
    else
    {
      FadeInNight();
      if (_squatMeter.isSquat)
      {
        pass++;
      }
      else
      {
        fail++;
      }
    }
    UpdateScore();
  }

  void UpdateScore()
  {
    if(scoreText!=null)
    {
      scoreText.text = $"{pass} - {fail}";
    }
  }

  void FadeInDay()
  {
    /* dayImage.CrossFadeAlpha(0, 0, true);
    dayImage.gameObject.SetActive(true);
    dayImage.CrossFadeAlpha(1, 1, false);
    dayImage.CrossFadeAlpha(0, 1, false);
    dayImage.gameObject.SetActive(false); */

    nightImage.gameObject.SetActive(false);
    dayImage.gameObject.SetActive(true);
  }

  void FadeInNight()
  {
    /* nightImage.CrossFadeAlpha(0, 0, true);
    nightImage.gameObject.SetActive(true);
    nightImage.CrossFadeAlpha(1, 100, false);
    nightImage.CrossFadeAlpha(0, 100, false);
    nightImage.gameObject.SetActive(false); */

    dayImage.gameObject.SetActive(false);
    nightImage.gameObject.SetActive(true);
  }
}
