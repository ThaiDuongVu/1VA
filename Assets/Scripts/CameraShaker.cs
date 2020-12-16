using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    // Use the singleton pattern to make the class globally accessible

    #region Singleton

    private static CameraShaker _instance;

    public static CameraShaker Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<CameraShaker>();

            return _instance;
        }
    }

    #endregion

    // How long to shake the camera
    private float _shakeDuration;

    // How hard to shake the camera
    private float _shakeIntensity;

    // How steep should the shake decrease
    private float _decreaseFactor;

    private Vector3 _originalPosition;

    // Start is called before the first frame update
    private void Start()
    {
        _originalPosition = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Randomize();
    }

    // When camera shakes, randomize its position by shake intensity
    private void Randomize()
    {
        // While shake duration is greater than 0
        if (_shakeDuration > 0)
        {
            // Randomize position
            transform.localPosition = _originalPosition + Random.insideUnitSphere * _shakeIntensity;

            // Decrease shake duration
            _shakeDuration -= Time.fixedDeltaTime * _decreaseFactor;
        }
        // When shake duration reaches 0
        else
        {
            // Reset everything
            _shakeDuration = 0f;
            transform.localPosition = _originalPosition;
        }
    }

    #region Shake Methods

    // Shake the camera at different intensities and duration

    public void Shake(CameraShakeMode cameraShakeMode)
    {
        switch (cameraShakeMode)
        {
            case CameraShakeMode.Micro:
                _shakeDuration = 0.1f;
                _shakeIntensity = 0.3f;

                GamepadRumbler.Instance.Rumble(GamepadRumbleMode.Micro);
                break;

            case CameraShakeMode.Light:
                _shakeDuration = 0.2f;
                _shakeIntensity = 0.4f;

                GamepadRumbler.Instance.Rumble(GamepadRumbleMode.Light);
                break;

            case CameraShakeMode.Normal:
                _shakeDuration = 0.3f;
                _shakeIntensity = 0.5f;

                GamepadRumbler.Instance.Rumble(GamepadRumbleMode.Normal);
                break;

            case CameraShakeMode.Hard:
                _shakeDuration = 0.4f;
                _shakeIntensity = 0.65f;

                GamepadRumbler.Instance.Rumble(GamepadRumbleMode.Hard);
                break;

            default:
                return;
        }

        _decreaseFactor = 2f;
    }

    #endregion
}