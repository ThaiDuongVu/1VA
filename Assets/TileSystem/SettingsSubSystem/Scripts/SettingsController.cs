using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public Settings fullScreen;
    public Settings resolution;

    public Settings quality;
    public Settings targetFPS;
    
    public Settings font;
    public TMP_FontAsset[] fonts;

    public new Settings audio;

    // Awake is called when an object is initialized
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        Apply();
    }

    public void Apply()
    {
        Screen.SetResolution(resolution.currentState, resolution.currentState / 16 * 9,
            (FullScreenMode)fullScreen.currentState);

        QualitySettings.SetQualityLevel(quality.currentState);
        Application.targetFrameRate = targetFPS.currentState;

        foreach (TMP_Text text in Resources.FindObjectsOfTypeAll(typeof(TMP_Text)))
        {
            text.font = fonts[font.currentState];
        }

        foreach (AudioSource audioSource in Resources.FindObjectsOfTypeAll(typeof(AudioSource)))
        {
            audioSource.enabled = false;
        }
    }
}