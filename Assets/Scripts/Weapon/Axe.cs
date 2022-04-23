using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MeleeWeapon
{
    public override void Shoot(Transform shootPoint)
    {
        _isReadyShoot = false;
        Hit hit = Instantiate(Hit, shootPoint.position, Quaternion.identity);
        hit.SetDamage(Damage);
        Invoke(nameof(Reload), _delayBetweenShoot);
    }

    private void Reload()
    {
        _isReadyShoot = true;
    }
}
