using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCombat Combat { private set; get; }
    public PlayerMovement Movement { private set; get; }

    public bool IsInCombat { get; set; }
    public bool IsRunning { get; set; }
    public bool IsDashing { get; set; }

    public bool IsSnapping { get; set; }

    public Animator Animator { get; set; }

    public TrailRenderer trail;

    public Transform rayPoint;
    private const float RaycastDistance = 20f;
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
        if (!hit2D.collider || !hit2D.transform.CompareTag("Enemy")) return;

        Enemy raycastEnemy = hit2D.transform.GetComponent<Enemy>();
        LockedOnEnemy = raycastEnemy;
        raycastEnemy.CombatZone.LockOn(raycastEnemy);
    }

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Enter combat zone
        if (other.CompareTag("CombatZone"))
        {
            Movement.Stop();
            Combat.EnterCombat();

            other.GetComponent<CombatZone>().StartCombat(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Exit combat zone
        if (other.CompareTag("CombatZone"))
        {
            Combat.ExitCombat();

            other.GetComponent<CombatZone>().EndCombat();
            other.GetComponent<CombatZone>().UnlockAll();

            LockedOnEnemy = null;
        }
    }

    #endregion
}