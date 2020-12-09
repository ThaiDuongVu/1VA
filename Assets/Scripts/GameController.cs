using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public Menu[] menus;
    private bool _isPaused;

    private InputManager _inputManager;

    private void OnEnable()
    {
        _inputManager = new InputManager();

        _inputManager.Game.Escape.performed += EscapeOnPerformed;

        _inputManager.Enable();
    }

    #region Input Methods

    private void EscapeOnPerformed(InputAction.CallbackContext context)
    {
        if (!_isPaused) Pause();
        else Resume();
    }

    #endregion

    private void OnDisable()
    {
        _inputManager.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Lock cursor
        GlobalController.Instance.LockCursor();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // Pause game
    public void Pause()
    {
        // Freeze game
        Time.timeScale = 0f;
        // Disable depth of field effect
        GlobalController.Instance.EnableDepthOfField();
        // Unlock cursor
        GlobalController.Instance.UnlockCursor();

        // Enable pause menu
        menus[0].Enable();

        _isPaused = true;
    }

    // Resume game
    public void Resume()
    {
        // Unfreeze game
        Time.timeScale = 1f;
        // Disable depth of field effect
        GlobalController.Instance.DisableDepthOfField();
        // Lock cursor
        GlobalController.Instance.LockCursor();

        // Disable pause menu
        foreach (Menu menu in menus)
        {
            menu.SetInteractable(true);
            menu.Disable();
        }

        _isPaused = false;
    }

    public void GameOver()
    {
    }
}