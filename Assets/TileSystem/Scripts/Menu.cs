using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Whether menu is disabled when scene loads
    [SerializeField] private bool disableOnStartup;

    [SerializeField] private TileManager tileManager;
    [SerializeField] private TileSelector tileSelector;

    [SerializeField] private Image background;

    /// <summary>
    /// Unity Event function.
    /// Initialize before first frame update.
    /// </summary>
    private void Start()
    {
        if (disableOnStartup) Disable();

        SetInteractable(true);
    }

    /// <summary>
    /// Enable menu.
    /// </summary>
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Disable menu.
    /// </summary>
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Set whether a menu is interactable or not.
    /// </summary>
    public void SetInteractable(bool interactable)
    {
        tileManager.enabled = interactable;
        background.gameObject.SetActive(!interactable);
        tileManager.selector.gameObject.SetActive(interactable);

        if (!interactable)
        {
            tileSelector.Animator.speed = 0f;
            tileManager.CurrentSelectedTile.OnDeselected();
        }
        else
        {
            tileSelector.Animator.speed = 1f;
            tileManager.CurrentSelectedTile.OnSelected();
        }

        foreach (Button button in tileManager.buttons)
            button.interactable = interactable;
    }
}