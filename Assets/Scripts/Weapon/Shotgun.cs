using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangedWeapon
{
    public override void Shoot(Transform shootPoint)
    {
        _isReadyShoot = false;
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        Invoke("Reload", _delayBetweenShoot);
    }

    private void Reload()
    {
        _isReadyShoot = true;
    }
}
