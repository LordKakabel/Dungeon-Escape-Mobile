using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private Animator _swordArcAnimator = null;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        if (!_animator)
            Debug.LogError(name + ": Animator component not found!");

        if (!_swordArcAnimator)
            Debug.LogError(name + ": Sowrd Arc Animator not assigned!");
    }

    public void Move(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jumping(bool isJumping)
    {
        _animator.SetBool("IsJumping", isJumping);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
        _swordArcAnimator.SetTrigger("Attack");
    }

    public void Die()
    {
        _animator.SetTrigger("Death");
    }
}
