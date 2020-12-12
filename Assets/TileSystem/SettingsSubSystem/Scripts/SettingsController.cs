﻿using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public Settings fullScreen;
    public Settings resolution;

    public Settings effects;
    private Volume _volume;

    public Settings targetFPS;

    public Settings motionBlur;
    public Settings font;
    public TMP_FontAsset[] fonts;

    public new Settings audio;

    public VolumeProfile volumeProfile;
    private MotionBlur _motionBlur;

    // Awake is called when an object is initialized
    private void Awake()
    {
        _volume = FindObjectOfType<Volume>();
        volumeProfile.TryGet(out _motionBlur);
    }

    // Start is called before the first frame update
    private void Start()
    {
        Apply();
    }

    public void Apply()
    {
        Screen.SetResolution(resolution.currentState, resolution.currentState / 16 * 9,
            (FullScreenMode) fullScreen.currentState);

        _volume.enabled = effects.currentState == 1;
        Application.targetFrameRate = targetFPS.currentState;

        _motionBlur.active = motionBlur.currentState == 1;

        foreach (Object o in Resources.FindObjectsOfTypeAll(typeof(TMP_Text)))
        {
            TMP_Text text = (TMP_Text) o;
            if (!text.transform.CompareTag("Title")) text.font = fonts[font.currentState];
        }

        foreach (Object o in Resources.FindObjectsOfTypeAll(typeof(AudioSource)))
        {
            AudioSource audioSource = (AudioSource) o;
            audioSource.enabled = false;
        }
    }
}