using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{

  [SerializeField] public Mediapipe.Unity.SquatMeter _squatMeter;
  [SerializeField] public Text scoreText;

  Score score = new Score();

  // Start is called before the first frame update
  void Start()
  {
    if(scoreText!=null)
        {
          scoreText.text = $"Score: {_squatMeter?.repCount}";
        }
        else
        {
          Debug.LogWarning("No score Text gameobject bound!");
        }
  }

  // Update is called once per frame
  void Update()
  {
        if(scoreText!=null)
        {
          scoreText.text = $"Score: {_squatMeter?.repCount}";
        }
  }

  void OnRepIncrease(int reps)
  {

  }
}
