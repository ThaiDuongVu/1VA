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

    private void Lock()
    {
        lockArrow.gameObject.SetActive(true);
        lockArrow.position = LockedOnEnemy.transform.position + (LockedOnEnemy.transform.position - transform.position).normalized * 1.5f;

        lockArrow.rotation = Quaternion.LookRotation(Vector3.forward, (LockedOnEnemy.transform.position - transform.position).normalized);
    }

    private void Unlock()
    {
        lockArrow.gameObject.SetActive(false);
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

            Unlock();
            LockedOnEnemy = null;
        }
    }

    #endregion
}