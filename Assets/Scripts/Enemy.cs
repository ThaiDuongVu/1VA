using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;

public class Enemy : MonoBehaviour, IDamageable
{
    public EnemyMovement Movement { get; private set; }

    public EnemyState State { get; set; }

    [SerializeField] private Light2D light2D;

    public Animator Animator { get; set; }

    public bool IsKnockingBack { get; set; }

    public float Health { get; set; } = 5f;
    public ParticleSystem bloodSpat;

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Movement = GetComponent<EnemyMovement>();
    }

    /// <summary>
    /// Unity Event function.
    /// Initialize before first frame update.
    /// </summary>
    private void Start()
    {
        State = EnemyState.Idle;
    }

    /// <summary>
    /// Deal an amount of damage to enemy.
    /// </summary>
    /// <param name="damage">Amount of damage to deal</param>
    public void TakeDamage(float damage)
    {
        Health -= damage;
        Instantiate(bloodSpat, transform.position, transform.rotation);

        ComboController.Instance.AddCombo(1);

        if (Health <= 0f) Die();
    }

    /// <summary>
    /// Die.
    /// </summary>
    public void Die()
    {
        // GlobalController.Instance.StartCoroutine(GlobalController.FreezeFrame());
        StartCoroutine(DestroyDelay());
    }

    /// <summary>
    /// Destroy enemy after a delay.
    /// </summary>
    /// <param name="delay">Number of seconds to delay</param>
    /// <returns>Number of seconds to delay</returns>
    private IEnumerator DestroyDelay(float delay = 0.1f)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}