using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Dying += EnemyDied;
    }

    private void OnDisable()
    {
        _enemy.Dying -= EnemyDied;
    }

    private void EnemyDied(Enemy enemy)
    {
        NeedTransit = true;
    }
}
