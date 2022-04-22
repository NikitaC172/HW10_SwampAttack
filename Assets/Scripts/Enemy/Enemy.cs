using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Reproducer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    private Player _target;
    private Reproducer _sound;
    private BoxCollider2D _collider;

    public Player Target => _target;
    public int Reward => _reward;

    public event UnityAction<Enemy> Dying;

    private void Awake()
    {
        _sound = GetComponent<Reproducer>();
        _collider = GetComponent<BoxCollider2D>();
        _sound.PlaySoundAwake();
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _sound.PlaySoundHurt();

        if (_health <= 0)
        {
            _collider.enabled = false;
            Dying?.Invoke(this);
            Invoke("Remove", 4f);
        }
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
