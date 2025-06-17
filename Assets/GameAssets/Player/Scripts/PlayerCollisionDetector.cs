using NUnit.Framework;
using UnityEngine;


public class PlayerCollisionDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _hidenObjectsLayer; // Слой объектов, в которых можно спрятаться

    private BasePickableItem _currentItem; // Хранит текущий доступный для подбора предмет
    private BaseHidenObjects _currentHidenObject; // Хранит текущий объект, в котором можно спрятаться

    public bool IsNearByHidenObject { get; private set; } // Флаг: находится ли игрок рядом с объектом, в котором можно спрятаться
    public bool IsNearByPickableObject { get; private set; } // Флаг: находится ли игрок рядом с объектом, который можно подобрать 

    public BaseHidenObjects CurrentHidenObject => _currentHidenObject; // Публичное свойство для получения текущего объекта

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, есть ли у объекта компонент BasePickableItem
        if (other.gameObject.TryGetComponent<BasePickableItem>(out BasePickableItem item))
        {
            _currentItem = item; // Сохраняем ссылку на текущий предмет
            //Debug.Log("Press E to pick up: " + item.name);
            IsNearByPickableObject = true;
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
                IsNearByPickableObject = false;
                //Debug.Log("Item no longer in range.");
            }
        }

        SoundTriggersZone triggerSounds = other.gameObject.GetComponent<SoundTriggersZone>();
        if (triggerSounds != null) // Если компонент найден, воспроизводим звуки
        {
            Debug.Log("TrigerSounds detected!");
            triggerSounds.PlayRandomTriggerSound();
        }
    }

    public void TryPickupItem()
    {
        // Если есть доступный для подбора предмет
        if (_currentItem != null)
        {
            Debug.Log("Item picked up: " + _currentItem.name);
            _currentItem.Collect(); // Вызываем метод подбора предмета
            //_currentItem = null; // Очищаем текущий предмет
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<BaseHidenObjects>(out BaseHidenObjects hidenObject))
        {
            _currentHidenObject = hidenObject; // Сохраняем ссылку на объект
            Debug.Log("Подруга может спрятаться!");
            IsNearByHidenObject = true; // Устанавливаем флаг
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<BaseHidenObjects>(out BaseHidenObjects hidenObject))
        {
            if (_currentHidenObject == hidenObject)
            {
                _currentHidenObject = null; // Очищаем ссылку
                Debug.Log("Подруга уже не возле предмета в котором можно спрятаться!!");
                IsNearByHidenObject = false; // Сбрасываем флаг
            }
        }
    }
    

    public BasePickableItem GetPickableItem()
    {
        return _currentItem;
    }
}