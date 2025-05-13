using UnityEngine;

public class Enemy_2_Light : MonoBehaviour
{
    public void SetLightDirection(Vector2 direction)
    {
        // Вычисляем угол поворота на основе направления
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Применяем угол к объекту (свет всегда направлен вдоль оси X по умолчанию)
        transform.eulerAngles = new Vector3(0, 0, angle ); // -90 для корректировки направления
    }
}
