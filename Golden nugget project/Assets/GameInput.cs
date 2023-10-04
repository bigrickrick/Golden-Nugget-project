using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction;
    //public event EventHandler OnPauseAction;
    public event EventHandler OnShoot;
    public event EventHandler OnWeaponChanged;

    private PlayerInputAction playerInputAction;
    private void Awake()
    {
        Instance = this;
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();

        playerInputAction.Player.Interact.performed += Interact_performed;
        playerInputAction.Player.Shoot.performed += Shoot_performed;
        playerInputAction.Player.ChangeWeapon.performed += ChangeWeapon_performed;
       
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

