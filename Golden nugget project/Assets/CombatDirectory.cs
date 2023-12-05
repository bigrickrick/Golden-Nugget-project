using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDirectory : MonoBehaviour
{
    private int Credit = 0;
    private System.Random randomEnemyNumber = new System.Random();
    private System.Random randomCoordonateForSpawn = new System.Random();
    public Transform spawnPoint;
    private bool IsSpawntimerRunning;
    private float timer = 5;
    public int difficultyScaler = 1;
    private float timebetweenspawn = 1f;
    public bool UltraHardMode;
    
    //this will be the list of enemies that the GameDirectory can spawn
    [SerializeField] private EnemyScript[] EnemyList;
    //each enemy has its own credit cost
    
    //will spawn enemies at random depending on how much Credit the game directory has
    public void SpawnEnemy()
    {
        RandomiseSpawnPoint();
        int numberChosen = GenerateRandomEnemyNumber();
        EnemyScript go = Instantiate(EnemyList[numberChosen], spawnPoint.position, spawnPoint.rotation);
        Credit -= go.CreditCost;
    }
    private void StartSpawnTimer()
    {
        IsSpawntimerRunning = true;
    }
    private void Update()
    {

        if (Credit > 0)
        {
            timebetweenspawn -= Time.deltaTime;
            if(timebetweenspawn <= 0)
            {
                SpawnEnemy();
                timebetweenspawn = 2f;
            }
            
           
            
        }
        else
        {
            if(IsSpawntimerRunning == false)
            {
                StartSpawnTimer();
            }
            
        }
        if (IsSpawntimerRunning == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                int creditGain = 50 + difficultyScaler * 10;
                Credit = creditGain;
                IsSpawntimerRunning = false;
                timer = 30;
                difficultyScaler += 1;
            }
        }

    }
    private void Start()
    {
        Credit = 50;
    }

    public int GenerateRandomEnemyNumber()
    {
        
        int randomEnemy = randomEnemyNumber.Next(0,EnemyList.Length);
        //Debug.Log("Random Enemy Number generated " + randomEnemy);
        return randomEnemy;
    }
    public void RandomiseSpawnPoint()
    {
        float RandomX = randomCoordonateForSpawn.Next(-20, 20);
        float RandomY = randomCoordonateForSpawn.Next(-20, 20);
        Vector3 newPosition = new Vector3(RandomX+Player.Instance.transform.position.x, 0, RandomY+ Player.Instance.transform.position.z);
        spawnPoint.position = newPosition;
    }
}
