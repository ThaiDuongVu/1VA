using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;
    private static readonly int IsRunningTrigger = Animator.StringToHash("isRunning");
    private static readonly int IsCombatWalkingTrigger = Animator.StringToHash("isCombatWalking");
    private static readonly int EnterDashTrigger = Animator.StringToHash("enterDash");
    private static readonly int EnterCombatTrigger = Animator.StringToHash("enterCombat");
    private static readonly int ExitCombatTrigger = Animator.StringToHash("exitCombat");

    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    private float _currentVelocity;

    private const float MaxVelocity = 20f;
    private const float MinVelocity = 0f;
    private const float Acceleration = 50f;
    private const float Deceleration = 25f;

    private const float CombatVelocity = 10f;

    private const float DashForce = 60f;
    private const float DashDuration = 0.15f;

    private Vector2 _snapPosition;
    private const float SnapDistance = 2.5f;
    private const float SnapInterpolationRatio = 0.3f;

    private const float LookInterpolationRatio = 0.2f;
    private Camera _mainCamera;

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
        if (_player.IsDashing || Time.timeScale == 0f) return;

        // Set movement vector
        _movement = Quaternion.Euler(0f, 0f, _mainCamera.transform.eulerAngles.z) * context.ReadValue<Vector2>();

        // Play run animation
        _player.Animator.SetBool(IsRunningTrigger, true);
        _player.Animator.SetBool(IsCombatWalkingTrigger, true);

        _player.IsRunning = true;
    }

    private void MoveOnCanceled(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0f) return;

        // Reset movement vector
        _movement = Vector2.zero;

        // Stop run animation
        _player.Animator.SetBool(IsRunningTrigger, false);
        _player.Animator.SetBool(IsCombatWalkingTrigger, false);

        _player.IsRunning = false;
    }

    private void DashOnPerformed(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0f || _player.IsSnapping) return;

        // Start dashing if not already
        if (!_player.IsDashing) StartCoroutine(Dash());
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

        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale == 0f) return;

        // If player is running then accelerate
        if (_player.IsRunning) Accelerate();
        // If not then decelerate
        else Decelerate();

        Animate();
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 0f) return;

        // If player is running then run
        if (_player.IsRunning) Run();
        // If player is snapping then snap
        if (_player.IsSnapping) Snap();
    }

    // Move player to movement vector
    private void Run()
    {
        // Vector2 _movementDirection = Quaternion.Euler(0f, 0f, _mainCamera.transform.eulerAngles.z) * _movement;
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * _currentVelocity * Time.fixedDeltaTime);

        // Rotate player to movement direction
        LookForward();
    }

    private void Accelerate()
    {
        // Accelerate if current velocity is less than max velocity
        if (!_player.IsInCombat)
        {
            if (_currentVelocity < MaxVelocity) _currentVelocity += Acceleration * Time.deltaTime;
        }
        else
        {
            if (_currentVelocity < CombatVelocity) _currentVelocity += Acceleration * Time.deltaTime;
        }
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

    // Perform a dash move
    private IEnumerator Dash()
    {
        // Whether player was running at time of dash
        bool wasRunning = _player.IsRunning;

        // Set to dash state
        _player.IsRunning = false;
        _player.IsDashing = true;

        // Enable player trail
        _player.trail.enabled = true;

        // Play dash animation
        _player.Animator.SetTrigger(EnterDashTrigger);

        // Add force forward
        _rigidbody2D.AddForce(transform.up.normalized * DashForce, ForceMode2D.Impulse);

        // Shake camera
        CameraShake.Instance.ShakeLight();

        yield return new WaitForSeconds(DashDuration);

        // Stop player movement
        _rigidbody2D.velocity = Vector2.zero;

        // Stop dash animation
        _player.Animator.ResetTrigger(EnterDashTrigger);
        _player.Animator.SetTrigger(_player.IsInCombat ? EnterCombatTrigger : ExitCombatTrigger);

        // Reset running state
        _player.IsRunning = wasRunning;
        _player.IsDashing = false;

        yield return new WaitForSeconds(_player.trail.time);

        // Disable player trail
        if (!_player.IsDashing) _player.trail.enabled = false;
    }

    // Player look at moving direction
    private void LookForward()
    {
        // New look rotation
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, _movement);

        // Lerp current rotation to new look rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, LookInterpolationRatio * Time.timeScale);
    }
    
    // Scale animation speed to movement speed
    private void Animate()
    {
        // If player is not running then set animation speed to 1
        if (!_player.IsRunning)
        {
            _player.Animator.speed = 1f;
            return;
        }

        // If not then set animation speed to velocity length
        if (!_player.IsInCombat)
            _player.Animator.speed = _currentVelocity / MaxVelocity;
        else
            _player.Animator.speed = _currentVelocity / CombatVelocity;
    }

    // Start snapping
    public void StartSnapping(Enemy other)
    {
        // Set player snapping to true
        _player.IsSnapping = true;
        _player.IsRunning = false;

        // Enable trail
        _player.trail.enabled = true;

        // Set snap position
        _snapPosition = other.transform.position;

        // Set snap enemy
        _player.SnapEnemy = _player.LockedOnEnemy;
    }

    // Stop snapping
    private void StopSnapping()
    {
        // Set player snapping to false
        _player.IsSnapping = false;

        // Disable trail
        _player.trail.enabled = false;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, ((Vector2)_snapPosition - (Vector2)transform.position).normalized);

        // Deal damage to locked enemy
        CameraShake.Instance.ShakeNormal();
        _player.SnapEnemy.GetComponent<IDamageable>().TakeDamage(1f);
    }

    // Snap to an enemy
    private void Snap()
    {
        // Snap position
        transform.position = Vector2.Lerp(transform.position, _snapPosition, SnapInterpolationRatio);

        // Snap rotation
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, ((Vector2)_snapPosition - (Vector2)transform.position).normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, SnapInterpolationRatio * Time.timeScale);

        // If snapped then stop snapping
        if (GlobalController.CloseTo(transform.position.x, _snapPosition.x, SnapDistance) && GlobalController.CloseTo(transform.position.y, _snapPosition.y, SnapDistance))
            StopSnapping();
    }
}