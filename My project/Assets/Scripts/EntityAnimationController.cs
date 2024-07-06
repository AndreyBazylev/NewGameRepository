using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void StartIdle()
    {
        _animator.SetFloat("HorizontalMove", 0);
        _animator.SetFloat("VerticalMove", 0);
    }

    public void GoDown()
    {
        _animator.SetFloat("HorizontalMove", 0);
        _animator.SetFloat("VerticalMove", -1);
    }

    public void GoUp()
    {
        _animator.SetFloat("HorizontalMove", 0);
        _animator.SetFloat("VerticalMove", 1);
    }

    public void GoRight()
    {
        _animator.SetFloat("HorizontalMove", 1);
        _animator.SetFloat("VerticalMove", 0);
    }

    public void GoLeft()
    {
        _animator.SetFloat("HorizontalMove", -1);
        _animator.SetFloat("VerticalMove", 0);
    }
}
