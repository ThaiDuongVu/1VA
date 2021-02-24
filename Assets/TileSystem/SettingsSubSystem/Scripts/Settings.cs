using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    public int[] toggles;
    private int toggleIndex;

    [HideInInspector] public int currentState;

    public SettingsController settingsController;

    public string propertyName;
    public TMP_Text propertyText;
    public string[] properties;

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        toggleIndex = PlayerPrefs.GetInt(propertyName, 0);

        currentState = toggles[toggleIndex];
        propertyText.text = properties[toggleIndex];
    }

    /// <summary>
    /// Toggle between settings.
    /// </summary>
    public void Toggle()
    {
        if (toggleIndex < toggles.Length - 1)
            toggleIndex++;
        else
            toggleIndex = 0;

        currentState = toggles[toggleIndex];
        propertyText.text = properties[toggleIndex];

        PlayerPrefs.SetInt(propertyName, toggleIndex);

        settingsController.Apply();
    }
}