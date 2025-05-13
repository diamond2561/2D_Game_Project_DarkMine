using UnityEngine;
using UnityEngine.AI;

public class Enemy_2 : BaseEnemy
{
    [SerializeField] private Enemy_2_PlayerDetector _enemyPlayerDetector;
    [SerializeField] private Enemy_2_Patrol _enemyPatrol;
    [SerializeField] private Enemy_2_Light _enemyLight;

    [SerializeField] private float _fixedZPosition = 0f; // Фиксированная Z-координата

    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
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
    }

    private void Update()
    {
        // Получаем нормализованное направление движения
        Vector2 movementDirection = _agent.velocity.normalized;

        // Проверяем, есть ли движение (чтобы не было "дрожи" при нулевом направлении)
        if (movementDirection != Vector2.zero)
        {
            _enemyLight.SetLightDirection(movementDirection);
        }
    }

    void LateUpdate()
    {
        // Принудительно фиксируем Z-позицию
        transform.position = new Vector3(transform.position.x, transform.position.y, _fixedZPosition);
    }

    private void ChasePlayer()
    {
        Vector2 playerPosition = _enemyPlayerDetector.PlayerPosition;
        _agent.SetDestination(playerPosition);
    }
}