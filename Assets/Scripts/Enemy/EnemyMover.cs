using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _groundDetection;
    [SerializeField] private LayerMask _groundCheckMask;

    private bool _movingRight = true;

    private const float GroundCheckRadius = 0.2F;

    private void Update()
    {
        if (_movingRight)
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (CheckEndPlatform())
            Flip();
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        _movingRight = !_movingRight;
    }

    private bool CheckEndPlatform()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundDetection.position, GroundCheckRadius, _groundCheckMask);

        return colliders.Length == 0;
    }
}
