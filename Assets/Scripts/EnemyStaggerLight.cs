using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemyStaggerLight : MonoBehaviour
{
    private Light2D light2D;
    private Color targetColor;

    // 255, 107, 107
    private Color redLight = new Color(1f, 0.42f, 0.42f, 1f);
    // 0, 210, 211
    private Color blueLight = new Color(0f, 0.82f, 0.82f, 1f);

    /// <summary>
    /// Unity Event function.
    /// Get component references.
    /// </summary>
    private void Awake()
    {
        light2D = GetComponent<Light2D>();
        targetColor = redLight;
    }

    public void Flash()
    {
        if (light2D.color == targetColor && targetColor == blueLight)
            targetColor = redLight;
        else if (light2D.color == targetColor && targetColor == redLight)
            targetColor = blueLight;

        light2D.color = Color.Lerp(light2D.color, targetColor, 0.25f);
    }
}
