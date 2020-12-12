using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public PlayerCombat Combat { get; private set; }
    public PlayerMovement Movement { get; private set; }
    public PlayerCombatZone combatZone;

    public bool IsInCombat { get; set; }
    public bool IsRunning { get; set; }
    public bool IsDashing { get; set; }
    public bool IsSnapping { get; set; }

    public Animator Animator { get; set; }

    public TrailRenderer trail;

    public Transform lockArrow;
    public Enemy LockedOnEnemy { get; set; }
    public Enemy SnapEnemy { get; set; }

    private void Awake()
    {
        // Get component references
        Combat = GetComponent<PlayerCombat>();
        Movement = GetComponent<PlayerMovement>();

        Animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Disable trail
        trail.enabled = false;

        // Disable lock arrow
        lockArrow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (LockedOnEnemy) Lock();
    }

    public void StartLock(Enemy other)
    {
        // Enable lock arrow
        lockArrow.gameObject.SetActive(true);

        // Unlock all enemies within combat zone to lock on other
        combatZone.UnlockAll();
        other.LockOn(true);

        // Set new lock enemy
        LockedOnEnemy = other;
    }

    public void Unlock(Enemy other)
    {
        // Disable lock arrow
        lockArrow.gameObject.SetActive(false);

        // Unlock other
        other.LockOn(false);

        // Set lock enemy to null
        LockedOnEnemy = null;
    }

    // Lock on enemy
    private void Lock()
    {
        // Set arrow position & rotation
        lockArrow.position = LockedOnEnemy.transform.position + (LockedOnEnemy.transform.position - transform.position).normalized * 1.5f;
        lockArrow.rotation = Quaternion.LookRotation(Vector3.forward, (LockedOnEnemy.transform.position - transform.position).normalized);
    }

    void IDamageable.TakeDamage(float damage)
    {

    }

    void IDamageable.Die()
    {

    }
}