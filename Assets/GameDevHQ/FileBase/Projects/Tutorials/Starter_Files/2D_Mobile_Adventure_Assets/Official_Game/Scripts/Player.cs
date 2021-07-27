using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpPower = 5f;
    [SerializeField] private float _groundRayLength = 1f;
    [SerializeField] private LayerMask _groundLayer = 0;

    private Rigidbody2D _rigidbody;
    private bool _isJumpResetNeeded = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (!_rigidbody)
            Debug.LogError(name + ": Rigidbody2D component not found!");
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal") * _speed;

        _rigidbody.velocity = new Vector2(x, _rigidbody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpPower);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _groundRayLength, _groundLayer);

        if (hitInfo.collider)
            if (!_isJumpResetNeeded)
                return true;

        return false;
    }

    private IEnumerator ResetJumpRoutine()
    {
        _isJumpResetNeeded = true;
        yield return new WaitForSeconds(0.1f);
        _isJumpResetNeeded = false;
    }
}
