using UnityEngine;
using UnityEngine.UI;

public class UIModeResolver : MonoBehaviour
{
    private const float DarkGrey = 0.07f;
    private readonly Color _darkGrey = new Color(DarkGrey, DarkGrey, DarkGrey, 1);

    private void Awake()
    {
        ResolveDarkMode();
    }

    private void ResolveDarkMode()
    {
        if (!PrefsHolder.IsDarkMode()) return;

        ResolveMode();
    }

    public void ResolveMode()
    {
        foreach (var text in GetComponentsInChildren<Text>(true))
        {
            text.color = text.color == Color.white ? _darkGrey : Color.white;
        }

        foreach (var image in GetComponentsInChildren<Image>(true))
        {
            var uiModeElement = image.GetComponent<UIModeElement>();
            if (uiModeElement)
            {
                uiModeElement.ResolveImage();
            }
            else
            {
                image.color = image.color == Color.white ? _darkGrey : Color.white;
            }
        }
    }
}