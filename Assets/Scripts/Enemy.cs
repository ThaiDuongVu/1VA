using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Enemy : MonoBehaviour, IDamageable
{
    public EnemyCombat Combat { private set; get; }
    public EnemyMovement Movement { private set; get; }

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

    [SerializeField] private Light2D light2D;

    public Animator Animator { get; set; }
    public bool IsInCombat { get; set; }

    public bool IsLockedOn { get; set; }

    public bool IsKnockingBack { get; set; }

    private void Awake()
    {
        // Get component references
        Animator = GetComponent<Animator>();

        Combat = GetComponent<EnemyCombat>();
        Movement = GetComponent<EnemyMovement>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        LockOn(false);
        GenerateAppearance();
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

    public void LockOn(bool value)
    {
        IsLockedOn = value;
        light2D.enabled = value;
    }

    void IDamageable.TakeDamage(float damage)
    {
        StartCoroutine(Movement.KnockBack());
    }
}