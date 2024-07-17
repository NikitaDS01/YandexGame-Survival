using UnityEngine;

[System.Serializable]
public class StringLanguage
{
    [Header("Перевод на RUS / ENG")]
    [SerializeField, Multiline]
    private string languageRUS = string.Empty;
    [SerializeField, Multiline]
    private string languageENG = string.Empty;

    public StringLanguage(string languageRUS, string languageENG)
    {
        this.languageRUS = languageRUS;
        this.languageENG = languageENG;
    }

    public string GetString()
    {
        switch (Settings.CurrentLanguage)
        {
            case Settings.Language.RUS: return languageRUS;
            case Settings.Language.ENG: return languageENG;
        }
        return string.Empty;
    }
    public override string ToString()
    {
        return GetString();
    }
    public static implicit operator string(StringLanguage languageIn)
    {
        return languageIn.GetString();
    }
}
