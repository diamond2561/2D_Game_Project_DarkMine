using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy_1_Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f; // Скорость перемещения
    [SerializeField] private float _moveToPlayerSpeed = 1.5f; // Скорость движения к игроку
    private Rigidbody2D _rigidbody;

    // Start вызывается один раз перед первым обновлением
    void Start()
    {
        // Получаем компонент Rigidbody2D
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Patrol()
    {
        // Создаем вектор движения вперед (вдоль оси X)
        Vector2 movement = new Vector2(_speed, 0);

        // Применяем движение к Rigidbody2D
        _rigidbody.linearVelocity = movement;
    }

    public void MoveToPlayer(Vector2 targetPosition)
    {
        // Вычисляем направление к игроку
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        _rigidbody.linearVelocity = direction * _moveToPlayerSpeed;
    }

    public void StopMoving()
    {
        // Останавливаем движение
        _rigidbody.linearVelocity = Vector2.zero;
    }
}