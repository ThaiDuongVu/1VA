using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Damage per bullet
    [SerializeField] private float damage;
    // How far will the bullets go
    [SerializeField] private float range;


    [SerializeField] private Transform barrel;
    [SerializeField] private Bullet bullet;

    // Spread angle
    [SerializeField] private float spread;

    // Number of bullets per second
    [SerializeField] private float fireRate;

    // Whether is a automatic weapon
    [SerializeField] private bool isAutomatic;

    private const float WeaponInterpolationRatio = 0.2f;

    /// <summary>
    /// Fire bullet from weapon.
    /// </summary>
    public void Shoot()
    {
        Instantiate(bullet, barrel.position, transform.rotation);
    }

    /// <summary>
    /// Move weapon with target position and rotation.
    /// </summary>
    public void MoveWithTarget(Transform target)
    {
        transform.position = Vector2.Lerp(transform.position, target.position, WeaponInterpolationRatio);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, WeaponInterpolationRatio);
    }
}