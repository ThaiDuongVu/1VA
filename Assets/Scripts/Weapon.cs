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
        if (Camera.main is { }) mainCamera = Camera.main.GetComponent<MainCamera>();
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
        if (canShoot) return;

        StartCoroutine(Cancel());
    }

    /// <summary>
    /// Fire a bullet from weapon.
    /// </summary>
    private void Shoot()
    {
        // Shake camera
        CameraShaker.Instance.Shake(CameraShakeMode.Normal);

        // Muzzle effect
        Instantiate(muzzle, barrel.transform.position, transform.rotation);

        // Spawn new bullet
        currentBullet = Instantiate(bullet, barrel.transform.position, transform.rotation).GetComponent<Bullet>();
        currentBullet.Weapon = this;

        // Camera follow bullet instead of player
        mainCamera.followTarget = currentBullet.transform;
        // Disable player shooting & controlling
        canShoot = false;
        Player.IsControllable = false;

        // Stop player
        Player.Movement.Stop();
    }

    private IEnumerator Cancel()
    {
        // Shake camera
        CameraShaker.Instance.Shake(CameraShakeMode.Normal);
        // Explode & destroy current bullet
        if (currentBullet) currentBullet.Explode();

        // Add a bit of delay
        yield return delay;

        // Camera follow player again
        mainCamera.followTarget = Player.transform;
        // Re-enable player shooting & controlling
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