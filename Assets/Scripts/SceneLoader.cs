using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    private Animator _cameraAnimator;
    [SerializeField] private AnimationClip cameraOutroAnimation;

    private Canvas _canvas;

    // Cached string for triggering animations
    private static readonly int Outro = Animator.StringToHash("outro");

    // Awake is called when an object is initialized
    private void Awake()
    {
        // Get component references
        if (!(Camera.main is null)) _cameraAnimator = Camera.main.GetComponent<Animator>();
        _canvas = FindObjectOfType<Canvas>();
    }

    // Load a scene
    public void Load(string scene)
    {
        StartCoroutine(LoadDelay(scene));
    }

    // Load a scene with delay for transition animation to play
    private IEnumerator LoadDelay(string scene)
    {
        // Reset time scale
        Time.timeScale = 1f;
        // Disable canvas
        _canvas.enabled = false;

        // Disable depth of field effect
        GlobalController.Instance.DisableDepthOfField();

        // Play transition animation
        _cameraAnimator.SetTrigger(Outro);

        // Load scene in the background while camera is transitioning
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;

        // Delay the load for animation to play
        yield return new WaitForSeconds(cameraOutroAnimation.averageDuration);

        // Once camera done transition, move to new scene
        asyncOperation.allowSceneActivation = true;
    }

    // Quit game
    public void Quit()
    {
        Application.Quit();
    }
}