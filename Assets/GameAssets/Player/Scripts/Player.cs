using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerLight _playerLight;
    [SerializeField] private PlayerCollisionDetector _playerCollisionDetector;

    public bool IsMoving { get; private set; }

    private void Update()
    {
        HandleLight();
        HandleItemPickup();
        TwitchPlayerLight();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
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
        // Включаем или выключаем свет в зависимости от состояния IsLightSwitch
        if (_inputReader.IsLightSwitch)
        {
            _playerLight.TurnOnThePlayerLight();

            // Звук включения лампы: Воспроизводится при включении света.
        }
        else
        {
            _playerLight.TurnOffThePlayerLight();

            // Звук выключения лампы: Воспроизводится при выключении света.
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
}