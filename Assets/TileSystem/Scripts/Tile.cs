using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private Animator animator;

    private bool isSelected;

    private EventSystem eventSystem;
    private PointerEventData eventData;

    // public Tile leftTile;
    // public Tile rightTile;
    public Tile upTile;
    public Tile downTile;

    [SerializeField] private Transform icon;

    private RectTransform rectTransform;

    // Return the height & current position of the tile
    public float Width => rectTransform.sizeDelta.x;
    public float Height => rectTransform.sizeDelta.y;

    public Vector2 Position => rectTransform.anchoredPosition;

    private TileManager tileManager;
    private static readonly int Selected = Animator.StringToHash("selected");

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        button = GetComponent<Button>();
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();

        eventSystem = EventSystem.current;
        eventData = new PointerEventData(eventSystem);

        tileManager = transform.parent.GetComponent<TileManager>();
    }

    /// <summary>
    /// When mouse hover over tile, select it.
    /// </summary>
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        tileManager.Select(this);
    }

    /// <summary>
    /// Keep selected tile even after mouse exit.
    /// </summary>
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        tileManager.Select(this);
    }

    #region Select Methods

    /// <summary>
    /// When a tile is selected.
    /// </summary>
    public void OnSelected()
    {
        if (isSelected) return;

        button.OnPointerEnter(eventData);
        icon.gameObject.SetActive(true);

        animator.SetTrigger(Selected);

        isSelected = true;
    }

    /// <summary>
    /// When a tile is not selected.
    /// </summary>
    public void OnDeselected()
    {
        button.OnPointerExit(eventData);
        icon.gameObject.SetActive(false);

        isSelected = false;
    }

    #endregion

    /// <summary>
    /// When the tile is clicked.
    /// </summary>
    public void OnClicked()
    {
        button.OnPointerClick(eventData);
    }
}