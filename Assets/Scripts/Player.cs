using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour, IDamageable
{
    public PlayerCombat Combat { get; private set; }
    public PlayerMovement Movement { get; private set; }

    public bool IsInCombat { get; set; }
    public bool IsRunning { get; set; }
    public bool IsLookingToLock { get; set; }
    public bool IsDashing { get; set; }
    public bool IsSnapping { get; set; }

    public Animator Animator { get; set; }

    public TrailRenderer trail;

    public Transform directionArrow;
    public Transform lockArrow;

    public Enemy LockedOnEnemy { get; set; }
    public Enemy SnapEnemy { get; set; }

    public List<Enemy> EnemiesInCombatZone { get; set; } = new List<Enemy>();
    public List<Enemy> EnemiesInViewCone { get; set; } = new List<Enemy>();

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

        // If more than one enemy within combat zone then player enter combat
        if (EnemiesInCombatZone.Count > 0 && !IsInCombat)
        {
            Combat.EnterCombat();
            Movement.Stop();
        }

        // If no enemy within combat zone then player exit combat
        if (EnemiesInCombatZone.Count == 0 && IsInCombat)
            Combat.ExitCombat();
    }

    public void StartLock(Enemy other)
    {
        // Enable lock arrow
        lockArrow.gameObject.SetActive(true);

        // Unlock all enemies within combat zone to lock on other
        UnlockAll();
        other.LockOn(true);

        // Set new lock enemy
        LockedOnEnemy = other;
    }

    public void Unlock(Enemy other)
    {
        if (LockedOnEnemy != other) return;

        // Disable lock arrow
        lockArrow.gameObject.SetActive(false);

        // Unlock all enemies
        other.LockOn(false);

        // Set lock enemy to null
        LockedOnEnemy = null;
    }

    // Lock on enemy
    private void Lock()
    {
        Transform enemy = LockedOnEnemy.transform;
        Vector3 enemyPosition = enemy.position;

        Transform transform1 = transform;
        Vector3 position = transform1.position;

        // Set arrow position & rotation
        lockArrow.position = enemyPosition + (enemyPosition - position).normalized * 1.5f;
        lockArrow.rotation = Quaternion.LookRotation(Vector3.forward, (enemyPosition - position).normalized);
    }

    // Unlock all enemies within combat zone
    public void UnlockAll()
    {
        foreach (Enemy enemy in EnemiesInCombatZone)
            enemy.LockOn(false);
    }

    void IDamageable.TakeDamage(float damage)
    {
    }

    void IDamageable.Die()
    {
    }
}