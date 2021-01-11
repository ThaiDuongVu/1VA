using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Weapon : MonoBehaviour
{
    public Transform barrel;
    public Bullet bullet;
    public WeaponAimCone aimCone;
    public ParticleSystem muzzle;

    // Weapon name
    public new string name;

    // How far will the bullets go
    public float range;

    public int maxAmmo;
    private int currentAmmo;

    // Damage per bullet
    public float damage;

    // Spread angle
    public float spread;

    // Number of bullets per second
    public float fireRate;

    // Whether is a automatic weapon
    public bool isAutomatic;

    public Light2D light2D;

    public Player Player { get; set; }

    private Vector2 fireDirection;

    private const float WeaponInterpolationRatio = 0.2f;

    private Animator animator;

    private bool canShoot = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = fireRate / 3f;
    }

    /// <summary>
    /// Start firing bullets.
    /// </summary>
    public void StartShoot()
    {
        if (!canShoot) return;

        if (isAutomatic)
            InvokeRepeating("Shoot", 0f, 1f / fireRate);
        else
            Shoot();

        animator.SetBool("isFiring", true);
    }

    /// <summary>
    /// Stop firing bullets.
    /// </summary>
    public void StopShoot()
    {
        CancelInvoke("Shoot");
        animator.SetBool("isFiring", false);
    }

    /// <summary>
    /// Fire a bullet from weapon.
    /// </summary>
    private void Shoot()
    {
        // Muzzle flash effect
        Instantiate(muzzle, barrel.position, transform.rotation).transform.parent = barrel;
        // Shake camera
        CameraShaker.Instance.Shake(CameraShakeMode.Light);

        // Direction at which to fire and raycast
        fireDirection = Quaternion.AngleAxis(Random.Range(-spread, spread), Vector3.forward) * transform.up;
        // Perform raycast at fire direction
        RaycastHit2D hit2D = Physics2D.Raycast(barrel.position, fireDirection, range);

        // If hit nothing then fire a bullet at range
        if (hit2D.transform == null)
        {
            Instantiate(bullet, barrel.position, barrel.rotation).GetComponent<Bullet>().endPosition = barrel.position + (Vector3)fireDirection * range;
        }
        // If hit enemy
        else if (hit2D.transform.CompareTag("Enemy"))
        {
            Enemy enemy = hit2D.transform.GetComponent<Enemy>();

            // Deal damage to enemy
            enemy.TakeDamage(damage);
            // Enemy knock back
            enemy.Movement.StartCoroutine(enemy.Movement.KnockBack(transform.up));

            // Fire a bullet at enemy
            Instantiate(bullet, barrel.position, barrel.rotation).GetComponent<Bullet>().endPosition = enemy.transform.position;
        }

        canShoot = false;
        Invoke("CanShoot", 1f / fireRate);
    }

    /// <summary>
    /// Perform a take down move.
    /// </summary>
    public void TakeDown()
    {
        // Perform raycast forward
        RaycastHit2D hit2D = Physics2D.Raycast(barrel.position, transform.up, range);

        // If hit nothing then do nothing
        if (hit2D.transform == null)
        {
            return;
        }
        // If hit enemy
        else if (hit2D.transform.CompareTag("Enemy"))
        {
            Enemy enemy = hit2D.transform.GetComponent<Enemy>();
            if (!enemy.IsStagger) return;

            Player.Movement.StartSnapping(enemy);

            // Deal damage to enemy
            enemy.TakeDamage(0f);
            // Insta kill enemy
            enemy.Die();
        }
    }

    /// <summary>
    /// Move weapon with current holder's position and rotation.
    /// </summary>
    public void MoveWithTarget(Transform target)
    {
        transform.position = Vector2.Lerp(transform.position, target.position, WeaponInterpolationRatio);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, WeaponInterpolationRatio);
    }

    private void CanShoot()
    {
        canShoot = true;
    }
}