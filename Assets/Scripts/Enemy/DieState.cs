using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Reproducer))]
[RequireComponent(typeof(Animator))]
public class DieState : State
{
    private Reproducer _sound;
    private Animator _animator;

    private void Awake()
    {
        _sound = GetComponent<Reproducer>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _sound.PlaySoundDie();
        _animator.Play("Die");
    }
}
