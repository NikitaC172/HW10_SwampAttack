using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : Weapon
{
    [SerializeField] protected Hit Hit;
    [SerializeField] protected int Damage;

    public override void Shoot(Transform shootPoint) { }
}
