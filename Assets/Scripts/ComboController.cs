using UnityEngine;
using TMPro;

public class ComboController : MonoBehaviour
{
    // Use the singleton pattern to make the class globally accessible

    #region Singleton

    private static ComboController instance;

    public static ComboController Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<ComboController>();

            return instance;
        }
    }

    #endregion

    public int multiplier;
    private float timer;
    private float timerMax = 5f;

    [SerializeField] private TMP_Text text;

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void FixedUpdate()
    {
        if (timer > 0f) timer -= Time.fixedDeltaTime;
        else multiplier = 0;
        
        text.transform.localScale = new Vector2(1f, 1f) * (timer / timerMax);
    }

    /// <summary>
    /// Add combo multiplier.
    /// </summary>
    /// <param name="amount">Amount to multiply</param>
    public void AddCombo(int amount)
    {
        multiplier += amount;
        timer = timerMax;

        text.text = "x" + multiplier.ToString();
    }
}
