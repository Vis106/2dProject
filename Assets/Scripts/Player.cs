using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _groundCheckMask;

    private const float GroundCheckRadius = 0.2F;

    private PlayerInput _playerInput;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private bool _movingRight = false;
    private Vector3 _startPosition;

    private Vector2 _direction;
    private Vector3 _currentPosition;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _startPosition = transform.position;
    }

    private void Update()
    {
        _currentPosition = transform.position;
        _direction = _playerInput.Player.Move.ReadValue<Vector2>();

        Movement.Move(_moveSpeed, _direction, _currentPosition, gameObject, out Vector3 between);
        Animate(between.magnitude);

        if (_direction.x < 0 && !_movingRight)
             Movement.Flip(gameObject, ref _movingRight);
        else if (_direction.x > 0 && _movingRight)
            Movement.Flip(gameObject, ref _movingRight);

        if (_direction.y > 0)
            Movement.Jump(_rigidBody,_jumpForce, ControlGround.CheckGround(_groundCheckPoint, _groundCheckMask, GroundCheckRadius));
    }

    public void ReturnToStart()
    {
        transform.position = _startPosition;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    
    private void Animate(float speed)
    {
        _animator.SetFloat(HashAnimationNames.PlayerAnimation.SpeedHash, speed);
    }
}
