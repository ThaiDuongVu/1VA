using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    // Bullet speed
    public float speed;

    // Bullet up time
    public float maxUpTime;
    private float currentUpTime;

    // Bullet damage
    public float damage;

    public ParticleSystem explosion;
    public TrailRenderer trail;

    public Weapon Weapon { get; set; }

    private float lookVelocity;
    private float lookSensitivity = 1.5f;

    private Rigidbody2D rigidBody2D;

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

    /// <summary>
    /// Unity Event function.
    /// Get component references.
    /// </summary>
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        currentUpTime = maxUpTime;
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void FixedUpdate()
    {
        Fly();
        Rotate();

        currentUpTime -= Time.fixedDeltaTime;
        if (currentUpTime <= 0f) Weapon.StopShoot();

        trail.time = (currentUpTime / maxUpTime);
    }

    /// <summary>
    /// Fly bullet forward.
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

    /// <summary>
    /// Explode bullet on destroyed.
    /// </summary>
    public void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            // Deal damage to enemy
            enemy.TakeDamage(damage);
            // Add enemy knock back effect
            enemy.Movement.StartCoroutine(enemy.Movement.KnockBack(transform.up));

            // Stop bullet
            Weapon.StopShoot();
        }
        else if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            // Deal damage to player
            player.TakeDamage(damage);

            // Stop bullet
            Weapon.StopShoot();
        }
    }

    #endregion
}
