using UnityEngine;
using UnityEngine.UI;

public class UIModeElement : MonoBehaviour
{
    public Sprite[] LightModeSprite;
    public Sprite[] DarkModeSprite;

  public void ResolveImage(bool darkTheme, int num)
  {
    if (LightModeSprite.Length != 0)
    {
      int spriteNum = num;
      if (LightModeSprite.Length == 1) {
        spriteNum = 0;
      }

      if (darkTheme)
      {
        GetComponent<Image>().sprite = DarkModeSprite[spriteNum];
      }
      else
      {
        GetComponent<Image>().sprite = LightModeSprite[spriteNum];
      }
    }
  }
}
