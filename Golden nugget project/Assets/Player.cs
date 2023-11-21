using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{


   
    public static Player Instance { get; private set; }



   
    
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;
    public MouseLook mousePosition;
    public GunInventory gunInventory;
    public Transform PlayerPosition;
    private bool IsShooting;
    private bool isWalking;
    private float timebetweenshoots = 0;
    public bool isPaused;
    public GameObject pauseMenuCanvas;
    public bool MovementAbilistyIsActivated;
    public MovementAbilityHolder movementAbility;
    private bool EnemyDied = false;
    public float pickuprange = 100;
    [SerializeField] private ObjectHolder objectHolder;
    private void Start()
    {
        gameInput.OnShoot += GameInput_OnShoot;
        gameInput.OnWeaponChanged += GameInput_OnWeaponChanged;
        gameInput.OnStopShoot += GameInput_OnStopShoot;
        gameInput.OnPause += GameInput_OnPause;
        gameInput.OnMovementAbility += GameInput_OnMovementAbility;
        gameInput.OnMovementAbilityStop += GameInput_OnMovementAbilityStop;
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        isPaused = false;
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        objectHolder.PickUpObject();

    }

    public bool EnemyHasdied()
    {
        return EnemyDied;
    }
    public void HasEnemyHasdied(bool yesOrno)
    {
        EnemyDied = yesOrno;
    }
    private void GameInput_OnMovementAbilityStop(object sender, EventArgs e)
    {
        if(movementAbility.currentAbility != null)
        {
            MovementAbilistyIsActivated = false;
        }
    }

    private void GameInput_OnMovementAbility(object sender, EventArgs e)
    {
        if (movementAbility.currentAbility!= null)
        {
            MovementAbilistyIsActivated = true;
        }
        else
        {
            Debug.Log("you do not have a movement ability");
        }
        
    }

    private void GameInput_OnPause(object sender, EventArgs e)
    {
        isPaused = !isPaused; 

        if (isPaused)
        {
            Debug.Log("Game paused");
            Time.timeScale = 0;
            pauseMenuCanvas.gameObject.SetActive(true);
            
        }
        else
        {
            Debug.Log("Game resumed");
            Time.timeScale = 1;
            pauseMenuCanvas.gameObject.SetActive(false);
        }
    }

    private void GameInput_OnStopShoot(object sender, EventArgs e)
    {
        IsShooting = false;
    }

    private void GameInput_OnWeaponChanged(object sender, EventArgs e)
    {
        gunInventory.WeaponSwitch(1);   
        Debug.Log("Weapon changed");
    }

    private void GameInput_OnShoot(object sender, EventArgs e)
    {
        if(gunInventory.gunlist.Count > 0)
        {
            IsShooting = true;
        }
        else
        {
            Debug.Log("you do not have a gun to shoot with it");
        }
        
       

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
        if (IsShooting == true)
        {
            
            if (timebetweenshoots <= 0)
            {
                if (objectHolder.ObjectHasBeenPickedUp)
                {
                    objectHolder.ThrowObject();
                }
                else
                {
                    gunInventory.currentGunUsed.shoot();
                    gunInventory.currentGunUsed.PLayGunSound();
                    timebetweenshoots = gunInventory.currentGunUsed.ShootingSpeed / Instance.GetComponent<Entity>().attackspeedModifier;
                }
                
            }
           
        }
        if (timebetweenshoots > 0)
        {
            timebetweenshoots -= Time.deltaTime;
            Debug.Log("shooting speed " + timebetweenshoots);
        }
        
        
       

    }


    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        float moveDistance = Instance.GetComponent<Entity>().EntitySpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);


        if (canMove)
        {
            transform.position += moveDir * Instance.GetComponent<Entity>().EntitySpeed * Time.deltaTime;
        }

        

        isWalking = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime);
    }
    
    private void playerLookatMouse()
    {
       
        transform.LookAt(mousePosition.MousePosition);
    }  
    
    

    
}
