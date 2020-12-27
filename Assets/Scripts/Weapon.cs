using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform barrel;
    public Bullet bullet;
    public WeaponAimCone aimCone;

    // How far will the bullets go
    public float range;

    public int maxAmmo;
    private int currentAmmo;

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
        Instantiate(bullet, barrel.position, transform.rotation).GetComponent<Bullet>().weapon = this;
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