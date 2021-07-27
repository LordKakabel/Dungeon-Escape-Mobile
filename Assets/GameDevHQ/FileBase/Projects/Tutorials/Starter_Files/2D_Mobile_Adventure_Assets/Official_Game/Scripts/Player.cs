using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 5f;
    [SerializeField] private float _groundRayLength = 1f;
    [SerializeField] private LayerMask _groundLayer = 0;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded = false;
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
        CheckGrounded();
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");

        // Jump
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpPower);
            _isGrounded = false;
            _isJumpResetNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());
        }

        _rigidbody.velocity = new Vector2(x, _rigidbody.velocity.y);
    }

    private void CheckGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _groundRayLength, _groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * _groundRayLength, Color.green);

        if (hitInfo.collider != null)
        {
            if (!_isJumpResetNeeded)
                _isGrounded = true;
        }
    }

    private IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _isJumpResetNeeded = false;
    }
}
