using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : BaseEnemy
{
    [SerializeField] private Enemy_1_PlayerDetector _enemyPlayerDetector;
    [SerializeField] private Enemy_1_Patrol _enemyPatrol; // Ссылка на патрульный скрипт
    [SerializeField] private float _fixedZPosition = 0f; // Фиксированная Z-координата
    [SerializeField] private Enemy_1_Animations _enemyAnimations;
    [SerializeField] private SpriteRenderer _spriteRenderer; // Ссылка на SpriteRenderer

    private NavMeshAgent _agent;
    private Vector3 _previousPosition; // Предыдущая позиция для расчета направления

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _previousPosition = transform.position; // Инициализация предыдущей позиции
    }

    private void FixedUpdate()
    {
        if (_enemyPlayerDetector.IsPlayerDetected)
        {
            ChasePlayer();
        }
        else
        {
            _enemyPatrol.Patrol();
        }

        HandleAnimations();
    }

    private void ChasePlayer()
    {
        Vector2 playerPosition = _enemyPlayerDetector.PlayerPosition;
        _agent.SetDestination(playerPosition);
    }

    private void HandleAnimations()
    {
        // Вычисляем направление движения
        Vector3 movementDirection = (transform.position - _previousPosition).normalized;

        // Проверяем, движется ли враг
        if (movementDirection.magnitude > 0.1f) // Если скорость достаточно большая
        {
            // Анализируем направление движения
            if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
            {
                // Движение влево или вправо (горизонтальное)
                _enemyAnimations.TriggerMoveSideAnimation();

                // Разворачиваем спрайт в зависимости от направления движения по оси X
                _spriteRenderer.flipX = movementDirection.x > 0; // true - вправо, false - влево
            }
            else
            {
                if (movementDirection.y > 0)
                {
                    // Движение вверх
                    _enemyAnimations.TriggerMoveUpAnimation();
                }
                else
                {
                    // Движение вниз
                    _enemyAnimations.TriggerMoveDownAnimation();
                }
            }
        }

        // Обновляем предыдущую позицию
        _previousPosition = transform.position;
    }

    void LateUpdate()
    {
        // Принудительно фиксируем Z-позицию
        transform.position = new Vector3(transform.position.x, transform.position.y, _fixedZPosition);
    }
}