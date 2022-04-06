using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{

  [SerializeField] UnityEngine.UI.Image dayImage;
  [SerializeField] UnityEngine.UI.Image nightImage;
  public double cooldown = 0;
  public bool isDay = true;

  // Start is called before the first frame update
  void Start()
  {
      cooldown=Time.timeAsDouble;
  }

  // Update is called once per frame
  void Update()
  {
    if (Time.time > cooldown)
    {
      TriggerNewChange();
    }
  }

  bool IsDay()
  {
    if (Random.Range(0f, 10.0f) > 5)
    {
      return true;
    }
    return false;
  }

///Fade between the day and night images
  void TriggerNewChange()
  {
    cooldown += Random.Range(0f, 10.0f);
    bool day = IsDay();
    if (day)
    {
      dayImage.CrossFadeAlpha(0, 0, true);
      dayImage.gameObject.SetActive(false);
      dayImage.CrossFadeAlpha(1, 1, false);
      nightImage.gameObject.SetActive(false);
      nightImage.CrossFadeAlpha(0, 0, true);
    }
    else
    {
      nightImage.CrossFadeAlpha(0, 0, true);
      nightImage.gameObject.SetActive(false);
      nightImage.CrossFadeAlpha(1, 1, false);
      dayImage.gameObject.SetActive(false);
      dayImage.CrossFadeAlpha(0, 0, true);
    }
  }
}