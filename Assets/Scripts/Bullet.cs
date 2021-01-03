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

        if (((Vector2)transform.position - endPosition).magnitude < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    // Fly bullet forward.
    /// </summary>
    private void Fly()
    {
        transform.position = Vector2.Lerp(transform.position, endPosition, speed / 100f);
    }
}
