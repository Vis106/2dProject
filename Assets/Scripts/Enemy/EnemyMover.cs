using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _groundDetection;
    [SerializeField] private LayerMask _groundCheckMask;

    private bool _movingRight = true;
    private bool _isReachedEndPlatform=false;
    private const float __groundCheckRadius = 0.2F;

    private void Start()
    {
        //Vector3 currentScale = gameObject.transform.localScale;
        //currentScale.x = -1;
        //gameObject.transform.localScale = currentScale;
    }

    private void Update()
    {
        if (_movingRight)
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

        GroundCheck();

        if (_isReachedEndPlatform)
            Flip();
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
        _isReachedEndPlatform = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundDetection.position, __groundCheckRadius, _groundCheckMask);

        if (colliders.Length == 0)
            _isReachedEndPlatform = true;
    }
}
