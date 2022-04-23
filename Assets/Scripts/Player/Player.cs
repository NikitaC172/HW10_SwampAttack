using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealth;
    private bool _isDead = false;
    private float _timeRemovePlayer = 5f;
    private float _timeChangeWeapon = 0.5f;

    public int Money { get; private set; }
    public int CurrentHealth => _currentHealth;
    public Weapon CurrentWeapon => _currentWeapon;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction DeadPlayer;
    public event UnityAction RemoveWeapon;
    public event UnityAction AcceptWeapon;
    public event UnityAction ShootWeapon;

    private void Start()
    {
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
            if (_isDead == false)
            {
                _isDead = true;
                DeadPlayer?.Invoke();
                Invoke(nameof(RemovePlayer), _timeRemovePlayer);
            }
        }
    }

    public void Attack()
    {
        if (_currentWeapon.IsReadyShoot)
        {
            _currentWeapon.Shoot(_shootPoint);
            ShootWeapon?.Invoke();
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
        RemoveWeapon?.Invoke();

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
        RemoveWeapon?.Invoke();

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
        Invoke(nameof(SetWeapon), _timeChangeWeapon);
    }

    private void SetWeapon()
    {
        AcceptWeapon?.Invoke();
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
