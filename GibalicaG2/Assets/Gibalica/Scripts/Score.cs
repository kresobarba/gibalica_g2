using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Score : MonoBehaviour
{
  private static DateTime date = DateTime.Now;
  private int duration = 0;
  private static int score = 0;
  private static int type = 0;

  public void IncreaseScore()
  {
    score += 1;
  }

}
