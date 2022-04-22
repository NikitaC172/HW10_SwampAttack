using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    [SerializeField] protected Bullet Bullet;

    public override void Shoot(Transform shootPoint) { }
}

