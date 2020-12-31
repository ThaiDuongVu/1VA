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

    public EnemyMovement Movement { get; private set; }

    public EnemyState State { get; set; }

    [SerializeField] private Light2D light2D;

    public Animator Animator { get; set; }

    public bool IsKnockingBack { get; set; }
    public bool IsStagger { get; set; }
    public bool CanBeTakenDown { get; set; }

    public float Health { get; set; } = 100f;
    public ParticleSystem bloodSpat;

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Movement = GetComponent<EnemyMovement>();
    }

    /// <summary>
    /// Unity Event function.
    /// Initialize before first frame update.
    /// </summary>
    private void Start()
    {
        GenerateAppearance();
        State = EnemyState.Idle;
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void Update()
    {
        if (Health <= 0f) Die();
    }

    /// <summary>
    /// Generate a random enemy appearance.
    /// </summary>
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

    /// <summary>
    /// Deal an amount of damage to enemy.
    /// </summary>
    /// <param name="damage">Amount of damage to deal</param>
    public void TakeDamage(float damage)
    {
        Health -= damage;
        Instantiate(bloodSpat, transform.position, transform.rotation);
    }

    /// <summary>
    /// Die.
    /// </summary>
    public void Die()
    {
        GlobalController.Instance.StartCoroutine(GlobalController.FreezeFrame());
        StartCoroutine(DestroyDelay());
    }

    /// <summary>
    /// Destroy enemy after a delay.
    /// </summary>
    /// <param name="delay">Number of seconds to delay</param>
    /// <returns>Number of seconds to delay</returns>
    private IEnumerator DestroyDelay(float delay = 0.1f)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}