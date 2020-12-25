using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    private Animator cameraAnimator;
    [SerializeField] private AnimationClip cameraOutroAnimation;

    private Canvas canvas;

    // Cached string for triggering animations
    private static readonly int Outro = Animator.StringToHash("outro");

    /// <summary>
    /// Unity Event function.
    /// Get component references before first frame update.
    /// </summary>
    private void Awake()
    {
        if (!(Camera.main is null)) cameraAnimator = Camera.main.GetComponent<Animator>();
        canvas = FindObjectOfType<Canvas>();
    }

    /// <summary>
    /// Load a scene.
    /// </summary>
    /// <param name="scene">Name of scene to load</param>
    public void Load(string scene)
    {
        StartCoroutine(LoadDelay(scene));
    }

    /// <summary>
    /// Load a scene with delay for transition animation to play.
    /// </summary>
    /// <param name="scene">Name of scene to load</param>
    /// <returns>Delay duration</returns>
    private IEnumerator LoadDelay(string scene)
    {
        // Reset time scale
        Time.timeScale = 1f;
        // Disable canvas
        canvas.enabled = false;

        // Disable depth of field effect
        GlobalController.Instance.DisableDepthOfField();

        // Play transition animation
        cameraAnimator.SetTrigger(Outro);

        // Load scene in the background while camera is transitioning
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        // Delay the load for animation to play
        yield return new WaitForSeconds(cameraOutroAnimation.averageDuration);

        // Once camera done transition, move to new scene
        asyncOperation.allowSceneActivation = true;
    }

    /// <summary>
    /// Quit game.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}