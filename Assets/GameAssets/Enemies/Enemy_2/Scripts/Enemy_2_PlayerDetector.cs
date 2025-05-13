using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_2_PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _detectionRadius = 5f; // радиус обнаружения
    [SerializeField] private LayerMask detectionLayerMask; // слой, на котором находится игрок

    public Vector2 PlayerPosition { get; private set; }
    public bool IsPlayerDetected { get; private set; }
    public bool WasPlayerDetectedOnce { get; private set; } // Флаг "игрок был обнаружен"

    void Update()
    {
        // Обновляем состояние обнаружения игрока каждый кадр
        IsPlayerDetected = CheckPlayerInLineOfSight();

        if (IsPlayerDetected)
        {
            WasPlayerDetectedOnce = true;
        }
    }

    private bool CheckPlayerInLineOfSight()
    {
        // Проверяем наличие игрока в радиусе обнаружения
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _detectionRadius);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<Player>(out Player player))
            {
                if (player.IsLightOn == true || player.IsMoving == true)
                {
                    Debug.Log("Player detected");
                    PlayerPosition = player.transform.position;
                    return true;
                }
            }
        }

        return false;
    }

    // === Gizmos для отрисовки области обнаружения ===
    private void OnDrawGizmos()
    {
        // Рисуем окружность вокруг врага
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            // Уничтожаем игрока с небольшой задержкой для визуального эффекта
            Destroy(collision.gameObject, 0.5f);

            // Перезапускаем сцену через 0.5 секунды (можно синхронно или асинхронно)
            Invoke("ReloadScene", 0.5f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
