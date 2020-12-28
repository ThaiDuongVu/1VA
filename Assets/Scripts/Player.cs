using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public PlayerMovement Movement { get; private set; }

    public bool IsRunning { get; set; }
    public bool IsDashing { get; set; }
    public bool IsSnapping { get; set; }
    public bool IsAimAssisting { get; set; }

    public Animator Animator { get; set; }
    public RuntimeAnimatorController regularAnimator;
    public AnimatorOverrideController weaponAnimator;

    public Weapon CurrentWeapon { get; set; }
    public Transform weaponTransform;
    private const float WeaponInterpolationRatio = 0.2f;

    public TrailRenderer trail;

    public Transform directionArrow;
    public Enemy SnapEnemy { get; set; }

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        Movement = GetComponent<PlayerMovement>();
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
    }

    /// <summary>
    /// Equip a weapon to player.
    /// </summary>
    /// <param name="weapon">Weapon to equip</param>
    private void EquipWeapon(Weapon weapon)
    {
        weapon.aimCone.enabled = true;

        Animator.runtimeAnimatorController = weaponAnimator;
        CurrentWeapon = weapon;
    }

    /// <summary>
    /// Unequip current weapon.
    /// </summary>
    private void UnequipWeapon()
    {
        CurrentWeapon.aimCone.enabled = false;

        Animator.runtimeAnimatorController = regularAnimator;
        CurrentWeapon = null;
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void Update()
    {
        if (CurrentWeapon)
        {
            CurrentWeapon.MoveWithTarget(weaponTransform);

            if ((CurrentWeapon.aimCone.EnemyCount > 0 && PlayerPrefs.GetInt("AimAssist", 0) == 0) && !IsAimAssisting) IsAimAssisting = true;
            else if ((CurrentWeapon.aimCone.EnemyCount == 0 || PlayerPrefs.GetInt("AimAssist", 0) != 0) && IsAimAssisting) IsAimAssisting = false;
        }
        else
        {
            IsAimAssisting = false;
        }

        if (IsAimAssisting && Movement.lookSensitivity != PlayerMovement.AimLookSensitivity)
        {
            Movement.lookSensitivity = PlayerMovement.AimLookSensitivity;
        }
        else if (!IsAimAssisting && Movement.lookSensitivity != PlayerMovement.NormalLookSensitivity)
        {
            Movement.lookSensitivity = PlayerMovement.NormalLookSensitivity;
        }
    }

    /// <summary>
    /// Deal damage to player.
    /// </summary>
    /// <param name="damage">Amount to damage</param>
    void IDamageable.TakeDamage(float damage)
    {
    }

    /// <summary>
    /// Player die.
    /// </summary>
    void IDamageable.Die()
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