using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy _enemy;

    public Transform lookTarget;
    private const float LookInterpolationRatio = 0.15f;

    private void Awake()
    {
        // Get component references
        _enemy = GetComponent<Enemy>();
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        LookAt(lookTarget);
    }

    private void LookAt(Transform target)
    {
        if (!lookTarget) return;

        // New look rotation
        Quaternion lookRotation =
            Quaternion.LookRotation(Vector3.forward, (target.position - transform.position).normalized);

        // Lerp current rotation to new look rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, LookInterpolationRatio * Time.timeScale);
    }
}