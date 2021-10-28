using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 3.0f;

    private PlayerControls _playerControls;
    private Rigidbody2D _playerRigidbody;
    private Animator _playerAnimator;
    private SpriteRenderer _playerSprite;

    private bool _isGrounded;
    [SerializeField] private bool _isAttacking;
    [SerializeField] private bool _isMoving;
    private bool _isJumping;
    private bool _canAttack = true;
    private Vector2 _currentMovementInput;
    private Vector3 _currentMovement;

    private float _attackRate = 0.5f;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }

    private void InputActionSubscribe()
    {
        _playerControls.CharacterControl.Attack1.started += OnAttack;
        _playerControls.CharacterControl.Attack1.canceled += OnAttack;
        _playerControls.CharacterControl.Jump.started += OnJump;
    }

    // Start is called before the first frame update
    void Start()
    {
        InputActionSubscribe();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (_isGrounded == true && _canAttack == true)
        {
            _currentMovementInput = _playerControls.CharacterControl.Move.ReadValue<Vector2>();
            FlipSprite(_currentMovementInput.x);
            _currentMovement.x = _currentMovementInput.x * _playerSpeed;
            _playerAnimator.SetFloat("playerMoving", Mathf.Abs(_currentMovementInput.x));
            _playerRigidbody.transform.Translate(_currentMovement * Time.deltaTime);
        }        
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        //_isJumping
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        _isAttacking = context.ReadValueAsButton();
        StartCoroutine(AttackCoroutine());
    }

    private void OnAttackEnd(InputAction.CallbackContext context)
    {
        _isAttacking = context.ReadValueAsButton();
    }

    private IEnumerator AttackCoroutine()
    {
        if (_canAttack == true && _isAttacking == true)
        {
            _canAttack = false;
            _playerAnimator.SetTrigger("playerAttack1");
            yield return new WaitForSeconds(_attackRate);
            _canAttack = true;
        }        
    }

    private void FlipSprite(float direction)
    {
        if (direction > 0)
        {
            _playerSprite.flipX = false;
        }
        else if (direction < 0)
        {
            _playerSprite.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    private void OnEnable()
    {
        _playerControls.CharacterControl.Enable();
        Debug.Log("Player controls enabled.");
    }

    private void OnDisable()
    {
        _playerControls.CharacterControl.Disable();
        Debug.Log("Player controls disabled.");
    }
}
