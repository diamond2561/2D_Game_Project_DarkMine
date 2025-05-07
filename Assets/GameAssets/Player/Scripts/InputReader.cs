using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public Vector2 Direction { get; private set; } // Направление движения
    public bool IsLightSwitch { get; private set; } // Состояние света (вкл/выкл)
    public bool IsItemPickup { get; private set; } // Состояние подбора предмета
    public bool IsInputHide { get; private set; } // состояние пряток

    private void Update()
    {
        ToggleDirection();
        ToggleLight();
        ToggleItemsPickup();
        ToggleHide();
    }

    private void ToggleDirection()
    {
        float horizontal = Input.GetAxis(Horizontal);
        float vertical = Input.GetAxis(Vertical);
        Direction = new Vector2(horizontal, vertical);
    }

    private void ToggleLight()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            IsLightSwitch = !IsLightSwitch;
        }
    }

    private void ToggleItemsPickup()
    {
        IsItemPickup = Input.GetKeyDown(KeyCode.E); // Возвращает true только в момент нажатия клавиши E
    }

    private void ToggleHide()
    {
        IsInputHide = Input.GetKeyDown(KeyCode.Q); // Возвращает true только в момент нажатия клавиши Q
    }
}