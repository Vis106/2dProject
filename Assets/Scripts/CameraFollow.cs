using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothFactor;

    private void Update()
    {
        Folllow();
    }

    private void Folllow()
    {
        Vector3 targetPosition = _target.position + _offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, _smoothFactor * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
