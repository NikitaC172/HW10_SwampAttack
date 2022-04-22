using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealth;
    private float _timeRemovePlayer = 5f;
    private float _timeChangeWeapon = 0.5f;
    private Animator _animator;
    private AudioSource _audioSource;

    public int Money { get; private set; }
    public int CurrentHealth => _currentHealth;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction DeadPlayer;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();        
        _currentWeapon = _weapons[0];
        _currentWeapon.SetReadyToShoot();
        _currentHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            DeadPlayer?.Invoke();
            _animator.Play("Dead");
            Invoke("RemovePlayer", _timeRemovePlayer);
        }
    }

    public void Attack()
    {
        if (_currentWeapon.IsReadyShoot)
        {            
            _audioSource.PlayOneShot(_currentWeapon.ShootSound);
            _currentWeapon.Shoot(_shootPoint);
            _animator.Play(_currentWeapon.ShootWeaponAnimation);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
        MoneyChanged?.Invoke(Money);
    }

    public void NextWeapon()
    {
        _animator.Play(_currentWeapon.RemoveWeaponAnimation);

        if (_currentWeaponNumber == _weapons.Count - 1)
        {
            _currentWeaponNumber = 0;
        }
        else
        {
            _currentWeaponNumber++;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        _animator.Play(_currentWeapon.RemoveWeaponAnimation);

        if (_currentWeaponNumber == 0)
        {
            _currentWeaponNumber = _weapons.Count - 1;
        }
        else
        {
            _currentWeaponNumber--;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        Invoke("SetWeapon", _timeChangeWeapon);
    }

    private void SetWeapon()
    {
        _animator.Play(_currentWeapon.AcceptWeaponAnimation);
        _currentWeapon.SetReadyToShoot();
    }

    private void RemovePlayer()
    {
        Destroy(gameObject);
    }

    private void OnEnemyDied(int reward)
    {
        Money += reward;
    }
}
