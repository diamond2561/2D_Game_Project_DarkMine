using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : BaseEnemy
{
    [SerializeField] private Enemy_1_PlayerDetector _enemyPlayerDetector;
    [SerializeField] private Enemy_1_Patrol _enemyPatrol; // Ссылка на новый патрульный скрипт
    [SerializeField] private float _fixedZPosition = 0f; // Укажи нужную Z-координату


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void LateUpdate()
    {
        // Принудительно фиксируем Z-позицию
        transform.position = new Vector3(transform.position.x, transform.position.y, _fixedZPosition);
    }

    private void HandleMovement()
    {
        //if (_enemyPlayerDetector.WasPlayerDetectedOnce)
        //{
        //    if (!_isChasing)
        //    {
        //        // Переключаемся в режим преследования
        //        _enemyPatrol.StopPatrolling(); // Останавливаем патрулирование
        //        _isChasing = true;
        //    }

        //    // Двигаемся к игроку
        //    _agent.SetDestination(_enemyPlayerDetector.PlayerPosition);
        //}
        //else
        //{
        //    if (_isChasing)
        //    {
        //        // Возвращаемся к патрулированию
        //        _enemyPatrol.ResumePatrolling();
        //        _isChasing = false;
        //    }
        //}
    }
}