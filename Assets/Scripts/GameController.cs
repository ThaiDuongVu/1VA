using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public Menu[] menus;
    private bool isPaused;

    private InputManager inputManager;

    /// <summary>
    /// Unity Event function.
    /// Initialize input handler on object enabled.
    /// </summary>
    private void OnEnable()
    {
        inputManager = new InputManager();
        inputManager.Game.Escape.started += EscapeOnPerformed;
        inputManager.Enable();
    }

    #region Input Methods

    /// <summary>
    /// On escape button pressed.
    /// </summary>
    /// <param name="context">Input context</param>
    private void EscapeOnPerformed(InputAction.CallbackContext context)
    {
        if (!isPaused) Pause();
        else Resume();
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
    /// Initialize before first frame update.
    /// </summary>
    private void Start()
    {
        GlobalController.LockCursor();
    }

    /// <summary>
    /// Pause game.
    /// </summary>
    public void Pause()
    {
        // Freeze game
        Time.timeScale = 0f;
        // Disable depth of field effect
        GlobalController.Instance.EnableDepthOfField();
        // Unlock cursor
        GlobalController.UnlockCursor();
        // Enable pause menu
        menus[0].Enable();

        isPaused = true;
    }

    /// <summary>
    /// Resume game.
    /// </summary>
    public void Resume()
    {
        // Unfreeze game
        Time.timeScale = 1f;
        // Disable depth of field effect
        GlobalController.Instance.DisableDepthOfField();
        // Lock cursor
        GlobalController.LockCursor();

        // Disable pause menu
        foreach (Menu menu in menus)
        {
            menu.SetInteractable(true);
            menu.Disable();
        }

        isPaused = false;
    }

    /// <summary>
    /// On game over.
    /// </summary>
    public void GameOver()
    {
    }
}