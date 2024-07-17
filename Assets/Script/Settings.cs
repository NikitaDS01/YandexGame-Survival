using UnityEngine;

public static class Settings
{
    public enum Language
    {
        RUS = 1,
        ENG = 2,
        TUR = 4
    }
    public static Language CurrentLanguage { get; set; } = Language.RUS;
}