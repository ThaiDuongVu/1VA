using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Bullet speed
    [SerializeField] private float speed;
    // Damage
    public float damage;

    [HideInInspector] public Weapon weapon;
    private Vector2 initPosition;

    private Rigidbody2D rigidBody2D;

    /// <summary>
    /// Unity Event function.
    /// Get component references.
    /// </summary>
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
        initPosition = transform.position;
        // Fly();
    }

    /// <summary>
    /// Unity Event function.
    /// Update at consistent time.
    /// </summary>
    private void FixedUpdate()
    {
        Fly();
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void Update()
    {
        if (((Vector2)transform.position - initPosition).magnitude > weapon.range + 10)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    // Fly bullet forward.
    /// </summary>
    private void Fly()
    {
        // rigidBody2D.velocity = transform.up * speed;
        rigidBody2D.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);
    }
}
