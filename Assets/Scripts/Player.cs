using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private PlayerInput _playerInput;
    private Animator _animator;   

    private Vector2 _direction;
    private Vector3 _currentPosition;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();       
    }

    private void Update()
    {
        _currentPosition = transform.position;
        _direction = _playerInput.Player.Move.ReadValue<Vector2>();
        Move(_direction);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Move(Vector2 direction)
    {
        Vector3 move = new Vector3(direction.x, direction.y);

        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;

        Vector3 targetPosition = _currentPosition + move;
        Vector3 newPosition = Vector3.MoveTowards(_currentPosition, targetPosition, scaledMoveSpeed);

        transform.position = newPosition;

        Vector3 between = newPosition - _currentPosition;
        Animate(between.magnitude);

    }

    private void Animate(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}
