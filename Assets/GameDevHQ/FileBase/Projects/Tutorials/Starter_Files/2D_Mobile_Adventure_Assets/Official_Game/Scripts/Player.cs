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
    private PlayerAnimation _animation;
    private SpriteRenderer _sprite;
    [SerializeField] private SpriteRenderer _swordSprite;
    [SerializeField] private float _swordSpriteX = 1.01f;
    private bool _isGrounded = false;

    private void Awake()
    {
        #region NullCheck

        _rigidbody = GetComponent<Rigidbody2D>();
        if (!_rigidbody)
            Debug.LogError(name + ": Rigidbody2D component not found!");

        _animation = GetComponent<PlayerAnimation>();
        if (!_animation)
            Debug.LogError(name + ": PlayerAnimation script not found!");

        _sprite = GetComponentInChildren<SpriteRenderer>();
        if (!_sprite)
            Debug.LogError(name + ": SpriteRenderer component not found in children!");

        if (!_swordSprite)
            Debug.LogError(name + ": Sword SpriteRenderer component not assigned!");

        #endregion
    }

    void Update()
    {
        Movement();

        if (Input.GetButtonDown("Fire1") && IsGrounded())
        {
            _animation.Attack();
        }
    }

    private void Movement()
    {
        _isGrounded = IsGrounded();

        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        HandleFlip(horizontalMovement);

        // Jump
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpPower);
            StartCoroutine(ResetJumpRoutine());
            _animation.Jumping(true);
        }

        _rigidbody.velocity = new Vector2(horizontalMovement * _speed, _rigidbody.velocity.y);

        _animation.Move(horizontalMovement);
    }

    private void HandleFlip(float horizontalMovement)
    {
        if (horizontalMovement < 0)
        {
            _sprite.flipX = true;
            _swordSprite.flipX = true;
            _swordSprite.flipY = true;

            Vector3 newPosition = _swordSprite.transform.localPosition;
            newPosition.x = _swordSpriteX * -1f;
            _swordSprite.transform.localPosition = newPosition;

        }
        else if (horizontalMovement > 0)
        {
            _sprite.flipX = false;
            _swordSprite.flipX = false;
            _swordSprite.flipY = false;

            Vector3 newPosition = _swordSprite.transform.localPosition;
            newPosition.x = _swordSpriteX;
            _swordSprite.transform.localPosition = newPosition;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _groundRayLength, _groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * _groundRayLength, Color.green, 0.1f);

        if (hitInfo.collider)
        {
            if (!_isJumpResetNeeded)
            {
                _animation.Jumping(false);
                return true;
            }
        }

        return false;
    }

    private IEnumerator ResetJumpRoutine()
    {
        _isJumpResetNeeded = true;
        yield return new WaitForSeconds(0.1f);
        _isJumpResetNeeded = false;
    }
}
