using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    protected override void Init()
    {
        base.Init();
        Health = _health;
    }

    protected override void SayHello()
    {
        base.SayHello();
        Debug.Log("I like long walks through the swamp.");
    }

    protected override void Attack()
    {
        Debug.Log("I'll smash you for " + _damage + " points of damage!");
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
}
