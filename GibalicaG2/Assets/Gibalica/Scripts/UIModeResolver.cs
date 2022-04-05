using UnityEngine;
using UnityEngine.UI;

public class UIModeResolver : MonoBehaviour
{
    private const float DarkGrey = 0.07f;
    private readonly Color _darkGrey = new Color(DarkGrey, DarkGrey, DarkGrey, 1);

    public void ResolveMode(bool darkTheme, SettingsFile settings)
    {
        foreach (var text in GetComponentsInChildren<Text>(true))
        {
            if(darkTheme)
            {
              text.color = Color.white;
            } else
            {
              text.color = _darkGrey;
            }
            
        }

        foreach (var image in GetComponentsInChildren<Image>(true))
        {
    
            var uiModeElement = image.GetComponent<UIModeElement>();
            if (uiModeElement)
            {
                int num = 0;
                if (settings.soundOff == true)
                {
                    num = 1;
                }  
                uiModeElement.ResolveImage(darkTheme, num);
            }
            else if (image.name.EndsWith("Button"))
            {
              if (darkTheme)
              {
                image.color = _darkGrey;
              }
              else
              {
                image.color = Color.white;
              }
            }
        }
    }
}
