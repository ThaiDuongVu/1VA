using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class GlobalController : MonoBehaviour
{
    // Use a singleton pattern to make the class globally accessible
    #region Singleton

    private static GlobalController instance;

    public static GlobalController Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<GlobalController>();

            return instance;
        }
    }

    #endregion

    public VolumeProfile volumeProfile;
    private DepthOfField depthOfField;

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        volumeProfile.TryGet(out depthOfField);
    }

    /// <summary>
    /// Unity Event function.
    /// Initialize before first frame update.
    /// </summary>
    private void Start()
    {
        DisableDepthOfField();
    }

    /// <summary>
    /// Enable depth of field effect.
    /// </summary>
    public void EnableDepthOfField()
    {
        depthOfField.active = true;
    }

    /// <summary>
    /// Disable depth of field effect.
    /// </summary>
    public void DisableDepthOfField()
    {
        depthOfField.active = false;
    }

    /// <summary>
    /// Lock cursor.
    /// </summary>
    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// Unlock cursor. 
    /// </summary>
    public static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// For logical purposes only
    /// Check whether two numbers are close enough to each other
    /// </summary>
    /// <param name="x">num1</param>
    /// <param name="y">num2</param>
    /// <param name="epsilon">How accurate</param>
    /// <returns></returns>
    public static bool CloseTo(float x, float y, float epsilon = 0.1f)
    {
        return Mathf.Abs(x - y) <= epsilon;
    }

    /// <summary>
    /// Perform freeze frame effect
    /// </summary>
    /// <param name="scale">How slow to freeze</param>
    /// <param name="duration">How long to freeze</param>
    /// <returns>Freeze duration</returns>
    public static IEnumerator FreezeFrame(float scale = 0.4f, float duration = 0.2f)
    {
        Time.timeScale = scale;
        yield return new WaitForSeconds(duration);
        Time.timeScale = 1f;
    }
}