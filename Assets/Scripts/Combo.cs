using UnityEngine;
using TMPro;

public class Combo : MonoBehaviour
{
    private Player player;

    public int multiplier;
    private float timer;
    private const float TimerMax = 5f;

    [SerializeField] private TMP_Text text;
    private RectTransform textTransform;

    /// <summary>
    /// Unity Event function.
    /// Get component references.
    /// </summary>
    private void Awake()
    {
        textTransform = text.GetComponent<RectTransform>();
        player = GetComponent<Player>();
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void FixedUpdate()
    {
        if (timer > 0f && player.IsControllable) timer -= Time.fixedDeltaTime;
        else if (timer <= 0f) multiplier = 0;

        text.transform.localScale = new Vector2(1f, 1f) * (timer / TimerMax);
    }

    /// <summary>
    /// Add combo multiplier.
    /// </summary>
    /// <param name="amount">Amount to multiply</param>
    public void AddCombo(int amount)
    {
        multiplier += amount;
        timer = TimerMax;

        textTransform.localRotation = new Quaternion(0f, 0f, Random.Range(-0.25f, 0.25f), 1f);
        text.text = "x" + multiplier.ToString();
    }
}
