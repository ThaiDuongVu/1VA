using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private const float FollowInterpolationRatio = 0.1f;
    private const float YOffset = 15f;
    public Transform followTarget;

    private const float LookInterpolationRatio = 0.3f;

    /// <summary>
    /// Unity Event function.
    /// Update at consistent time.
    /// </summary>
    private void FixedUpdate()
    {
        Follow(followTarget);
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

        transform.position = Vector3.Lerp(transform.position,
            new Vector3(targetPosition.x, targetPosition.y, -10f) + transform.up * YOffset,
            FollowInterpolationRatio);

        transform.up = Vector2.Lerp(transform.up, target.transform.up, LookInterpolationRatio);
    }
}