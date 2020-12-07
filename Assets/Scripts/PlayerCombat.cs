﻿using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private Player _player;

    private Animator _cameraAnimator;

    private InputManager _inputManager;

    private void OnEnable()
    {
        _inputManager = new InputManager();

        // Handle combat input
        _inputManager.Player.Strike.performed += StrikeOnPerformed;
        _inputManager.Player.Counter.performed += CounterOnPerformed;
        _inputManager.Player.Stun.performed += StunOnPerformed;

        _inputManager.Enable();
    }

    #region Input Methods

    private void StrikeOnPerformed(InputAction.CallbackContext context)
    {

    }

    private void CounterOnPerformed(InputAction.CallbackContext context)
    {

    }

    private void StunOnPerformed(InputAction.CallbackContext context)
    {

    }

    #endregion

    private void OnDisable()
    {
        _inputManager.Disable();
    }

    private void Awake()
    {
        // Get component references
        _player = GetComponent<Player>();
        _cameraAnimator = Camera.main.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    // Player enter combat state
    public void EnterCombat()
    {
        // Play combat animation
        _player.animator.ResetTrigger("exitCombat");
        _player.animator.SetTrigger("enterCombat");

        // Camera enter combat state
        _cameraAnimator.ResetTrigger("exitCombat");
        _cameraAnimator.SetTrigger("enterCombat");

        // Set state
        _player.isInCombat = true;
    }

    // Player exit combat state
    public void ExitCombat()
    {
        // Stop combat animation
        _player.animator.ResetTrigger("enterCombat");
        _player.animator.SetTrigger("exitCombat");

        // Camera exit combat state
        _cameraAnimator.ResetTrigger("enterCombat");
        _cameraAnimator.SetTrigger("exitCombat");

        // Set state
        _player.isInCombat = false;
    }
}
