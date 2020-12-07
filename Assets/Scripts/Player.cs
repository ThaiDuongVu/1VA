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
        RaycastHit2D hit2D = Physics2D.Raycast(rayPoint.position, transform.up, 20f);
        if (hit2D.collider != null)
        {
            if (hit2D.transform.CompareTag("Enemy")) hit2D.transform.GetComponent<Enemy>().LockOn(true);
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
        }
    }

    #endregion
}
