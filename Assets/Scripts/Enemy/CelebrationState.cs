using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private Animator _animator;
    private string _celebrationAnimation = "Celebration";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(_celebrationAnimation);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
