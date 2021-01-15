using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    // Bullet speed
    [SerializeField] private float speed;

    private Rigidbody2D rigidBody2D;

    private float lookVelocity;
    private float lookSensitivity = 1.5f;

    private InputManager inputManager;

    /// <summary>
    /// Unity Event function.
    /// Initialize input handler on object enabled.
    /// </summary>
    private void OnEnable()
    {
        inputManager = new InputManager();

        // Look rotation
        inputManager.Bullet.Look.performed += LookOnPerformed;
        inputManager.Bullet.Look.canceled += LookOnCanceled;

        inputManager.Enable();
    }

    #region Input Methods

    /// <summary>
    /// On look input performed.
    /// </summary>
    /// <param name="context">Input context</param>
    private void LookOnPerformed(InputAction.CallbackContext context)
    {
        lookVelocity = context.ReadValue<Vector2>().x * lookSensitivity;
    }

    /// <summary>
    /// On look input canceled.
    /// </summary>
    /// <param name="context">Input context</param>
    private void LookOnCanceled(InputAction.CallbackContext context)
    {
        lookVelocity = 0f;
    }

    #endregion

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Unity Event function.
    /// Initialize before first frame update.
    /// </summary>
    private void Start()
    {

    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void FixedUpdate()
    {
        Fly();
        Rotate();
    }

    /// <summary>
    // Fly bullet forward.
    /// </summary>
    private void Fly()
    {
        rigidBody2D.MovePosition(rigidBody2D.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    /// <summary>
    /// Rotate to look velocity.
    /// </summary>
    private void Rotate()
    {
        transform.Rotate(0f, 0f, lookVelocity * Time.timeScale, Space.Self);
    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}
