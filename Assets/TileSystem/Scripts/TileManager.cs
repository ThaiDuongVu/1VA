using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TileManager : MonoBehaviour
{
    public Tile[] tiles;
    [HideInInspector] public Button[] buttons;

    public TileSelector selector;
    public Tile CurrentSelectedTile { get; set; }

    private InputManager inputManager;

    /// <summary>
    /// Unity Event function.
    /// Initialize input handler on object enabled.
    /// </summary>
    private void OnEnable()
    {
        inputManager = new InputManager();

        // Handle directional input and click tiles
        inputManager.Game.Direction.performed += DirectionOnPerformed;
        inputManager.Game.Click.performed += ClickOnPerformed;

        inputManager.Enable();

        Select(tiles[0]);
    }

    #region Input Methods

    /// <summary>
    /// On direction input performed.
    /// </summary>
    /// <param name="context">Input context</param>
    private void DirectionOnPerformed(InputAction.CallbackContext context)
    {
        Vector2 directionValue = context.ReadValue<Vector2>();

        // if (directionValue.x > 0.5f) // Right
        // {
        //     Select(_currentSelectedTile.rightTile);
        // }
        // else if (directionValue.x < -0.5f) // Left
        // {
        //     Select(_currentSelectedTile.leftTile);
        // }

        if (directionValue.y > 0.5f && CurrentSelectedTile.upTile != null) // Up
            Select(CurrentSelectedTile.upTile);
        else if (directionValue.y < -0.5f && CurrentSelectedTile.downTile != null) // Down
            Select(CurrentSelectedTile.downTile);
    }

    /// <summary>
    /// On click input performed.
    /// </summary>
    /// <param name="context">Input context</param>
    private void ClickOnPerformed(InputAction.CallbackContext context)
    {
        Click(CurrentSelectedTile);
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
        buttons = new Button[tiles.Length];
        for (int i = 0; i < tiles.Length; i++) buttons[i] = tiles[i].GetComponent<Button>();
    }

    /// <summary>
    /// Select a tile.
    /// </summary>
    public void Select(Tile tileToSelect)
    {
        // Deselect current tile first
        if (CurrentSelectedTile != null) CurrentSelectedTile.OnDeselected();

        // Select tile
        tileToSelect.OnSelected();
        CurrentSelectedTile = tileToSelect;

        // Set selector position
        selector.Select(tileToSelect);
    }

    /// <summary>
    /// Click a tile.`
    /// </summary>
    private void Click(Tile tileToClick)
    {
        tileToClick.OnClicked();
    }
}