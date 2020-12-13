using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;

public class Enemy : MonoBehaviour, IDamageable
{
    # region Appearance Serializations

    [SerializeField] private Sprite[] headVariation;
    [SerializeField] private Sprite[] bodyVariation;
    [SerializeField] private Sprite[] handVariation;
    [SerializeField] private Sprite[] footVariation;

    [SerializeField] private SpriteRenderer head;
    [SerializeField] private SpriteRenderer body;
    [SerializeField] private SpriteRenderer handRight;
    [SerializeField] private SpriteRenderer handLeft;
    [SerializeField] private SpriteRenderer footRight;
    [SerializeField] private SpriteRenderer footLeft;

    #endregion

    public EnemyCombat Combat { get; private set; }
    public EnemyMovement Movement { get; private set; }

    public EnemyState State { get; set; }

    [SerializeField] private Light2D light2D;

    public Animator Animator { get; set; }

    public bool IsInCombat { get; set; }
    public bool IsLockedOn { get; set; }
    public bool IsKnockingBack { get; set; }
    public bool IsStagger { get; set; }

    public float Health { get; set; } = 5f;

    IDamageable damageable;
    public ParticleSystem bloodSpat;

    private void Awake()
    {
        // Get component references
        Animator = GetComponent<Animator>();

        Combat = GetComponent<EnemyCombat>();
        Movement = GetComponent<EnemyMovement>();

        damageable = GetComponent<IDamageable>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        LockOn(false);
        GenerateAppearance();

        State = EnemyState.Idle;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Health <= 0f) damageable.Die();
    }

    // Generate a random appearance
    private void GenerateAppearance()
    {
        head.sprite = headVariation[Random.Range(0, headVariation.Length)];
        body.sprite = bodyVariation[Random.Range(0, bodyVariation.Length)];

        Sprite handSprite = handVariation[Random.Range(0, handVariation.Length)];
        handLeft.sprite = handSprite;
        handRight.sprite = handSprite;

        Sprite footSprite = footVariation[Random.Range(0, footVariation.Length)];
        footLeft.sprite = footSprite;
        footRight.sprite = footSprite;
    }

    // Enable lock on indicator for enemy
    public void LockOn(bool value)
    {
        IsLockedOn = value;
        light2D.enabled = value;
    }

    void IDamageable.TakeDamage(float damage)
    {
        StartCoroutine(Movement.KnockBack());
        Health -= damage;

        Instantiate(bloodSpat, transform.position, transform.rotation);
    }

    void IDamageable.Die()
    {
        GlobalController.Instance.StartCoroutine(GlobalController.FreezeFrame());
        StartCoroutine(DestroyDelay());
    }

    private IEnumerator DestroyDelay(float delay = 0.1f)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            State = EnemyState.CombatAttack;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            State = EnemyState.CombatWander;
    }

    #endregion
}