using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class GamepadRumbler : MonoBehaviour
{
    // Use the singleton pattern to make the class globally accessible

    #region Singleton

    private static GamepadRumbler instance;

    public static GamepadRumbler Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<GamepadRumbler>();

            return instance;
        }
    }

    #endregion

    /// <summary>
    /// Start rumbling gamepad.
    /// </summary>
    /// <param name="duration">Number of seconds to rumble</param>
    /// <param name="intensity">How hard to rumble</param>
    /// <returns></returns>
    private static IEnumerator StartRumble(float duration, float intensity)
    {
        Gamepad.current.SetMotorSpeeds(intensity, intensity);
        yield return new WaitForSeconds(duration);

        InputSystem.ResetHaptics();
    }

    #region Rumble Methods

    /// <summary>
    /// Rumble gamepad.
    /// </summary>
    /// <param name="gamepadRumbleMode">Mode at which to rumble</param>
    public void Rumble(GamepadRumbleMode gamepadRumbleMode)
    {
        StopAllCoroutines();
        switch (gamepadRumbleMode)
        {
            case GamepadRumbleMode.Micro:
                StartCoroutine(StartRumble(0.05f, 0.05f));
                break;

            case GamepadRumbleMode.Light:
                StartCoroutine(StartRumble(0.075f, 0.075f));
                break;

            case GamepadRumbleMode.Normal:
                StartCoroutine(StartRumble(0.15f, 0.15f));
                break;

            case GamepadRumbleMode.Hard:
                StartCoroutine(StartRumble(0.2f, 0.2f));
                break;

            default:
                return;
        }
    }

    #endregion
}