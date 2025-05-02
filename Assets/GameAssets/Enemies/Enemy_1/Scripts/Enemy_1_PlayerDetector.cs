using UnityEngine;

public class Enemy_1_PlayerDetector : MonoBehaviour
{
    [Header("Настройки обнаружения игрока")]
    [SerializeField] private float _detectionRadius = 5f;  // радиус обнаружения

    public Vector2 PlayerPosition { get; private set; }
    public bool IsPlayerDetected { get; private set; }

    public bool WasPlayerDetectedOnce { get; private set; } // Флаг "игрок был обнаружен"

    void Update()
    {
        IsPlayerDetected = CheckForPlayerInRadius();

        // Если игрок обнаружен, устанавливаем флаг
        if (IsPlayerDetected)
        {
            WasPlayerDetectedOnce = true;
        }
    }

    private bool CheckForPlayerInRadius()
    {
        // Проверяем наличие игрока в радиусе обнаружения
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _detectionRadius);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<Player>(out Player player))
            {
                if (player.IsMoving == true)
                {
                    PlayerPosition = player.transform.position;
                    return true;
                }
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}
