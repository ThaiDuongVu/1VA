using UnityEngine;
using UnityEngine.InputSystem;

public class MainCamera : MonoBehaviour
{
    private const float InterpolationRatio = 0.1f;
    [SerializeField] private Transform followTarget;

    private float lookVelocity;
    private const float LookInterpolationRatio = 0.2f;

    private Player _player;
    private bool _isResettingRotation;

    private InputManager _inputManager;

    private void OnEnable()
    {
        _inputManager = new InputManager();

        // Look rotation
        _inputManager.Player.Look.performed += LookOnPerformed;
        _inputManager.Player.Look.canceled += LookOnCanceled;

        // Reset rotation
        _inputManager.Player.ResetRotation.started += ResetRotationOnPerformed;
        _inputManager.Player.ResetRotation.canceled += ResetRotationOnCanceled;

        _inputManager.Enable();
    }

    #region Input Methods

    private void LookOnPerformed(InputAction.CallbackContext context)
    {
        lookVelocity = context.ReadValue<Vector2>().x;
    }

    private void LookOnCanceled(InputAction.CallbackContext context)
    {
        lookVelocity = 0f;
    }

    private void ResetRotationOnPerformed(InputAction.CallbackContext context)
    {
        _isResettingRotation = true;
    }

    private void ResetRotationOnCanceled(InputAction.CallbackContext context)
    {
        _isResettingRotation = false;
    }

    #endregion

    private void OnDisable()
    {
        _inputManager.Disable();
    }

    private void Awake()
    {
        // Get component references
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isResettingRotation) ResetRotation();
        else Rotate();
    }

    private void FixedUpdate()
    {
        Follow(followTarget);
    }

    private void Follow(Transform target)
    {
        if (!target) return;

        // Lerp to target position
        Vector2 targetPosition = target.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, targetPosition.y, -10f),
            InterpolationRatio);
    }

    // Rotate to look velocity
    private void Rotate()
    {
        transform.Rotate(0f, 0f, lookVelocity, Space.Self);
    }

    // Rotate camera to player
    private void ResetRotation()
    {
        transform.up = Vector2.Lerp(transform.up, _player.transform.up, LookInterpolationRatio);
    }
}