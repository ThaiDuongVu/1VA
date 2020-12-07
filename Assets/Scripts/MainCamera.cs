using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private const float InterpolationRatio = 0.1f;
    [SerializeField] private Transform followTarget;
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        Follow(followTarget);
    }

    private void Follow(Transform target)
    {
        if (!target) return;

        // Lerp to target position
        Vector2 targetPosition = target.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, targetPosition.y, -10f), InterpolationRatio);
    }
}
