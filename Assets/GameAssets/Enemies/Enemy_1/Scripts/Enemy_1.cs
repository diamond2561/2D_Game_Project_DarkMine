using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : BaseEnemy
{
    [SerializeField] private Enemy_1_PlayerDetector _enemyPlayerDetector;
    [SerializeField] private Enemy_1_Patrol _enemyPatrol; // Ссылка на патрульный скрипт
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

    private void ChasePlayer()
    {
        Vector2 playerPosition = _enemyPlayerDetector.PlayerPosition;
        _agent.SetDestination(playerPosition);
    }

    void LateUpdate()
    {
        // Принудительно фиксируем Z-позицию
        transform.position = new Vector3(transform.position.x, transform.position.y, _fixedZPosition);
    }
}