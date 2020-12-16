using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class GamepadRumbler : MonoBehaviour
{
    // Use the singleton pattern to make the class globally accessible

    #region Singleton

    private static GamepadRumbler _instance;

    public static GamepadRumbler Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<GamepadRumbler>();

            return _instance;
        }
    }

    #endregion

    private IEnumerator StartRumble(float duration, float intensity)
    {
        Gamepad.current.SetMotorSpeeds(intensity, intensity);
        yield return new WaitForSeconds(duration);

        InputSystem.ResetHaptics();
    }

    #region Rumble Methods

    public void Rumble(GamepadRumbleMode gamepadRumbleMode)
    {
        switch (gamepadRumbleMode)
        {
            case GamepadRumbleMode.Micro:
                StopAllCoroutines();
                StartCoroutine(StartRumble(0.05f, 0.05f));
                break;

            case GamepadRumbleMode.Light:
                StopAllCoroutines();
                StartCoroutine(StartRumble(0.1f, 0.1f));
                break;

            case GamepadRumbleMode.Normal:
                StopAllCoroutines();
                StartCoroutine(StartRumble(0.2f, 0.2f));
                break;

            case GamepadRumbleMode.Hard:
                StopAllCoroutines();
                StartCoroutine(StartRumble(0.35f, 0.35f));
                break;

            default:
                return;
        }
    }

    #endregion
}