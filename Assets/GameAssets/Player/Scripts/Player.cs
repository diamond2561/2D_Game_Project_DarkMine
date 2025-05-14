using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; 

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerLight _playerLight;
    [SerializeField] private PlayerCollisionDetector _playerCollisionDetector;
    [SerializeField] private PlayerSprite _playerSprite;

    [SerializeField] private Button _lightButton;
    [SerializeField] private Button _hideButton;
    [SerializeField] private Button _pickUpButton;

    public bool IsMoving { get; private set; }
    public bool IsLightOn { get; private set; }
    public bool IsHide { get; private set; }

    // Переменные для хранения предыдущих состояний
    private bool _wasMoving;
    private bool _wasLightOn;
    private bool _wasHide;

    private bool _shouldTryToHide = false;
    private bool _shouldTryToPickUp = false;

    // Событие, которое будет вызываться при подборе предмета
    public UnityEvent PickUpNotes = new UnityEvent();

    private void Start()
    {
        InitButtons();

        // Изначально скрываем кнопки
        ShowHideButton(false);
        ShowPickUpButton(false);
    }

    private void Update()
    {
        HandleLight();
        HandleItemPickup();
        HandleHide();
        TwitchPlayerLight();

        // Проверка статуса игрока только при изменении состояния
        CheckPlayerStatus();

        // Обновляем состояние кнопок на основе триггеров
        UpdateButtonStates();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void InitButtons()
    {
        if (_lightButton != null)
        {
            _lightButton.onClick.AddListener(ToggleLight);
        }

        if (_hideButton != null)
        {
            _hideButton.onClick.AddListener(ToggleHide);
        }
        if (_pickUpButton != null)
        {
            _pickUpButton.onClick.AddListener(TogglePickUp);
        }
    }    

    // Движение игрока
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


    // Свет Игрока
    private void ToggleLight()
    {
        // Эмулируем нажатие клавиши включения/выключения света
        _inputReader.ForceSetLightSwitch(!IsLightOn);
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

    // Подбор предметов
    private void TogglePickUp()
    {
        _shouldTryToPickUp = true;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Paper/Paper", GetComponent<Transform>().position);// Юрий добавил для звука записок
    }

    private void HandleItemPickup()
    {
        if (_inputReader.IsItemPickup || _shouldTryToPickUp)
        {
            //Debug.Log("[HandleItemPickup] Triggered via " + (_shouldTryToPickUp ? "Button" : "Keyboard"));

            _playerCollisionDetector.TryPickupItem();

            // Вызываем событие, если предмет был успешно подобран
            PickUpNotes.Invoke();

            // Сброс флагов после использования
            _inputReader.ForceSetItemPickup(false);
            _shouldTryToPickUp = false;
        }
    }

    // Прятки Игрока
    private void ToggleHide()
    {
        _shouldTryToHide = true;
    }

    private void HandleHide()
    {
        // Объединяем нажатие с клавиатуры и с кнопки
        if (_inputReader.IsInputHide || _shouldTryToHide)
        {
            //Debug.Log($"[HandleHide] Triggered via {(_shouldTryToHide ? "Button" : "Keyboard")}");

            if (_playerCollisionDetector.IsNearByHidenObject)
            {
                IsHide = !IsHide;

                if (IsHide)
                {
                    UpdatePlayerLight(false);
                    _playerSprite.MakeTransparent();

                    if (_playerCollisionDetector.CurrentHidenObject != null)
                    {
                        _playerCollisionDetector.CurrentHidenObject.TurnOnTheObjectLight();
                    }
                }
                else
                {
                    _playerSprite.ResetTransparency();
                    UpdatePlayerLight(_inputReader.IsLightSwitch);

                    if (_playerCollisionDetector.CurrentHidenObject != null)
                    {
                        _playerCollisionDetector.CurrentHidenObject.TurnOffTheObjectLight();
                    }
                }
            }
            else
            {
                Debug.LogWarning("Нельзя спрятаться — нет укрытия рядом.");
            }

            _inputReader.ForceSetInputHide(false);
            _shouldTryToHide = false; // Сброс
        }
    }

    // Методы скрытия кнопок
    private void ShowHideButton(bool show)
    {
        if (_hideButton != null)
        {
            _hideButton.gameObject.SetActive(show);
        }
    }

    private void ShowPickUpButton(bool show)
    {
        if (_pickUpButton != null)
        {
            _pickUpButton.gameObject.SetActive(show);
        }
    }

    private void UpdateButtonStates()
    {
        if (_playerCollisionDetector != null)
        {
            // Активируем/деактивируем кнопку прятания
            ShowHideButton(_playerCollisionDetector.IsNearByHidenObject);

            // Активируем/деактивируем кнопку подбора предметов
            ShowPickUpButton(_playerCollisionDetector.IsNearByPickableObject);
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
            FMODUnity.RuntimeManager.PlayOneShot("event:/Flashlight/FlashlightClik", GetComponent<Transform>().position);// Юрий добавил для звука включения фонарика
        }

        // Проверка состояния прятания
        if (IsHide != _wasHide)
        {
            _wasHide = IsHide; // Обновляем предыдущее состояние
            Debug.Log(IsHide ? "Подруга спряталась!" : "Подруга больше не прячется!");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Box/Box", GetComponent<Transform>().position);// Юрий добавил для звука Прятания в коробке
        }
    }
}