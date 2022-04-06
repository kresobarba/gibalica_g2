using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Score : MonoBehaviour
{


  public DateTime date = DateTime.Now;
  public int duration = 0;
  public int score = 0;
  public int type = 0;


  //squatMeter.OnRep

  public void IncreaseScore()
  {
    score += 1;
  }

}
