using UnityEngine;
using UnityEngine.InputSystem;

public class MainCamera : MonoBehaviour
{
    private const float FollowInterpolationRatio = 0.1f;
    private const float YOffset = 10f;
    [SerializeField] private Transform followTarget;

    private Player _player;
    private const float LookInterpolationRatio = 0.25f;

    private void Awake()
    {
        // Get component references
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale == 0f) return;
    }

    private void FixedUpdate()
    {
        Follow(followTarget);
        RotateToPlayer();
    }

    private void Follow(Transform target)
    {
        if (!target) return;

        // Lerp to target position
        Vector2 targetPosition = target.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x, targetPosition.y, -10f) + transform.up * YOffset,
            FollowInterpolationRatio);
    }

    // Rotate to face player direction
    private void RotateToPlayer()
    {
        transform.up = Vector2.Lerp(transform.up, _player.transform.up, LookInterpolationRatio);
    }
}