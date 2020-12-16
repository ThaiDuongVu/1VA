using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private Enemy _enemy;
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    public Transform LookTarget { get; set; }
    private const float LookInterpolationRatio = 0.2f;
    public Transform MoveTarget { get; set; }

    private const float CombatVelocity = 5f;
    private const float PursuitVelocity = 10f;

    private const float KnockBackForce = 30f;
    private const float KnockBackDuration = 0.1f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        // Get component references
        _enemy = GetComponent<Enemy>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        LookAt(LookTarget);

        if (!_enemy.IsKnockingBack && _rigidbody2D.velocity != Vector2.zero)
            _rigidbody2D.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (MoveTarget)
        {
            if (_enemy.State == EnemyState.CombatWander)
                Wander();
            else if (_enemy.State == EnemyState.Pursuit)
                Pursuit();
        }
    }

    private void LookAt(Transform target)
    {
        if (!target) return;

        // New look rotation
        Quaternion lookRotation =
            Quaternion.LookRotation(Vector3.forward, (target.position - transform.position).normalized);

        // Lerp current rotation to new look rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, LookInterpolationRatio * Time.timeScale);
    }

    private void Wander()
    {
        // _rigidbody2D.MovePosition(_rigidbody2D.position + (Vector2)(MoveTarget.position - transform.position).normalized * CombatVelocity * Time.fixedDeltaTime);
        LookAt(MoveTarget);
    }

    private void Pursuit()
    {
        Vector2 moveTargetPosition = MoveTarget.position;
        Vector2 targetPosition = new Vector2(moveTargetPosition.x + Random.Range(-2.5f, 2.5f),
            moveTargetPosition.y + Random.Range(-2.5f, 2.5f));

        _rigidbody2D.MovePosition(_rigidbody2D.position + (targetPosition - (Vector2) transform.position).normalized *
            PursuitVelocity * Time.fixedDeltaTime);

        LookAt(MoveTarget);
    }

    public void StartPursuit()
    {
        _enemy.State = EnemyState.Pursuit;
        _enemy.Animator.SetBool(IsRunning, true);
    }

    public IEnumerator KnockBack()
    {
        _rigidbody2D.velocity = Vector2.zero;

        _enemy.IsKnockingBack = true;
        _rigidbody2D.AddForce(-transform.up.normalized * KnockBackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(KnockBackDuration);

        _rigidbody2D.velocity = Vector2.zero;
        _enemy.IsKnockingBack = false;
    }
}