using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform barrel;
    public Bullet bullet;
    public WeaponAimCone aimCone;
    public ParticleSystem muzzle;

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

    private Vector2 fireDirection;

    private const float WeaponInterpolationRatio = 0.2f;

    /// <summary>
    /// Fire bullet from weapon.
    /// </summary>
    public void StartShoot()
    {
        if (!isAutomatic)
            Shoot();
        else
            InvokeRepeating("Shoot", 0f, 1f / fireRate);
    }

    /// <summary>
    /// Stop firing bullets.
    /// </summary>
    public void StopShoot()
    {
        CancelInvoke();
    }

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
    }

    /// <summary>
    /// Move weapon with current holder's position and rotation.
    /// </summary>
    public void MoveWithTarget(Transform target)
    {
        transform.position = Vector2.Lerp(transform.position, target.position, WeaponInterpolationRatio);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, WeaponInterpolationRatio);
    }
}