using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private int _damage;
    private float _delayRemove = 0.5f;

    private void OnEnable()
    {
        Invoke(nameof(Remove), _delayRemove);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
