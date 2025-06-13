using UnityEngine;

public class GamePause : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0f; // Игра на паузе
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f; // Игра продолжается
    }
}