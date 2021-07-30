using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;
    [SerializeField] protected int damage;
    [SerializeField] protected Transform pointA, pointB;
    
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

    public abstract void Update();
}
