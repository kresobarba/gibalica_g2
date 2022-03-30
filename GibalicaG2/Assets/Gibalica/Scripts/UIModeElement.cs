using UnityEngine;
using UnityEngine.UI;

public class UIModeElement : MonoBehaviour
{
    public Sprite LightModeSprite;
    public Sprite DarkModeSprite;

    public void ResolveImage()
    {
        if (LightModeSprite)
        {
            GetComponent<Image>().sprite = PrefsHolder.IsDarkMode() ? DarkModeSprite : LightModeSprite;
        }
    }
}