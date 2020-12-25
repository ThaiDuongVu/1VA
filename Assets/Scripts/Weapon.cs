using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Damage per bullet
    [SerializeField] private float damage;

    // Spread angle
    [SerializeField] private float spread;

    // Number of bullets per second
    [SerializeField] private float fireRate;

    // Whether is a automatic weapon
    [SerializeField] private bool isAutomatic;

    /// <summary>
    /// Fire bullet from weapon.
    /// </summary>
    public void Shoot()
    {
    }
}