using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    protected override void Attack()
    {
        Debug.Log(name + " bites you--you lose " + _damage + " health points!");
    }

    protected override void Movement()
    {
        // No movement
    }
}