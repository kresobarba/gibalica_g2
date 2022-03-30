using UnityEngine;

public static class PrefsHolder
{
    private const string DarkMode = "DarkMode";

    public static void SaveDarkMode(bool on)
    {
        PlayerPrefs.SetInt(DarkMode, on ? 1 : 0);
    }

    public static bool IsDarkMode()
    {
        return PlayerPrefs.GetInt(DarkMode, 0) == 1;
    }
}