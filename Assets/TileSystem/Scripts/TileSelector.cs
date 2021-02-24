using UnityEngine;

public class TileSelector : MonoBehaviour
{
    private RectTransform rectTransform;

    private float Width => rectTransform.sizeDelta.x;

    private const float InterpolationRatio = 0.15f;
    private bool isLerping;
    private Vector2 lerpPosition;

    // Target to rotate to
    private Transform lookTarget;

    public Animator Animator => GetComponent<Animator>();

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void Update()
    {
        // If current position is close enough to lerp position
        // Then stop lerping to save on memory
        if (GlobalController.CloseTo(rectTransform.position.x, lerpPosition.x, 0.01f) &&
            GlobalController.CloseTo(rectTransform.position.y, lerpPosition.y, 0.01f)) isLerping = false;

        // If is lerping then lerp to position
        if (isLerping)
            rectTransform.anchoredPosition =
                Vector2.Lerp(rectTransform.anchoredPosition, lerpPosition, InterpolationRatio);

        Transform transform1 = transform;
        transform.right = Vector2.Lerp(transform1.right, lookTarget.transform.position - transform1.position,
            InterpolationRatio);
    }

    /// <summary>
    /// When a tile is selected.
    /// </summary>
    public void Select(Tile tile)
    {
        // Set lerp position and start lerping
        lerpPosition = new Vector2(tile.Position.x - tile.Width / 2f - Width / 2f - 15f, tile.Position.y);
        isLerping = true;

        lookTarget = tile.transform;
    }
}