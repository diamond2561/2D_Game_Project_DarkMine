using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private Light2D _playerLight; // Ссылка на свет игрока

    public void SetLightDirection(Vector2 direction)
    {
        // Вычисляем угол поворота на основе направления
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Применяем угол к объекту (свет всегда направлен вдоль оси X по умолчанию)
        transform.eulerAngles = new Vector3(0, 0, angle + 90); // -90 для корректировки направления
    }

    // Включение света игрока
    public void TurnOffThePlayerLight()
    {
        _playerLight.enabled = false;
    }

    // Выключение света игрока
    public void TurnOnThePlayerLight()
    {
        _playerLight.enabled = true;
    }

    public void TwitchLight()
    {
        float minTwitch = -0.1f;
        float maxTwitch = 0.1f;

        // Генерируем случайное смещение в диапазоне [minTwitch, maxTwitch]
        float randomOffsetX = Random.Range(minTwitch, maxTwitch);
        float randomOffsetY = Random.Range(minTwitch, maxTwitch);

        // Применяем смещение к позиции света
        Vector3 newPosition = transform.localPosition;
        newPosition.x = randomOffsetX; // Добавляем случайное смещение по оси X
        newPosition.y = randomOffsetY; // Добавляем случайное смещение по оси Y
        transform.localPosition = newPosition;
    }
}