using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public PlayerMovement Movement { get; private set; }

    public bool IsRunning { get; set; }
    public bool IsDashing { get; set; }
    public bool IsSnapping { get; set; }

    public Animator Animator { get; set; }
    public RuntimeAnimatorController regularAnimator;
    public AnimatorOverrideController weaponAnimator;

    public Weapon CurrentWeapon { get; set; }
    public Transform weaponTransform;

    public TrailRenderer trail;

    public Transform directionArrow;
    public Enemy SnapEnemy { get; set; }

    private void Awake()
    {
        // Get component references
        Movement = GetComponent<PlayerMovement>();
        Animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Disable trail
        trail.enabled = false;
        
        UnequipWeapon();
    }

    // Equip a weapon with player
    public void EquipWeapon(Weapon weapon)
    {
        Animator.runtimeAnimatorController = weaponAnimator;
        CurrentWeapon = weapon;
    }

    // Unequip current weapon
    public void UnequipWeapon()
    {
        Animator.runtimeAnimatorController = regularAnimator;
        CurrentWeapon = null;
    }

    // Update is called once per frame
    private void Update()
    {
        if (CurrentWeapon) 
        {
            CurrentWeapon.transform.position = weaponTransform.position;
            CurrentWeapon.transform.rotation = transform.rotation;
        }
    }

    void IDamageable.TakeDamage(float damage)
    {
    }

    void IDamageable.Die()
    {
    }

    #region Trigger Methods

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            Weapon otherWeapon = other.GetComponent<Weapon>();

            if (!CurrentWeapon)
            {
                EquipWeapon(otherWeapon);
                otherWeapon.transform.parent = weaponTransform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }

    #endregion
}