using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Sprite[] UIModeImages;
    
    private UIModeResolver _modeResolver;
    private Button _uiMode;
    
    private void Awake()
    {
        _modeResolver = FindObjectOfType<UIModeResolver>();
        _uiMode = GetComponentInChildren<Button>();
        _uiMode.image.sprite = UIModeImages[PrefsHolder.IsDarkMode() ? 0 : 1];
    }

    public void ToggleUIMode()
    {
        var state = !PrefsHolder.IsDarkMode();
        PrefsHolder.SaveDarkMode(state);
        _uiMode.image.sprite = UIModeImages[state ? 0 : 1];
        _modeResolver.ResolveMode();
    }
}
