using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Bullet speed
    [SerializeField] private float speed;

    public Vector2 endPosition;

    /// <summary>
    /// Unity Event function.
    /// Initialize before first frame update.
    /// </summary>
    private void Start()
    {
        
    }

    /// <summary>
    /// Unity Event function.
    /// Update once per frame.
    /// </summary>
    private void Update()
    {
        Fly();

        if (GlobalController.CloseTo(transform.position.x, endPosition.x, 0.1f) && GlobalController.CloseTo(transform.position.y, endPosition.y, 0.1f))
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    // Fly bullet forward.
    /// </summary>
    private void Fly()
    {
        transform.position = Vector2.Lerp(transform.position, endPosition, 0.25f);
    }
}
