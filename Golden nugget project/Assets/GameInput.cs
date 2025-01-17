using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnPauseAction;
    public event EventHandler OnShoot;
    public event EventHandler OnStopShoot;
    public event EventHandler OnWeaponChanged;
    public event EventHandler OnPause;
    public event EventHandler OnMovementAbility;
    public event EventHandler OnMovementAbilityStop;
    public event EventHandler OnUtilityAbility;
    private PlayerInputAction playerInputAction;
    private void Awake()
    {
        Instance = this;
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();

        playerInputAction.Player.Interact.performed += Interact_performed;
        playerInputAction.Player.Shoot.performed += Shoot_performed;
        playerInputAction.Player.Shoot.canceled += Shoot_canceled;
        playerInputAction.Player.ChangeWeapon.performed += ChangeWeapon_performed;
        playerInputAction.Player.Pause.performed += Pause_performed;
        playerInputAction.Player.Movementability.performed += Movementability_performed;
        playerInputAction.Player.Movementability.canceled += Movementability_canceled;
        playerInputAction.Player.UtilityAbility.performed += UtilityAbility_performed;
       
    }

    private void UtilityAbility_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnUtilityAbility?.Invoke(this, EventArgs.Empty);
    }

    private void Movementability_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMovementAbilityStop?.Invoke(this, EventArgs.Empty);
    }

    private void Movementability_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMovementAbility?.Invoke(this, EventArgs.Empty);
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPause?.Invoke(this, EventArgs.Empty);
    }

    private void Shoot_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnStopShoot?.Invoke(this, EventArgs.Empty);
    }

    private void ChangeWeapon_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnWeaponChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("Changed Weapon Input");
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnShoot?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        
        OnInteractAction?.Invoke(this,EventArgs.Empty);
        
    }
    
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();


        inputVector = inputVector.normalized;

        
        return inputVector;
    }


    
}

