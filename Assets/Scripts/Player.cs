using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCombat combat { private set; get; }
    public PlayerMovement movement { private set; get; }

    public bool isInCombat { get; set; } = false;
    public bool isRunning { get; set; } = false;
    public bool isDashing { get; set; } = false;

    public Animator animator { get; set; }

    public TrailRenderer trail;

    public Transform rayPoint;
    private const float RaycastDistance = 20f;

    private void Awake()
    {
        // Get component references
        combat = GetComponent<PlayerCombat>();
        movement = GetComponent<PlayerMovement>();

        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        trail.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        RayLock();
    }

    // Perform raycast for enemies to lock on
    private void RayLock()
    {
        // Ray cast from player forward
        RaycastHit2D hit2D = Physics2D.Raycast(rayPoint.position, transform.up, RaycastDistance);

        // If raycast hit an enemy collider
        if (hit2D.collider && hit2D.transform.CompareTag("Enemy"))
        {
            Enemy raycastedEnemy = hit2D.transform.GetComponent<Enemy>();
            if (hit2D.transform.CompareTag("Enemy")) raycastedEnemy.combatZone.LockOn(raycastedEnemy);
        }
    }

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Enter combat zone
        if (other.CompareTag("CombatZone"))
        {
            movement.Stop();
            combat.EnterCombat();

            other.GetComponent<CombatZone>().StartCombat(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Exit combat zone
        if (other.CompareTag("CombatZone"))
        {
            combat.ExitCombat();

            other.GetComponent<CombatZone>().EndCombat();
            other.GetComponent<CombatZone>().UnlockAll();
        }
    }

    #endregion
}
