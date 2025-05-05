using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const string PREHISTORY_SCENE = "PrehistoryScene";
    private const string OPTIONS_SCENE = "OptionsScene";

    [SerializeField] private Button _startNewGameButton;
    [SerializeField] private Button _continueGameButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _authorsButton;
    [SerializeField] private Button _quitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startNewGameButton.onClick.AddListener(LoadPrehistoryScene);
        _optionsButton.onClick.AddListener(GoToOptions);
    }

    private void LoadPrehistoryScene()
    {
        SceneManager.LoadScene(PREHISTORY_SCENE);
    }

    private void GoToOptions()
    {
        SceneManager.LoadScene(OPTIONS_SCENE);
    }
}
