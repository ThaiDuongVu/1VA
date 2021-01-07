using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private const float FollowInterpolationRatio = 0.1f;
    private const float YOffset = 15f;
    public Transform followTarget;

    private Player player;
    private const float LookInterpolationRatio = 0.3f;

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    /// <summary>
    /// Unity Event function.
    /// Update at consistent time.
    /// </summary>
    private void FixedUpdate()
    {
        Follow(followTarget);
        RotateToPlayer();
    }

    /// <summary>
    /// Follow a target in scene.
    /// </summary>
    /// <param name="target">Target in scene</param>
    private void Follow(Transform target)
    {
        if (!target) return;

        // Lerp to target position
        Vector2 targetPosition = target.position;
        Transform transform1 = transform;

        transform.position = Vector3.Lerp(transform1.position,
            new Vector3(targetPosition.x, targetPosition.y, -10f) + transform1.up * YOffset,
            FollowInterpolationRatio);
    }

    /// <summary>
    /// Rotate to face player direction.
    /// </summary>
    private void RotateToPlayer()
    {
        transform.up = Vector2.Lerp(transform.up, player.transform.up, LookInterpolationRatio);
    }
}