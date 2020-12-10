using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public PlayerCombat Combat { private set; get; }
    public PlayerMovement Movement { private set; get; }
    public PlayerCombatZone CombatZone;

    public bool IsInCombat { get; set; }
    public bool IsRunning { get; set; }
    public bool IsDashing { get; set; }

    public bool IsSnapping { get; set; }

    public Animator Animator { get; set; }

    public TrailRenderer trail;

    public Transform lockArrow;
    public Enemy LockedOnEnemy { get; set; }

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
        trail.enabled = false;
        Unlock();
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

        CombatZone.UnlockAll();

        LockedOnEnemy = other;
        other.LockOn(true);
    }

    // Lock on enemy
    private void Lock()
    {
        // Set arrow position & rotation
        lockArrow.position = LockedOnEnemy.transform.position + (LockedOnEnemy.transform.position - transform.position).normalized * 1.5f;
        lockArrow.rotation = Quaternion.LookRotation(Vector3.forward, (LockedOnEnemy.transform.position - transform.position).normalized);
    }

    // Unlock enemy
    private void Unlock()
    {
        // Disable lock arrow
        lockArrow.gameObject.SetActive(false);
    }

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }

    #endregion

    void IDamageable.TakeDamage(float damage)
    {

    }
}