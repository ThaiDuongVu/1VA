using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public Transform barrel;
    public Bullet bullet;
    public Bullet currentBullet;

    public ParticleSystem muzzle;

    // Weapon name
    public new string name;

    public int maxAmmo;
    private int currentAmmo;

    // Damage per bullet
    public float damage;

    // Delay between shots
    public float delayDuration;
    private WaitForSeconds delay;

    public Light2D light2D;

    public Player Player { get; set; }

    private const float WeaponInterpolationRatio = 0.2f;

    public bool canShoot = true;
    private MainCamera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main.GetComponent<MainCamera>();
        delay = new WaitForSeconds(delayDuration);
    }

    /// <summary>
    /// Start firing bullets.
    /// </summary>
    public void StartShoot()
    {
        if (!canShoot) return;

        Shoot();
    }

    /// <summary>
    /// Stop firing bullets.
    /// </summary>
    public void StopShoot()
    {
        StartCoroutine(Cancel());
    }

    /// <summary>
    /// Fire a bullet from weapon.
    /// </summary>
    private void Shoot()
    {
        CameraShaker.Instance.Shake(CameraShakeMode.Normal);

        currentBullet = Instantiate(bullet, barrel.transform.position, transform.rotation).GetComponent<Bullet>();
        Instantiate(muzzle, barrel.transform.position, transform.rotation);

        mainCamera.followTarget = currentBullet.transform;
        canShoot = false;
        Player.IsControllable = false;

        Player.Movement.Stop();
    }

    private IEnumerator Cancel()
    {
        CameraShaker.Instance.Shake(CameraShakeMode.Normal);
        currentBullet.Explode();

        yield return delay;

        mainCamera.followTarget = Player.transform;
        canShoot = true;
        Player.IsControllable = true;
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