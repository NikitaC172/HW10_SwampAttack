using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundForPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private Player _player = null;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.ShootWeapon += ShootWeapon;
    }

    private void OnDisable()
    {
        _player.ShootWeapon -= ShootWeapon;
    }

    private void ShootWeapon()
    {
        _audioSource.PlayOneShot(_player.CurrentWeapon.ShootSound);
    }
}
