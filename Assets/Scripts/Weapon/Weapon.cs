using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;
    [SerializeField] private string _acceptWeaponAnimation = null;
    [SerializeField] private string _removeWeaponAnimation = null;
    [SerializeField] private string _shootWeaponAnimation = null;
    [SerializeField] private AudioClip _shootSound = null;
    
    [SerializeField] protected float _delayBetweenShoot;

    protected bool _isReadyShoot = false;

    public AudioClip ShootSound => _shootSound;
    public string AcceptWeaponAnimation => _acceptWeaponAnimation;
    public string RemoveWeaponAnimation => _removeWeaponAnimation;
    public string ShootWeaponAnimation => _shootWeaponAnimation;
    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public bool IsReadyShoot => _isReadyShoot;

    public abstract void Shoot(Transform shootPoint);

    public void SetReadyToShoot()
    {
        _isReadyShoot = true;
    }

    public void Buy()
    {
        _isBuyed = true;
    }
}
