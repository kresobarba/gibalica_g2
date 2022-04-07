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
    //Important model keypoints
    const int LEFT_HIP = 23;
    const int RIGHT_HIP = 24;
    const int LEFT_KNEE = 25;
    const int RIGHT_KNEE = 26;
    const int LEFT_ANKLE = 27;
    const int RIGHT_ANKLE = 28;

    // Serializable for saving the state
    [SerializeField] public float _squatLegRatio = 1.5f;
    [SerializeField] public float _standingLegRatio = 2.0f;
    [SerializeField] public bool _enableDebugLog=false;

    // Set fields to public for easy debugging and hooking into the script
    public bool isSquat = false;
    public int repCount = 0;

    public float ankle_l;
    public float ankle_r;
    public float diff_l;
    public float diff_r;

    public int GetReps()
    {
      return repCount;
    }

    [SerializeField] Text debugLog;

    public bool Measure(IList<NormalizedLandmark> currentTarget)
    {
      if (currentTarget==null || currentTarget.Count==0)
      {
        // Skip detection if no points are accessible
        return false;
      }

      ankle_l = currentTarget[LEFT_ANKLE].Y / currentTarget[LEFT_ANKLE].Y;
      ankle_r = currentTarget[RIGHT_ANKLE].Y / currentTarget[RIGHT_ANKLE].Y;
      diff_l = (currentTarget[LEFT_HIP].Y - ankle_l) / (currentTarget[LEFT_KNEE].Y - ankle_l);
      diff_r = (currentTarget[RIGHT_HIP].Y - ankle_r) / (currentTarget[RIGHT_KNEE].Y - ankle_r);

      if (!isSquat)
      {
        if (diff_l < this._squatLegRatio && diff_r < this._squatLegRatio)
        {
          this.isSquat = true;
          repCount++;
          RaiseOnRep();
          //EventManager.sad
        }
      }
      else
      {
        if (diff_l > this._standingLegRatio && diff_r > this._standingLegRatio)
        {
          this.isSquat = false;
        }
      }


      if (_enableDebugLog && debugLog != null)
      {

        //string message = string.Format("Diff\nL:{8:f4} Diff R:{8:f4}\nHIPS\nL:{8:f4} R:{8:f4}\nKNEES\nL:{8:f4} R:{8:f4}\nANKLES\nL:{8:f4} R:{8:f4}",
        //diff_l, diff_r, currentTarget[LEFT_HIP].Y, currentTarget[RIGHT_HIP].Y, currentTarget[LEFT_KNEE].Y, currentTarget[RIGHT_KNEE].Y, currentTarget[LEFT_ANKLE].Y);

        string log = $"Diff L: {diff_l} R: {diff_r}" + "\nHIPS " + "\nR: " + currentTarget[RIGHT_HIP].ToString() + "\nL: " + currentTarget[LEFT_HIP].ToString();
        log += "\nKNEES " + "\nR: " + currentTarget[RIGHT_KNEE].ToString() + "\nL: " + currentTarget[LEFT_KNEE].ToString();
        log += "\nANKLES " + "\nR: " + currentTarget[RIGHT_ANKLE].ToString() + "\nL: " + currentTarget[LEFT_ANKLE].ToString();
        debugLog.text = log;
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
