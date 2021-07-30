using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int health;
    protected int speed;
    protected int gems;
    protected int damage;

    public void Start()
    {
        SayHello();
        Attack();
    }

    public virtual void SayHello()
    {
        Debug.Log("Oh hia! I'm a " + gameObject.name);
    }

    public abstract void Attack();
}
