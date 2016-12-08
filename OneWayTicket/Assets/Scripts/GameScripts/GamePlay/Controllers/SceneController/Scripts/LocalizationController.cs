public class LocalizationController : ILocalizationController
{
	// Use this for initialization
	void Start ()
    {
        SetLanguage("en");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SetLanguage(string languageKey)
    {
        GlobalLocalizationManager.Instance.LanguageManager.ChangeLanguage(languageKey);
    }

}
