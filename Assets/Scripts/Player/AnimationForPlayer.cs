using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class AnimationForPlayer : MonoBehaviour
{
    private Player _player = null;
    private Animator _animator = null;
    private string _deadAnimation = "Dead";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.AcceptWeapon += AcceptWeapon;
        _player.RemoveWeapon += RemoveWeapon;
        _player.ShootWeapon += ShootWeapon;
        _player.DeadPlayer += DeadPlayer;
    }

    private void OnDisable()
    {
        _player.AcceptWeapon -= AcceptWeapon;
        _player.RemoveWeapon -= RemoveWeapon;
        _player.ShootWeapon -= ShootWeapon;
        _player.DeadPlayer -= DeadPlayer;
    }

    private void AcceptWeapon()
    {
        _animator.Play(_player.CurrentWeapon.AcceptWeaponAnimation);
    }

    private void RemoveWeapon()
    {
        _animator.Play(_player.CurrentWeapon.RemoveWeaponAnimation);
    }

    private void ShootWeapon()
    {
        _animator.Play(_player.CurrentWeapon.ShootWeaponAnimation);
    }

    private void DeadPlayer()
    {
        _animator.Play(_deadAnimation);
    }
}
