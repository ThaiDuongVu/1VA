using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    public Transform LookTarget { get; set; }
    private const float LookInterpolationRatio = 0.2f;

    public Transform MoveTarget { get; set; }

    private const float PursuitVelocity = 10f;

    private const float KnockBackForce = 30f;
    private const float KnockBackDuration = 0.1f;

    private Rigidbody2D rigidBody2D;

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void Update()
    {
        LookAt(LookTarget);

        if (!enemy.IsKnockingBack && rigidBody2D.velocity != Vector2.zero)
            rigidBody2D.velocity = Vector2.zero;
    }

    /// <summary>
    /// Rotate to look at a target.
    /// </summary>
    /// <param name="target">Target to look at</param>
    private void LookAt(Transform target)
    {
        if (!target) return;

        // New look rotation
        Quaternion lookRotation =
            Quaternion.LookRotation(Vector3.forward, (target.position - transform.position).normalized);

        // Lerp current rotation to new look rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, LookInterpolationRatio * Time.timeScale);
    }

    /// <summary>
    /// Knock enemy back from original position.
    /// </summary>
    /// <returns>Number of seconds during knock back</returns>
    public IEnumerator KnockBack()
    {
        rigidBody2D.velocity = Vector2.zero;

        enemy.IsKnockingBack = true;
        rigidBody2D.AddForce(-transform.up.normalized * KnockBackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(KnockBackDuration);

        rigidBody2D.velocity = Vector2.zero;
        enemy.IsKnockingBack = false;
    }
}