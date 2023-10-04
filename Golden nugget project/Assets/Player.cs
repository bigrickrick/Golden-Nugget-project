using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{


   
    public static Player Instance { get; private set; }
    
   
    

    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;
    private Transform mouse;
    public MouseLook mousePosition;
    [SerializeField] private Bullet Playerbullet;
    public GunInventory gunInventory;
    public Transform PlayerPosition;
    private bool isWalking;
    private void Start()
    {
        gameInput.OnShoot += GameInput_OnShoot;
        gameInput.OnWeaponChanged += GameInput_OnWeaponChanged;
    }

    private void GameInput_OnWeaponChanged(object sender, EventArgs e)
    {
        gunInventory.WeaponSwitch(1);   
        Debug.Log("Weapon changed");
    }

    private void GameInput_OnShoot(object sender, EventArgs e)
    {
        gunInventory.currentGunUsed.shoot();
    }
    
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("there is more than one Player instance");
        }
        Instance = this;
    }
    private void Update()
    {
        HandleMovement();
        playerLookatMouse();
        PlayerPosition.position = Instance.PlayerPosition.position;

        //if(isShooting)
        // Shoot!
    }


    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);


        if (canMove)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        

        isWalking = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime);
    }
    
    private void playerLookatMouse()
    {
       
        transform.LookAt(mousePosition.MousePosition);
    }  
    
    

    
}
