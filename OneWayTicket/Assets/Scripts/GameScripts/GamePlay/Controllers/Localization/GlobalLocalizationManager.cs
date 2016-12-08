using UnityEngine;
using System.Collections;
using SmartLocalization;

public class GlobalLocalizationManager : Singleton<GlobalLocalizationManager>
{
    protected GlobalLocalizationManager() { }

    private LanguageManager _languageManager;
    public LanguageManager LanguageManager
    {
        get
        {
            if (_languageManager == null)
                _languageManager = LanguageManager.Instance;
            return _languageManager;
        }
    }
}
