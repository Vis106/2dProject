using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _groundCheckMask;

    
    private const float __groundCheckRadius = 0.2F;
    private PlayerInput _playerInput;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private bool _movingRight = true;
    private bool _isGrounded;
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
        Move(_direction);

        if (_direction.x < 0 && !_movingRight)
            Flip();
        else if (_direction.x > 0 && _movingRight)
            Flip();         

        if (_direction.y > 0)
            Jump(_jumpForce);
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

    private void Jump(float jumpForce)
    {
        GroundCheck();
        if (_isGrounded)
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
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
        _animator.SetFloat(HashAnimationNames.PlayerAnimation.SpeedHash, speed);
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        _movingRight = !_movingRight;
    }

    private void GroundCheck()
    {
        _isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheckPoint.position, __groundCheckRadius, _groundCheckMask);

        if (colliders.Length > 0)
            _isGrounded = true;
    }    
}
