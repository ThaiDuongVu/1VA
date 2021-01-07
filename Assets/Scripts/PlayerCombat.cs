using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private Player player;

    private InputManager inputManager;

    /// <summary>
    /// Unity Event function.
    /// Initialize input handler on object enabled.
    /// </summary>
    private void OnEnable()
    {
        inputManager = new InputManager();

        // Handle fire input
        inputManager.Player.Fire.started += FireOnPerformed;
        inputManager.Player.Fire.canceled += FireOnCanceled;

        // Handle take down input
        inputManager.Player.TakeDown.started += TakeDownOnPerformed;

        inputManager.Enable();
    }

    #region Input Methods

    /// <summary>
    /// On fire input performed.
    /// </summary>
    /// <param name="context">Input context</param>
    private void FireOnPerformed(InputAction.CallbackContext context)
    {
        if (!player.CurrentWeapon) return;

        player.CurrentWeapon.StartShoot();
    }

    /// <summary>
    /// On fire input release.
    /// </summary>
    /// <param name="context">Input context</param>
    private void FireOnCanceled(InputAction.CallbackContext context)
    {
        if (!player.CurrentWeapon) return;

        player.CurrentWeapon.StopShoot();
    }

    private void TakeDownOnPerformed(InputAction.CallbackContext context)
    {
        if (!player.CurrentWeapon) return;

        player.CurrentWeapon.TakeDown();
    }

    #endregion

    /// <summary>
    /// Unity Event function.
    /// Disable input handling on object disabled.
    /// </summary>
    private void OnDisable()
    {
        inputManager.Disable();
    }

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        player = GetComponent<Player>();
    }
}