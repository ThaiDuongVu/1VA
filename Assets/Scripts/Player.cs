using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public PlayerMovement Movement { get; private set; }

    public bool IsRunning { get; set; }
    public bool IsDashing { get; set; }
    public bool IsSnapping { get; set; }
    public bool IsSnapLooking { get; set; }
    public float TakeDownRange = 30f;

    public Animator Animator { get; set; }
    public RuntimeAnimatorController regularAnimator;
    public AnimatorOverrideController combatAnimator;

    public Weapon CurrentWeapon { get; set; }
    public Transform weaponTransform;

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
        weapon.light2D.enabled = false;

        weapon.Player = this;

        Animator.runtimeAnimatorController = combatAnimator;
        CurrentWeapon = weapon;

        UIController.Instance.ShowMessage(CurrentWeapon.name + " equiped");
    }

    /// <summary>
    /// Unequip current weapon.
    /// </summary>
    private void UnequipWeapon()
    {
        UIController.Instance.ShowMessage(CurrentWeapon.name + " unequiped");

        CurrentWeapon.aimCone.enabled = false;
        CurrentWeapon.light2D.enabled = true;

        CurrentWeapon.Player = null;

        Animator.runtimeAnimatorController = regularAnimator;
        CurrentWeapon = null;
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void FixedUpdate()
    {
        if (CurrentWeapon)
        {
            CurrentWeapon.MoveWithTarget(weaponTransform);

            if (PlayerPrefs.GetInt("AimAssist", 0) == 0)
                Movement.AimAssist();
            else
                Movement.lookSensitivity = PlayerMovement.NormalLookSensitivity;
        }
    }

    /// <summary>
    /// Deal damage to player.
    /// </summary>
    /// <param name="damage">Amount to damage</param>
    public void TakeDamage(float damage)
    {
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