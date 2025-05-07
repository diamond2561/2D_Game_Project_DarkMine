using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSprite; // Ссылка на компонент SpriteRenderer

    private Color _originalColor; // Переменная для хранения исходного цвета спрайта

    private void Start()
    {
        // Сохраняем исходный цвет спрайта при старте
        if (_playerSprite != null)
        {
            _originalColor = _playerSprite.color;
        }
        else
        {
            Debug.LogError("SpriteRenderer не назначен!");
        }
    }

    public void MakeTransparent()
    {
        if (_playerSprite != null)
        {
            Color transparentColor = _playerSprite.color;
            transparentColor.a = 0f; // Устанавливаем альфа-канал (например, 0.3 для полупрозрачности)
            _playerSprite.color = transparentColor;
        }
    }

    public void ResetTransparency()
    {
        if (_playerSprite != null)
        {
            _playerSprite.color = _originalColor; // Возвращаем исходный цвет
        }
    }
}