using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int _health;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _gems;
    [SerializeField] protected int _damage;
    [SerializeField] protected Transform _pointA, _pointB;

    protected Vector3 _target;
    protected Animator _animator;
    protected SpriteRenderer _sprite;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        _animator = GetComponentInChildren<Animator>();
        if (!_animator)
            Debug.LogError(name + ": Animator component not found in children!");

        _sprite = GetComponentInChildren<SpriteRenderer>();
        if (!_sprite)
            Debug.LogError(name + ": SpriteRenderer component not found in children!");

        _target = _pointB.position;
    }

    protected virtual void SayHello()
    {
        Debug.Log("Oh hia! I'm a " + gameObject.name);
    }

    protected abstract void Attack();

    protected virtual void Update()
    {
        // If Idle animation is playing,
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return;

        Movement();
    }

    protected virtual void Movement()
    {
        if (_target == _pointA.position)
            _sprite.flipX = true;
        else
            _sprite.flipX = false;

        if (transform.position == _pointA.position)
        {
            _target = _pointB.position;
            _animator.SetTrigger("Idle");
        }
        else if (transform.position == _pointB.position)
        {
            _target = _pointA.position;
            _animator.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }
}
