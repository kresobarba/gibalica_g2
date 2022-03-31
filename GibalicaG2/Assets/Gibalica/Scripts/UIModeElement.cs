using UnityEngine;
using UnityEngine.UI;

public class UIModeElement : MonoBehaviour
{
    public Sprite LightModeSprite;
    public Sprite DarkModeSprite;

  public void ResolveImage(bool darkTheme)
  {
    if (LightModeSprite)
    {
      if (darkTheme)
      {
        GetComponent<Image>().sprite = DarkModeSprite;
      }
      else
      {
        GetComponent<Image>().sprite = LightModeSprite;
      }
    }
  }
}
