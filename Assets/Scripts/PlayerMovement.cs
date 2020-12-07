using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    private float _currentVelocity;

    private const float MaxVelocity = 20f;
    private const float MinVelocity = 0f;
    private const float Acceleration = 50f;
    private const float Deceleration = 25f;

    private const float CombatVelocity = 10f;

    private const float DashForce = 50f;
    private const float DashDuration = 0.15f;

    private const float LookInterpolationRatio = 0.15f;

    private InputManager _inputManager;

    private void OnEnable()
    {
        _inputManager = new InputManager();

        // Handle movement keyboard input
        _inputManager.Player.MoveKeyboard.performed += MoveOnPerformed;
        _inputManager.Player.MoveKeyboard.canceled += MoveOnCanceled;

        // Handle movement gamepad input
        _inputManager.Player.MoveGamepad.performed += MoveOnPerformed;
        _inputManager.Player.MoveGamepad.canceled += MoveOnCanceled;

        // Handle dash input
        _inputManager.Player.Dash.performed += DashOnPerformed;

        _inputManager.Enable();
    }

    #region Input Methods

    private void MoveOnPerformed(InputAction.CallbackContext context)
    {
        // If player is in a middle of a dash then return
        if (_player.isDashing || Time.timeScale == 0f) return;

        // Set movement vector
        _movement = context.ReadValue<Vector2>();

        // Play run animation
        _player.animator.SetBool("isRunning", true);
        _player.animator.SetBool("isCombatWalking", true);

        _player.isRunning = true;
    }

    private void MoveOnCanceled(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0f) return;

        // Reset movement vector
        _movement = Vector2.zero;

        // Stop run animation
        _player.animator.SetBool("isRunning", false);
        _player.animator.SetBool("isCombatWalking", false);

        _player.isRunning = false;
    }

    private void DashOnPerformed(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0f) return;

        // Start dashing if not already
        if (!_player.isDashing) StartCoroutine(Dash());
    }

    #endregion

    private void OnDisable()
    {
        _inputManager.Disable();
    }

    private void Awake()
    {
        // Get component references
        _player = GetComponent<Player>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale == 0f) return;

        // If player is running then accelerate
        if (_player.isRunning) Accelerate();
        // If not then decelerate
        else Decelerate();

        Animate();
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 0f) return;

        if (_player.isRunning) Run();
    }

    // Move player to movement vector
    private void Run()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * _currentVelocity * Time.fixedDeltaTime);
    }

    private void Accelerate()
    {
        // Accelerate if current velocity is less than max velocity
        if (!_player.isInCombat)
        {
            if (_currentVelocity < MaxVelocity) _currentVelocity += Acceleration * Time.deltaTime;
        }
        else
        {
            if (_currentVelocity < CombatVelocity) _currentVelocity += Acceleration * Time.deltaTime;
        }

        // Rotate player to movement direction
        Look();
    }

    private void Decelerate()
    {
        // Decelerate if current velocity is greater than min velocity
        if (_currentVelocity > MinVelocity) _currentVelocity -= Deceleration * Time.deltaTime;

        // If player near stopping then stop
        if (Mathf.Abs(_currentVelocity - MinVelocity) < 0.1f) Stop();
    }

    // Stop running
    public void Stop()
    {
        _currentVelocity = 0f;
    }

    // Dash move
    private IEnumerator Dash()
    {
        // Whether player was running at time of dash
        bool wasRunning = _player.isRunning;

        // Set to dash state
        _player.isRunning = false;
        _player.isDashing = true;

        // Enable player trail
        _player.trail.enabled = true;

        // Play dash animation
        _player.animator.SetTrigger("enterDash");

        // Add force forward
        _rigidbody2D.AddForce(transform.up.normalized * DashForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(DashDuration);

        // Stop player movement
        _rigidbody2D.velocity = Vector2.zero;

        // Stop dash animation
        _player.animator.ResetTrigger("enterDash");
        if (_player.isInCombat) _player.animator.SetTrigger("enterCombat");
        else _player.animator.SetTrigger("exitCombat");

        // Reset running state
        _player.isRunning = wasRunning;
        _player.isDashing = false;

        yield return new WaitForSeconds(_player.trail.time);

        // Disable player trail
        if (!_player.isDashing) _player.trail.enabled = false;
    }

    private void Look()
    {
        // New look rotation
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, _movement);

        // Lerp current rotation to new look rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, LookInterpolationRatio * Time.timeScale);
    }

    private void Animate()
    {
        // If player is not running then set animation speed to 1
        if (!_player.isRunning)
        {
            _player.animator.speed = 1f;
            return;
        }
        // If not then set animation speed to velocity length
        if (!_player.isInCombat)
            _player.animator.speed = _currentVelocity / MaxVelocity;
        else
            _player.animator.speed = _currentVelocity / CombatVelocity;
    }
}
