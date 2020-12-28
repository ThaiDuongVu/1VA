using UnityEngine;
using System.Collections;

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

    private const float WeaponInterpolationRatio = 0.2f;

    /// <summary>
    /// Fire bullet from weapon.
    /// </summary>
    public void Shoot()
    {
        Instantiate(muzzle, barrel.position, transform.rotation);
        
        RaycastHit2D hit2D = Physics2D.Raycast(barrel.position, transform.up, range);

        if (hit2D.transform == null)
        {
            Instantiate(bullet, barrel.position, transform.rotation).GetComponent<Bullet>().endPosition = barrel.position + barrel.up * range;
            return;
        }

        if (hit2D.transform.CompareTag("Enemy"))
        {
            Enemy enemy = hit2D.transform.GetComponent<Enemy>();

            Instantiate(bullet, barrel.position, transform.rotation).GetComponent<Bullet>().endPosition = enemy.transform.position;
            enemy.GetComponent<IDamageable>().TakeDamage(damage);
            enemy.Movement.StartCoroutine(enemy.Movement.KnockBack(transform.up));
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(barrel.position, barrel.position + barrel.up * range);
    }
}