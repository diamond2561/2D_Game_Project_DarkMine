using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerLight _playerLight;
    [SerializeField] private PlayerCollisionDetector _playerCollisionDetector;
    [SerializeField] private PlayerSprite _playerSprite;

    public bool IsMoving { get; private set; }
    public bool IsLightOn { get; private set; }

    public bool IsHide { get; private set; }

    // Переменные для хранения предыдущих состояний
    private bool _wasMoving;
    private bool _wasLightOn;
    private bool _wasHide;

    private void Update()
    {
        HandleLight();
        HandleItemPickup();
        HandleHide();
        TwitchPlayerLight();

        // Проверка статуса игрока только при изменении состояния
        CheckPlayerStatus();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Если игрок прячется, блокируем движение
        if (IsHide)
        {
            _playerMover.MovePlayer(Vector2.zero); // Останавливаем движение
            IsMoving = false; // Устанавливаем флаг "не движется"
            return; // Выходим из метода, чтобы не обрабатывать дальнейшее движение
        }

        // Обычная логика движения
        Vector2 direction = _inputReader.Direction;

        if (direction.magnitude > 0.1f)
        {
            _playerMover.MovePlayer(direction);
            _playerLight.SetLightDirection(direction); // Передаем направление в свет
            IsMoving = true;

            // Звук шагов: Воспроизводится, когда игрок движется.
        }
        else
        {
            _playerMover.MovePlayer(Vector2.zero);
            IsMoving = false;
        }
    }

    private void HandleLight()
    {
        // Включаем или выключаем свет в зависимости от состояния IsLightSwitch, если игрок не прячется
        if (!IsHide)
        {
            if (_inputReader.IsLightSwitch)
            {
                UpdatePlayerLight(true); // Включаем свет
            }
            else
            {
                UpdatePlayerLight(false); // Выключаем свет
            }
        }
    }

    private void HandleItemPickup()
    {
        // Если нажата клавиша E, пытаемся подобрать предмет
        if (_inputReader.IsItemPickup)
        {
            _playerCollisionDetector.TryPickupItem();
        }
    }

    private void HandleHide()
    {
        // Проверяем, была ли нажата клавиша Q
        if (_inputReader.IsInputHide)
        {
            // Переключаем состояние IsHide только если игрок находится рядом с объектом, в котором можно спрятаться
            if (_playerCollisionDetector.IsNearByHidenObject)
            {
                IsHide = !IsHide; // Переключаем состояние IsHide

                // Управляем прозрачностью спрайта, светом и светом коробки в зависимости от состояния IsHide
                if (IsHide)
                {
                    UpdatePlayerLight(false); // Выключаем свет игрока
                    _playerSprite.MakeTransparent(); // Делаем спрайт прозрачным

                    // Включаем свет коробки
                    if (_playerCollisionDetector.CurrentHidenObject != null)
                    {
                        _playerCollisionDetector.CurrentHidenObject.TurnOnTheObjectLight();
                    }
                }
                else
                {
                    _playerSprite.ResetTransparency(); // Восстанавливаем исходный цвет спрайта
                    UpdatePlayerLight(_inputReader.IsLightSwitch); // Включаем свет игрока, если IsLightSwitch == true

                    // Выключаем свет коробки
                    if (_playerCollisionDetector.CurrentHidenObject != null)
                    {
                        _playerCollisionDetector.CurrentHidenObject.TurnOffTheObjectLight();
                    }
                }
            }
        }
    }

    private void TwitchPlayerLight()
    {
        if (IsMoving == true)
        {
            _playerLight.TwitchLight();
        }
        if (IsMoving == false)
        {
            _playerLight.transform.position = transform.position;
        }
    }

    private void UpdatePlayerLight(bool isLightOn)
    {
        if (isLightOn)
        {
            _playerLight.TurnOnThePlayerLight();
            IsLightOn = true;
        }
        else
        {
            _playerLight.TurnOffThePlayerLight();
            IsLightOn = false;
        }
    }



    // Метод проверки статуса игрока
    private void CheckPlayerStatus()
    {
        // Проверяем, изменилось ли состояние движения
        if (IsMoving != _wasMoving)
        {
            _wasMoving = IsMoving; // Обновляем предыдущее состояние
            Debug.Log(IsMoving ? "Подруга начала идти!" : "Подруга перестала идти!");
        }

        // Проверяем, изменилось ли состояние света
        if (IsLightOn != _wasLightOn)
        {
            _wasLightOn = IsLightOn; // Обновляем предыдущее состояние
            Debug.Log(IsLightOn ? "Подруга включила лампу!" : "Подруга выключила лампу!");
        }

        // Проверка состояния прятания
        if (IsHide != _wasHide)
        {
            _wasHide = IsHide; // Обновляем предыдущее состояние
            Debug.Log(IsHide ? "Подруга спряталась!" : "Подруга больше не прячется!");
        }
    }    
}