using UnityEngine;
using System.Collections;
using SmartLocalization;
public static class StringExtensions
{
    public static bool IsNullOrEmpty (this string s)
    {
        return (s == "" || s == null);
	}
    public static string Localize(this string s, params string[] args)
    {
        return GlobalLocalizationManager.Instance.LanguageManager.GetTextValue(s) != null ? string.Format(GlobalLocalizationManager.Instance.LanguageManager.GetTextValue(s), args) : null;
    }

}
