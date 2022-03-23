using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevButton : MonoBehaviour
{
  [SerializeField] private GameObject _footer;

  public void ToggleFooter()
  {
    _footer.SetActive(!_footer.activeSelf);
  }

}
