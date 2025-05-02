using UnityEngine;

public class Enemy_1 : BaseEnemy
{
    [SerializeField] private Enemy_1_Mover _enemyMover;
    [SerializeField] private Enemy_1_PlayerDetector _enemyPlayerDetector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (_enemyPlayerDetector.WasPlayerDetectedOnce)
        {
            // Если игрок был обнаружен хотя бы один раз, двигаемся к нему
            _enemyMover.MoveToPlayer(_enemyPlayerDetector.PlayerPosition);
        }
        else
        {
            // Если игрок еще не был обнаружен, патрулируем
            _enemyMover.Patrol();
        }
    }
}
