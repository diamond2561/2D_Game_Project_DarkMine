using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    private const string TO_MAIN_MENU = "MainMenuScene";

    [SerializeField] private TMP_Dropdown _dropdownLanguageOptions;
    [SerializeField] private Button _backToMainMenuButton;

    private void Awake()
    {
        _dropdownLanguageOptions.options = new List<TMP_Dropdown.OptionData>();

        foreach (string language in LanguageData.LANGUAGES)
        {
            _dropdownLanguageOptions.options.Add(new TMP_Dropdown.OptionData(language));
        }

        _dropdownLanguageOptions.onValueChanged.AddListener((int i) =>
        {
            string language = LanguageData.LANGUAGES[i];
            LanguageData.CURRENT_LANGUAGE = language;
            LanguageData.OnLanguageChanged.Invoke();
        });
    }

    private void Start()
    {
        _backToMainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene(TO_MAIN_MENU);
    }
}
