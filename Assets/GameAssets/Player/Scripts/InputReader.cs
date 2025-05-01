using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public Vector2 Direction { get; private set; } // Направление движения
    public bool IsLightSwitch { get; private set; } // Состояние света (вкл/выкл)

    private void Update()
    {
        ToggleDirection();
        ToggleLight();
    }

    private void ToggleDirection()
    {
        // Получаем входные данные для движения
        float horizontal = Input.GetAxis(Horizontal);
        float vertical = Input.GetAxis(Vertical);
        Direction = new Vector2(horizontal, vertical);
    }

    // Метод для переключения состояния света
    private void ToggleLight()
    {
        // Проверяем нажатие клавиши L для переключения света
        if (Input.GetKeyDown(KeyCode.L))
        {
            IsLightSwitch = !IsLightSwitch; // Переключаем состояние света
        }            
    }
}