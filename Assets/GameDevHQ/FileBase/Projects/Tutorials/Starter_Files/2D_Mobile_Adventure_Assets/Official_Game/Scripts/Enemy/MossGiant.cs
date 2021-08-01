using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    protected override void SayHello()
    {
        base.SayHello();
        Debug.Log("I like long walks through the swamp.");
    }
    protected override void Attack()
    {
        Debug.Log("I'll smash you for " + _damage + " points of damage!");
    }
}
