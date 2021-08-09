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
    [SerializeField] protected float _detectionRadius = 2f;

    protected Vector3 _target;
    protected Animator _animator;
    protected SpriteRenderer _sprite;
    protected bool _isHit = false;
    protected Player _player;
    protected bool _isDead = false;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        #region Null Checks

        _animator = GetComponentInChildren<Animator>();
        if (!_animator)
            Debug.LogError(name + ": Animator component not found in children!");

        _sprite = GetComponentInChildren<SpriteRenderer>();
        if (!_sprite)
            Debug.LogError(name + ": SpriteRenderer component not found in children!");

        _player = FindObjectOfType<Player>();
        if (!_player)
            Debug.LogError(name + ": Player GameObject not found in scene!");

        #endregion

        _target = _pointB.position;
    }

    protected virtual void SayHello()
    {
        Debug.Log("Oh hia! I'm a " + gameObject.name);
    }

    protected abstract void Attack();

    protected virtual void Update()
    {
        // If Idle animation is playing OR we are dead,
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && _animator.GetBool("IsInCombat")==false || _isDead)
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

        if (_isHit == false)
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, _player.transform.position);
        if (distance > _detectionRadius)
        {
            _isHit = false;
            _animator.SetBool("IsInCombat", false);
        }

        Vector3 direction = _player.transform.position - transform.position;
        if (direction.x > 0 && _animator.GetBool("IsInCombat") == true)
        {
            _sprite.flipX = false;
        }
        else if (direction.x < 0 && _animator.GetBool("IsInCombat") == true)
        {
            _sprite.flipX = true;
        }
    }

    protected void DropDiamond()
    {
        GameObject diamondInstance = Instantiate(
            Resources.Load("Diamond") as GameObject,
            transform.position,
            Quaternion.identity);

        Diamond diamond = diamondInstance.GetComponent<Diamond>();
        if (diamond != null)
        {
            diamond.AssignValue(_gems);
        }
    }
}
