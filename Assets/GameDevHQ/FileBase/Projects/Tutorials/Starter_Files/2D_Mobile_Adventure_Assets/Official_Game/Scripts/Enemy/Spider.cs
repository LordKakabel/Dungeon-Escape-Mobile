using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    public override void Attack()
    {
        Debug.Log(name + " bites you--you lose " + damage + " health points!");
    }
}
