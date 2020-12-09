using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalController : MonoBehaviour
{
    // Use a singleton pattern to make the class globally accessible

    #region Singleton

    private static GlobalController _instance;

    public static GlobalController Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<GlobalController>();

            return _instance;
        }
    }

    #endregion

    public VolumeProfile volumeProfile;
    private DepthOfField _depthOfField;

    // Awake is called when an object is initialized
    private void Awake()
    {
        volumeProfile.TryGet(out _depthOfField);
    }

    // Start is called before the first frame update
    private void Start()
    {
        DisableDepthOfField();
    }

    // Enable depth of field effect
    public void EnableDepthOfField()
    {
        _depthOfField.active = true;
    }

    // Disable depth of field effect
    public void DisableDepthOfField()
    {
        _depthOfField.active = false;
    }

    // Lock cursor
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Unlock cursor
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // For logical purposes only
    // Check whether two numbers are close enough to each other
    public static bool CloseTo(float x, float y, float epsilon)
    {
        return Mathf.Abs(x - y) < epsilon;
    }
}