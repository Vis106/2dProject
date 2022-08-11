using UnityEngine;

[RequireComponent(typeof(Animator))]
public class House : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.SetBool(HashAnimationNames.HouseAnimation.IsClosed, false);
    }

    public void Close()
    {
        _animator.SetBool(HashAnimationNames.HouseAnimation.IsClosed, true);
    }
}
