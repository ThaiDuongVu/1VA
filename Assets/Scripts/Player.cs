using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public PlayerMovement Movement { get; private set; }
    public PlayerCombat Combat { get; private set; }
    public Combo Combo { get; private set; }

    public const float MaxHealth = 10f;
    public float CurrentHealth { get; set; }

    public bool IsControllable { get; set; } = true;
    public bool IsRunning { get; set; }
    public bool IsDashing { get; set; }
    public bool IsSnapping { get; set; }

    public Animator Animator { get; set; }
    public RuntimeAnimatorController regularAnimator;
    public AnimatorOverrideController combatAnimator;

    public Weapon CurrentWeapon { get; set; }
    public Transform weaponTransform;

    public TrailRenderer trail;
    public ParticleSystem bloodSpat;

    public Transform directionArrow;
    public Enemy SnapEnemy { get; set; }

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        Movement = GetComponent<PlayerMovement>();
        Combat = GetComponent<PlayerCombat>();
        Combo = GetComponent<Combo>();

        Animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Unity Event function.
    /// Initialize before first frame update.
    /// </summary>
    private void Start()
    {
        // Disable trail
        trail.enabled = false;

        // Set initial health
        CurrentHealth = MaxHealth;
    }

    /// <summary>
    /// Equip a weapon to player.
    /// </summary>
    /// <param name="weapon">Weapon to equip</param>
    private void EquipWeapon(Weapon weapon)
    {
        weapon.Player = this;

        Animator.runtimeAnimatorController = combatAnimator;
        CurrentWeapon = weapon;

        UIController.Instance.ShowMessage(CurrentWeapon.name + " equipped");
    }

    /// <summary>
    /// Unequip current weapon.
    /// </summary>
    private void UnequipWeapon()
    {
        UIController.Instance.ShowMessage(CurrentWeapon.name + " unequipped");

        CurrentWeapon.Player = null;

        Animator.runtimeAnimatorController = regularAnimator;
        CurrentWeapon = null;
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void Update()
    {
        if (CurrentWeapon) CurrentWeapon.MoveWithTarget(weaponTransform);
        UIController.Instance.UpdatePlayerHealthBar(CurrentHealth);
    }

    /// <summary>
    /// Deal damage to player.
    /// </summary>
    /// <param name="damage">Amount to damage</param>
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        Instantiate(bloodSpat, transform.position, transform.rotation);

        Combo.Cancel();
    }

    /// <summary>
    /// Player die.
    /// </summary>
    public void Die()
    {
    }

    #region Trigger Methods

    /// <summary>
    /// Unity Event function.
    /// Handle trigger colliding with other colliders.
    /// </summary>
    /// <param name="other">Other collider</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            if (CurrentWeapon) return;

            Weapon otherWeapon = other.GetComponent<Weapon>();

            EquipWeapon(otherWeapon);
            otherWeapon.transform.parent = weaponTransform;
        }
    }

    #endregion
}