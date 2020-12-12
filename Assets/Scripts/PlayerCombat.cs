﻿using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private Player _player;
    private static readonly int ExitCombatTrigger = Animator.StringToHash("exitCombat");
    private static readonly int EnterCombatTrigger = Animator.StringToHash("enterCombat");

    private Animator _cameraAnimator;

    private InputManager _inputManager;

    private void OnEnable()
    {
        _inputManager = new InputManager();

        // Handle combat input
        _inputManager.Player.Strike.started += StrikeOnPerformed;
        _inputManager.Player.Counter.started += CounterOnPerformed;
        _inputManager.Player.Stun.started += StunOnPerformed;

        _inputManager.Enable();
    }

    #region Input Methods

    private void StrikeOnPerformed(InputAction.CallbackContext context)
    {
        Strike();
    }

    private void CounterOnPerformed(InputAction.CallbackContext context)
    {
        Counter();
    }

    private void StunOnPerformed(InputAction.CallbackContext context)
    {
        Stun();
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
        if (!(Camera.main is null)) _cameraAnimator = Camera.main.GetComponent<Animator>();
    }

    // Player enter combat state
    public void EnterCombat()
    {
        // Play combat animation
        _player.Animator.ResetTrigger(ExitCombatTrigger);
        _player.Animator.SetTrigger(EnterCombatTrigger);

        // Camera enter combat state
        _cameraAnimator.ResetTrigger(ExitCombatTrigger);
        _cameraAnimator.SetTrigger(EnterCombatTrigger);

        // Set state
        _player.IsInCombat = true;
    }

    // Player exit combat state
    public void ExitCombat()
    {
        // Stop combat animation
        _player.Animator.ResetTrigger(EnterCombatTrigger);
        _player.Animator.SetTrigger(ExitCombatTrigger);

        // Camera exit combat state
        _cameraAnimator.ResetTrigger(EnterCombatTrigger);
        _cameraAnimator.SetTrigger(ExitCombatTrigger);

        // Set state
        _player.IsInCombat = false;
    }

    private void Strike()
    {
        if (!_player.LockedOnEnemy) return;

        _player.Movement.StartSnapping(_player.LockedOnEnemy);
    }

    private void Counter()
    {

    }

    private void Stun()
    {

    }
}