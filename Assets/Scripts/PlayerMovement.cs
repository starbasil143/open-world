using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _dashSpeed = 50f;
    [SerializeField] private float _dashLength = .3f;
    [SerializeField] private float _dashCooldown;

    private float currentDashCooldown = 0f;
    private bool isDashing;
    //private bool canDash = true;
    private Vector2 lastDirection;
    public bool isPaused;

    
    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";
    
    private Vector2 _movement;
    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isPaused)
        {
            // Movement

            if (InputManager.Dash && currentDashCooldown <= 0) // Dashing
            {
                isDashing = true;
                currentDashCooldown = _dashCooldown;
                _movement = lastDirection;
            }
        }
    }
    private void FixedUpdate()
    {
        if (!isPaused)
        {
            // Movement

            if (!isDashing) // Walking
            {
                _movement.Set(InputManager.Movement.x, InputManager.Movement.y);
                _rigidbody.linearVelocity = _movement * _moveSpeed;
            }
            
            if (isDashing)
            {
                _rigidbody.linearVelocity = _movement * Mathf.Lerp(_dashSpeed, _moveSpeed, (_dashCooldown - currentDashCooldown)/_dashLength);

                if (_dashCooldown - currentDashCooldown >= _dashLength)
                {
                    isDashing = false;
                }
            }
            if (currentDashCooldown > 0)
            {
                currentDashCooldown -= Time.deltaTime;
                if (currentDashCooldown <= 0)
                {
                    isDashing = false;
                }
            }

            if (_movement != Vector2.zero)
            {
                lastDirection = _movement;
            }
        }
    }
    
    /*
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        _rigidbody.linearVelocity = new Vector2();
        float i = 0;
        float dashCompletion = 0;
        while (i < _dashLength)
        {
            i += Time.deltaTime;
            dashCompletion  = i/_dashLength;
            _rigidbody.linearVelocity = Lerp();

        }
    }*/


}

