using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Use a singleton pattern to make the class globally accessible

    #region Singleton

    private static UIController instance;

    public static UIController Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<UIController>();

            return instance;
        }
    }

    #endregion

    [SerializeField] private TMP_Text fpsText;
    private float timer;

    [SerializeField] private TMP_Text message;
    [SerializeField] private Animator messageAnimator;

    /// <summary>
    /// Unity Event function.
    /// Initialize before first frame update.
    /// </summary>
    private void Start()
    {
        HideFPS();
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void FixedUpdate()
    {
        DisplayFPS();
    }

    #region FPS Methods

    /// <summary>
    /// Show game framerate.
    /// </summary>
    private void DisplayFPS()
    {
        UpdateText(fpsText, ((int)(1f / Time.unscaledDeltaTime)).ToString(), 1f);
    }

    /// <summary>
    /// Show fps text.
    /// </summary>
    public void ShowFPS()
    {
        fpsText.gameObject.SetActive(true);
    }

    /// <summary>
    /// Hide fps text.
    /// </summary>
    public void HideFPS()
    {
        fpsText.gameObject.SetActive(false);
    }

    #endregion

    /// <summary>
    /// Update a text on screen with a refresh rate to stop screen from updating every frame.
    /// </summary>
    /// <param name="text">Text to update</param>
    /// <param name="message">String of message to display</param>
    /// <param name="refreshRate">How many times to refresh per second</param>
    private void UpdateText(TMP_Text text, string message, float refreshRate)
    {
        if (!(Time.unscaledTime > timer)) return;

        text.text = message;
        timer = Time.unscaledTime + refreshRate;
    }

    /// <summary>
    /// Display a text message to player.
    /// </summary>
    /// <param name="text">Text to display</param>
    public void ShowMessage(string text)
    {
        message.text = text;
        messageAnimator.SetTrigger("showMessage");
    }
}