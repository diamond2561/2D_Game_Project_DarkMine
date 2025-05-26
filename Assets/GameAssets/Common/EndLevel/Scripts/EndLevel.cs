using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    // Флаг, указывающий, что уровень завершен
    public bool IsLevelEnd { get; private set; }

    // Ссылка на текущую сцену
    private string currentSceneName;

    private void Start()
    {
        // Получаем имя текущей сцены
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, что объект, вошедший в триггер, содержит компонент Player
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("Player come to end level");
            IsLevelEnd = true;

            // Сохраняем прогресс
            SaveProgress(currentSceneName);

            // Загружаем следующую сцену
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        // Разбиваем имя текущей сцены на части (например, "Level1-1" -> ["Level", "1", "1"])
        string[] sceneParts = currentSceneName.Split('-');

        if (sceneParts.Length == 2)
        {
            // Парсим номер текущего уровня
            if (int.TryParse(sceneParts[1], out int currentLevelNumber))
            {
                // Формируем имя следующей сцены
                string nextSceneName = $"{sceneParts[0]}-{currentLevelNumber + 1}";

                // Проверяем, существует ли такая сцена
                if (SceneExists(nextSceneName))
                {
                    Debug.Log($"Loading next level: {nextSceneName}");
                    SceneManager.LoadScene(nextSceneName);
                }
                else
                {
                    Debug.LogWarning($"Next level '{nextSceneName}' does not exist. Game over or loop back?");
                    // Здесь можно добавить логику завершения игры или возврата к главному меню
                }
            }
            else
            {
                Debug.LogError("Failed to parse level number from scene name.");
            }
        }
        else
        {
            Debug.LogError("Scene name is not in the expected format (e.g., 'Level1-1').");
        }
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

    private void SaveProgress(string levelName)
    {
        // Сохраняем имя последнего пройденного уровня
        PlayerPrefs.SetString("LastCompletedLevel", levelName);
        PlayerPrefs.Save(); // Убедимся, что данные сохранены
        Debug.Log($"Progress saved: Last completed level is {levelName}");
    }
}