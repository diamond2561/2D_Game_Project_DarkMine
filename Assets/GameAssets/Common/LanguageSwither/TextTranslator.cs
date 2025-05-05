using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextTranslator : MonoBehaviour
{
    TextMeshProUGUI _text;
    string _key;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _key = _text.text;
        SetText();
        LanguageData.OnLanguageChanged.AddListener(SetText);
    }

    private void SetText()
    {
        _text.text = LanguageData.LOCALIZATION[_key][LanguageData.CURRENT_LANGUAGE];
    }
}