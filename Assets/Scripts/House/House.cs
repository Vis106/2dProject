using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.SetBool("IsClosed", false);
    }

    public void Close()
    {
        _animator.SetBool("IsClosed", true);
    }
}
