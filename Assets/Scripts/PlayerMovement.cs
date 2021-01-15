using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    private static readonly int IsRunningTrigger = Animator.StringToHash("isRunning");
    private static readonly int EnterDashTrigger = Animator.StringToHash("enterDash");
    private static readonly int ExitDashTrigger = Animator.StringToHash("exitDash");

    private Rigidbody2D rigidBody2D;
    private Vector2 movement;
    private Vector2 direction;
    private float currentVelocity;

    private const float MaxVelocity = 30f;
    private const float MinVelocity = 0f;
    private const float Acceleration = 60f;
    private const float Deceleration = 30f;

    private const float DashForce = 60f;
    private const float DashDuration = 0.2f;

    private Vector2 snapPosition;
    private const float SnapDistance = 2.5f;
    private const float SnapInterpolationRatio = 0.25f;

    private float lookVelocity;
    private float lookSensitivity = 1.5f;

    private new Camera camera;
    private MainCamera mainCamera;

    private InputManager inputManager;

    /// <summary>
    /// Unity Event function.
    /// Initialize input handler on object enabled.
    /// </summary>
    private void OnEnable()
    {
        inputManager = new InputManager();

        // Handle movement keyboard input
        inputManager.Player.MoveKeyboard.performed += MoveOnPerformed;
        inputManager.Player.MoveKeyboard.canceled += MoveOnCanceled;

        // Handle movement gamepad input
        inputManager.Player.MoveGamepad.performed += MoveOnPerformed;
        inputManager.Player.MoveGamepad.canceled += MoveOnCanceled;

        // Look rotation
        inputManager.Player.Look.performed += LookOnPerformed;
        inputManager.Player.Look.canceled += LookOnCanceled;

        // Handle dash input
        inputManager.Player.Dash.performed += DashOnPerformed;

        inputManager.Enable();
    }

    #region Input Methods

    /// <summary>
    /// On move input performed.
    /// </summary>
    /// <param name="context">Input context</param>
    private void MoveOnPerformed(InputAction.CallbackContext context)
    {
        // Debug.Log(context.control.device == InputSystem.devices[0]);

        // If player is in a middle of a dash then return
        if (player.IsDashing || Time.timeScale == 0f || !player.IsControllable) return;

        // Set movement vector
        direction = context.ReadValue<Vector2>();

        // Play run animation
        player.Animator.SetBool(IsRunningTrigger, true);
        player.IsRunning = true;
    }

    /// <summary>
    /// On move input canceled.
    /// </summary>
    /// <param name="context">Input context</param>
    private void MoveOnCanceled(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0f) return;

        // Reset movement vector
        direction = Vector2.zero;

        // Stop run animation
        player.Animator.SetBool(IsRunningTrigger, false);
        player.IsRunning = false;
    }

    /// <summary>
    /// On look input performed.
    /// </summary>
    /// <param name="context">Input context</param>
    private void LookOnPerformed(InputAction.CallbackContext context)
    {
        if (!player.IsControllable) return;

        lookVelocity = context.ReadValue<Vector2>().x;
    }

    /// <summary>
    /// On look input canceled.
    /// </summary>
    /// <param name="context">Input context</param>
    private void LookOnCanceled(InputAction.CallbackContext context)
    {
        lookVelocity = 0f;
    }

    /// <summary>
    /// On dash input performed.
    /// </summary>
    /// <param name="context">Input context</param>
    private void DashOnPerformed(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 0f || player.IsSnapping || !player.IsControllable) return;

        // Start dashing if not already
        if (!player.IsDashing) StartCoroutine(Dash());
    }

    #endregion

    /// <summary>
    /// Unity Event function.
    /// Disable input handling on object disabled.
    /// </summary>
    private void OnDisable()
    {
        inputManager.Disable();
    }

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        player = GetComponent<Player>();
        rigidBody2D = GetComponent<Rigidbody2D>();

        camera = Camera.main;
        if (camera is { }) mainCamera = camera.GetComponent<MainCamera>();
    }

    /// <summary>
    /// Unity Event function.
    /// Update at consistent time.
    /// </summary>
    private void FixedUpdate()
    {
        if (Time.timeScale == 0f) return;

        // If player is running then accelerate
        if (player.IsRunning) Accelerate();
        // If not then decelerate
        else Decelerate();

        Animate();
        Rotate();

        // If player is running then run
        if (player.IsRunning) Run();

        // If player is snapping then snap
        if (player.IsSnapping) Snap();

        player.directionArrow.transform.up = Vector2.Lerp(player.directionArrow.transform.up, movement, 0.4f);
    }

    /// <summary>
    /// Move player to movement vector.
    /// </summary>
    private void Run()
    {
        movement = Quaternion.Euler(0f, 0f, camera.transform.eulerAngles.z) * direction;
        rigidBody2D.MovePosition(rigidBody2D.position + movement * (currentVelocity * Time.fixedDeltaTime));
    }

    /// <summary>
    /// Accelerate if current velocity is less than max velocity.
    /// </summary>
    private void Accelerate()
    {
        if (currentVelocity < MaxVelocity) currentVelocity += Acceleration * Time.deltaTime;
    }

    /// <summary>
    /// Decelerate if current velocity is greater than min velocity.
    /// </summary>
    private void Decelerate()
    {
        if (currentVelocity > MinVelocity) currentVelocity -= Deceleration * Time.deltaTime;
        // If player near stopping then stop
        if (Mathf.Abs(currentVelocity - MinVelocity) < 0.1f) Stop();
    }

    /// <summary>
    /// Stop running.
    /// </summary>
    public void Stop()
    {
        currentVelocity = 0f;
        direction = Vector2.zero;
    }

    /// <summary>
    /// Rotate to look velocity.
    /// </summary>
    private void Rotate()
    {
        if (Mathf.Abs(lookVelocity) <= 0.1f) return;

        transform.Rotate(0f, 0f, lookVelocity * lookSensitivity * Time.timeScale, Space.Self);
    }

    /// <summary>
    /// Perform a dash move.
    /// </summary>
    /// <returns>Dash duration</returns>
    private IEnumerator Dash()
    {
        // Whether player was running at time of dash
        bool wasRunning = player.IsRunning;

        // Set to dash state
        player.IsRunning = false;
        player.IsDashing = true;

        // Enable player trail
        player.trail.enabled = true;

        // Play dash animation
        player.Animator.SetTrigger(EnterDashTrigger);

        // Add force forward
        rigidBody2D.AddForce(movement * DashForce, ForceMode2D.Impulse);

        // Shake camera
        CameraShaker.Instance.Shake(CameraShakeMode.Light);

        yield return new WaitForSeconds(DashDuration);

        // Stop player movement
        rigidBody2D.velocity = Vector2.zero;

        // Stop dash animation
        player.Animator.ResetTrigger(EnterDashTrigger);
        player.Animator.SetTrigger(ExitDashTrigger);

        // Reset running state
        player.IsRunning = wasRunning;
        player.IsDashing = false;

        yield return new WaitForSeconds(player.trail.time);

        // Disable player trail
        if (!player.IsDashing) player.trail.enabled = false;
    }

    /// <summary>
    /// Scale animation speed to movement speed.
    /// </summary>
    private void Animate()
    {
        // If player is not running then set animation speed to 1
        if (!player.IsRunning)
        {
            player.Animator.speed = 1f;
            return;
        }

        // If not then set animation speed to velocity length
        player.Animator.speed = currentVelocity / MaxVelocity;
    }

    /// <summary>
    /// Start snapping.
    /// </summary>
    /// <param name="other">enemy to snap to</param>
    public void StartSnapping(Enemy other)
    {
        // Set player snapping to true
        player.IsSnapping = true;
        player.IsRunning = false;

        // Enable trail
        player.trail.enabled = true;

        // Set snap position
        snapPosition = other.transform.position;

        // Set snap enemy
        player.SnapEnemy = other;

        // Temporarily disable camera follow until finished snapping
        mainCamera.followTarget = null;
    }

    /// <summary>
    /// Stop snapping.
    /// </summary>
    private void StopSnapping()
    {
        // Set player snapping to false
        player.IsSnapping = false;
        if (direction != Vector2.zero) player.IsRunning = true;

        // Disable trail
        player.trail.enabled = false;

        transform.rotation =
            Quaternion.LookRotation(Vector3.forward, (snapPosition - (Vector2)transform.position).normalized);

        CameraShaker.Instance.Shake(CameraShakeMode.Normal);

        // Re-enable camera follow
        mainCamera.followTarget = transform;
    }

    /// <summary>
    /// Snap to an enemy.
    /// </summary>
    private void Snap()
    {
        // Snap position
        Vector3 position = transform.position;
        position = Vector2.Lerp(position, snapPosition, SnapInterpolationRatio);
        transform.position = position;

        // Snap rotation
        Quaternion lookRotation =
            Quaternion.LookRotation(Vector3.forward, (snapPosition - (Vector2)position).normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, SnapInterpolationRatio * Time.timeScale);

        // If snapped then stop snapping
        if (GlobalController.CloseTo(transform.position.x, snapPosition.x, SnapDistance) &&
            GlobalController.CloseTo(transform.position.y, snapPosition.y, SnapDistance))
            StopSnapping();
    }
}