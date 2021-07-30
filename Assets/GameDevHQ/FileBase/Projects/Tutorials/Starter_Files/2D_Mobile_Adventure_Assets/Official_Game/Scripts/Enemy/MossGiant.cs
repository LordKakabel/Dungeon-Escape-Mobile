using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    public override void SayHello()
    {
        base.SayHello();
        Debug.Log("I like long walks through the swamp.");
    }
    public override void Attack()
    {
        Debug.Log("I'll smash you for " + damage + " points of damage!");
    }
}
