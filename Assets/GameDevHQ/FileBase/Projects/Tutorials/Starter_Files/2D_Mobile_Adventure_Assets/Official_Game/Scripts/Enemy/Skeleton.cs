using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    protected override void Init()
    {
        base.Init();
        Health = _health;
    }

    public void Damage()
    {
        if (_isDead)
            return;

        _isHit = true;
        _animator.SetTrigger("Hit");
        _animator.SetBool("IsInCombat", true);
        Health--;

        if (Health < 1)
        {
            _animator.SetTrigger("Death");
            _isDead = true;
        }
    }

    protected override void Attack()
    {
        Debug.Log("Skeleton attacks with sword for " + _damage + " points of damage!");
    }
}
