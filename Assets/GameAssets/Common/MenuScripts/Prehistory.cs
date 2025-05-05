using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prehistory : MonoBehaviour
{
    private const string TO_MAIN_MENU = "MainMenuScene";
    private const string TO_FIRST_LEVEL = "Level1-1";

    [SerializeField] private Button _startNewGameButton;
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private Button _nextPageButton;

    [SerializeField] private GameObject[] _pages; // Массив страниц

    private int _currentPageIndex = 0; // Индекс текущей страницы

    private void Start()
    {
        _startNewGameButton.onClick.AddListener(StartLevel1);
        _backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        _nextPageButton.onClick.AddListener(SwitchNextPage);

        // Показываем только первую страницу
        UpdatePages();
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene(TO_MAIN_MENU);
    }

    private void StartLevel1()
    {
        SceneManager.LoadScene(TO_FIRST_LEVEL);
    }

    private void SwitchNextPage()
    {
        _currentPageIndex++; // Увеличиваем индекс страницы

        if (_currentPageIndex >= _pages.Length)
        {
            _currentPageIndex = 0; // Если достигли конца, начинаем сначала или можно спрятать кнопку
        }

        UpdatePages();
    }

    private void UpdatePages()
    {
        for (int i = 0; i < _pages.Length; i++)
        {
            _pages[i].SetActive(i == _currentPageIndex);
        }
    }
}
