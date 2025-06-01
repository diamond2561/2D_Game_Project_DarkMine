using UnityEngine;
using UnityEngine.UI;
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

    private void Start()
    {
        _startNewGameButton.onClick.AddListener(LoadPrehistoryScene);
        _continueGameButton.onClick.AddListener(ContinueGame);
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

    private void ContinueGame()
    {
        // Проверяем, есть ли сохраненный прогресс
        string lastCompletedLevel = PlayerPrefs.GetString("LastCompletedLevel", "");

        if (!string.IsNullOrEmpty(lastCompletedLevel))
        {
            // Разбиваем имя уровня на части (например, "Level1-1" -> ["Level", "1", "1"])
            string[] sceneParts = lastCompletedLevel.Split('-');

            if (sceneParts.Length == 2 && int.TryParse(sceneParts[1], out int currentLevelNumber))
            {
                // Формируем имя следующей сцены
                string nextSceneName = $"{sceneParts[0]}-{currentLevelNumber + 1}";

                // Проверяем, существует ли такая сцена
                if (SceneExists(nextSceneName))
                {
                    Debug.Log($"Continuing game from level: {nextSceneName}");
                    SceneManager.LoadScene(nextSceneName);
                    return;
                }
            }
        }

        // Если прогресса нет или следующий уровень не существует, начинаем новую игру
        Debug.LogWarning("No saved progress found. Starting a new game.");
        SceneManager.LoadScene(PREHISTORY_SCENE);
    }

    private bool SceneExists(string sceneName)
    {
        // Получаем все сцены из Build Settings
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneFileName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            if (sceneFileName == sceneName)
            {
                return true;
            }
        }

        return false;
    }
}