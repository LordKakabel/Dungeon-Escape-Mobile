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
        _isHit = true;
        _animator.SetTrigger("Hit");
        _animator.SetBool("IsInCombat", true);
        Health--;

        if (Health < 1)
            Destroy(transform.parent.gameObject);
    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
