using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Damage per bullet
    [SerializeField] private float _damage;
    // Spread angle
    [SerializeField] private float _spread;
    // Number of bullets per second
    [SerializeField] private float _fireRate;

    // Whether is a automatic weapon
    [SerializeField] private bool _isAutomatic;
    public void Shoot()
    {
        
    }
}
