using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 direction = _inputReader.Direction;
        if (direction.magnitude > 0.1f)
        {
            _playerMover.MovePlayer(direction);
        }
        else
        {
            _playerMover.MovePlayer(Vector2.zero);
        }
    }
}
