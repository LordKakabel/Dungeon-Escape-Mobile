using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField] private GameObject _acidPrefab = null;
    [SerializeField] private Transform _acidFirePoint = null;

    public int Health { get; set; }

    protected override void Init()
    {
        base.Init();

        if (!_acidPrefab)
            Debug.Log(name + ": Acid prefab not assigned!");

        if (!_acidFirePoint)
            Debug.Log(name + ": Acid fire transform not assigned!");

        Health = _health;
    }

    protected override void Update()
    {
        
    }

    protected override void Attack()
    {
        Debug.Log(name + " bites you--you lose " + _damage + " health points!");
    }

    protected override void Movement()
    {
        // No movement
    }

    public void Fire()
    {
        Instantiate(_acidPrefab, _acidFirePoint.position, Quaternion.identity);
    }

    public void Damage()
    {
        if (_isDead)
            return;

        Health--;

        if (Health < 1)
        {
            _animator.SetTrigger("Death");
            _isDead = true;
        }
    }
}