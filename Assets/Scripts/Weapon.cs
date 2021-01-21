using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public Transform barrel;
    public Bullet bullet;
    public Bullet CurrentBullet { get; set; }

    public ParticleSystem muzzle;

    // Weapon name
    public new string name;

    public int maxAmmo;
    public int CurrentAmmo { get; set; }

    // Delay between shots
    public float delayDuration;
    private WaitForSeconds delay;

    public Player Player { get; set; }

    private const float WeaponInterpolationRatio = 0.2f;

    public bool canShoot = true;
    private MainCamera mainCamera;
    private Animator cameraAnimator;

    private void Awake()
    {
        if (Camera.main is { }) mainCamera = Camera.main.GetComponent<MainCamera>();
        cameraAnimator = mainCamera.GetComponent<Animator>();

        delay = new WaitForSeconds(delayDuration);
        CurrentAmmo = maxAmmo;
    }

    /// <summary>
    /// Start firing bullets.
    /// </summary>
    public void StartShoot()
    {
        if (!canShoot) return;
        if (CurrentAmmo <= 0)
        {
            UIController.Instance.ShowMessage("Out of ammo!");
            return;
        }

        Fire();
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
    private void Fire()
    {
        // Shake camera
        CameraShaker.Instance.Shake(CameraShakeMode.Normal);
        // Camera enter flying state
        cameraAnimator.SetBool("isFlying", true);

        // Muzzle effect
        Instantiate(muzzle, barrel.transform.position, transform.rotation);

        // Spawn new bullet
        CurrentBullet = Instantiate(bullet, barrel.transform.position, transform.rotation).GetComponent<Bullet>();
        CurrentBullet.Weapon = this;

        // Camera follow bullet instead of player
        mainCamera.followTarget = CurrentBullet.transform;
        // Disable player shooting & controlling
        canShoot = false;
        Player.IsControllable = false;

        // Stop player running & looking
        Player.Movement.StopMovement();
        Player.Movement.StopRotation();

        // Decrease current ammo
        CurrentAmmo--;
    }

    private IEnumerator Cancel()
    {
        // Shake camera
        CameraShaker.Instance.Shake(CameraShakeMode.Normal);

        // Explode & destroy current bullet
        if (CurrentBullet) CurrentBullet.Explode();

        // Add a bit of delay
        yield return delay;

        // Camera exit flying state
        cameraAnimator.SetBool("isFlying", false);

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