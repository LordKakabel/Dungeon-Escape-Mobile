using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _target;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        if (!_animator)
            Debug.LogError(name + ": Animator component not found in children!");

        _sprite = GetComponentInChildren<SpriteRenderer>();
        if (!_sprite)
            Debug.LogError(name + ": SpriteRenderer component not found in children!");

        _target = pointB.position;
    }

    public override void SayHello()
    {
        base.SayHello();
        Debug.Log("I like long walks through the swamp.");
    }
    public override void Attack()
    {
        Debug.Log("I'll smash you for " + damage + " points of damage!");
    }

    public override void Update()
    {
        // If Idle animation is playing,
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return;

        Movement();
    }

    void Movement()
    {
        if (_target == pointA.position)
            _sprite.flipX = true;
        else
            _sprite.flipX = false;

        if (transform.position == pointA.position)
        {
            _target = pointB.position;
            _animator.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            _target = pointA.position;
            _animator.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
    }
}
