using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mediapipe.Unity;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Mediapipe.Unity
{
  public class SquatMeter : MonoBehaviour
  {
    const int LEFT_HIP = 23;
    const int RIGHT_HIP = 24;
    const int LEFT_KNEE = 25;
    const int RIGHT_KNEE = 26;
    const int LEFT_ANKLE = 27;
    const int RIGHT_ANKLE = 28;

    [SerializeField] public float _squatLegRatio = 1.0f;
    [SerializeField] public float _standingLegRatio = 1.8f;
    public bool isSquat = false;
    public int repCount = 0;

    public int GetReps()
    {
      return repCount;
    }

    [SerializeField] Text debugLog;

    public bool Measure(IList<NormalizedLandmark> currentTarget)
    {
      float ankle_l = currentTarget[LEFT_ANKLE].Y / currentTarget[LEFT_ANKLE].Y;
      float ankle_r = currentTarget[RIGHT_ANKLE].Y / currentTarget[RIGHT_ANKLE].Y;
      float diff_l = (currentTarget[LEFT_HIP].Y - ankle_l) / (currentTarget[LEFT_KNEE].Y - ankle_l);
      float diff_r = (currentTarget[RIGHT_HIP].Y - ankle_r) / (currentTarget[RIGHT_KNEE].Y - ankle_r);

      if (!isSquat)
      {
        if (diff_l < this._squatLegRatio && diff_r < this._squatLegRatio)
        {
          this.isSquat = true;
          repCount++;
          RaiseOnRep();
        }
      }
      else
      {
        if (diff_l < this._standingLegRatio && diff_r < this._standingLegRatio)
        {
          this.isSquat = false;
        }
      }


      if (debugLog != null)
      {

        string message = string.Format("Diff\nL:{8:f4} Diff R:{8:f4}\nHIPS\nL:{8:f4} R:{8:f4}\nKNEES\nL:{8:f4} R:{8:f4}\nANKLES\nL:{8:f4} R:{8:f4}",
        diff_l, diff_r, currentTarget[LEFT_HIP].Y, currentTarget[RIGHT_HIP].Y, currentTarget[LEFT_KNEE].Y, currentTarget[RIGHT_KNEE].Y, currentTarget[LEFT_ANKLE].Y);

        //string log = $"Diff L- {diff_l} R- {diff_r}" + "\nHIPS " + "\nR: " + currentTarget[RIGHT_HIP].ToString() + "\nL: " + currentTarget[LEFT_HIP].ToString(); ;
        debugLog.text = message;
      }


      return this.isSquat;
    }

    public void ResetReps()
    {
      repCount = 0;
    }

    // Events

    // When Reps have increased raise event to notify the scoring sysstem
    public delegate void RepDelegate();              //Declare a Delegate
    public static event RepDelegate OnRep;         //Create an Event
    public static void RaiseOnRep()
    {
      if (OnRep != null)
      {
        OnRep();                          //Invoke an Event
      }
    }
  }
}
