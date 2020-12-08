using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Enemy : MonoBehaviour
{
    public Sprite[] headVariation;
    public Sprite[] bodyVariation;
    public Sprite[] handVariation;
    public Sprite[] footVariation;

    public SpriteRenderer head;
    public SpriteRenderer body;
    public SpriteRenderer handRight;
    public SpriteRenderer handLeft;
    public SpriteRenderer footRight;
    public SpriteRenderer footLeft;

    public Animator animator { get; set; }
    public bool isInCombat { get; set; }

    public bool isLockedOn { get; set; }

    public CombatZone combatZone { get; set; }

    public Light2D light2D;

    private void Awake()
    {
        // Get component references
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        LockOn(false);
        GenerateAppearance();
    }

    // Update is called once per frame
    private void Update()
    {

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
        isLockedOn = value;
        light2D.enabled = value;
    }
}
