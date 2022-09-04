using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;       

    private void Start()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x = -1;
        gameObject.transform.localScale = currentScale;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);        
    }
}
