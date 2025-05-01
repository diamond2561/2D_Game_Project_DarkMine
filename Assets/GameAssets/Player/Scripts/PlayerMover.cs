using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _playerRigidBody;
    private bool _isMoving;

    public event System.Action<bool> OnPlayerMove;

    private void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer(Vector2 direction)
    {
        // Нормализуем направление, чтобы избежать диагонального движения быстрее обычного
        Vector2 movement = direction.normalized * _speed;

        // Устанавливаем скорость Rigidbody2D
        _playerRigidBody.linearVelocity = movement;

        // Проверяем, движется ли игрок
        bool isCurrentlyMoving = direction.magnitude > 0.1f;
        if (_isMoving != isCurrentlyMoving)
        {
            _isMoving = isCurrentlyMoving;
            OnPlayerMove?.Invoke(_isMoving);
        }
    }
}