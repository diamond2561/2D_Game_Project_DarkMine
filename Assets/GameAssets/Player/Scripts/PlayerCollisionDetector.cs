using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    private BasePickableItem _currentItem; // Хранит текущий доступный для подбора предмет

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, есть ли у объекта компонент BasePickableItem
        if (other.gameObject.TryGetComponent<BasePickableItem>(out BasePickableItem item))
        {
            _currentItem = item; // Сохраняем ссылку на текущий предмет
            Debug.Log("Press E to pick up: " + item.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Если игрок покидает триггер, очищаем текущий предмет
        if (other.gameObject.TryGetComponent<BasePickableItem>(out BasePickableItem item))
        {
            if (_currentItem == item)
            {
                _currentItem = null;
                Debug.Log("Item no longer in range.");
            }
        }
    }

    public void TryPickupItem()
    {
        // Если есть доступный для подбора предмет
        if (_currentItem != null)
        {
            Debug.Log("Item picked up: " + _currentItem.name);
            _currentItem.Collect(); // Вызываем метод подбора предмета
            _currentItem = null; // Очищаем текущий предмет
        }
    }
}