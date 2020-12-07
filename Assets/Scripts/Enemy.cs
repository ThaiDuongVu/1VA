using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Sprite[] headVariation;
    public Sprite[] bodyVariation;
    public Sprite[] handVariation;
    public Sprite[] footVariation;

    public SpriteRenderer head;
    public SpriteRenderer body;
    public SpriteRenderer[] hands;
    public SpriteRenderer[] feet;

    public Animator animator { get; set; }
    public bool isInCombat { get; set; }

    private void Awake()
    {
        // Get component references
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
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

        foreach (SpriteRenderer hand in hands)
        {
            hand.sprite = handVariation[Random.Range(0, handVariation.Length)];
        }
        foreach (SpriteRenderer foot in feet)
        {
            foot.sprite = footVariation[Random.Range(0, footVariation.Length)];
        }
    }
}
