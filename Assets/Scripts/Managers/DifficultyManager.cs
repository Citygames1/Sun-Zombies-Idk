using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private GameManager gameManager;

    //PlayerHealth
    [Space] public float playerHealthMultiplier = 1;

    //EnemyHealth
    [Space] public float enemyHealthMultiplier = 1;

    //PointsGainedPerShot
    [Space] public float pointsMultiplier = 1;

    //ZombieSpeed
    [Space] public float enemySpeedMultiplier = 1;

    //PurchasingPrice
    [Space] public float priceMultiplier = 1;

    void Update()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
        
        //setting player health in the PlayerHealth script

        //setting enemy health happens in the SpawnManager script

        //setting points happens in the PointSystem script

        //setting enemy speed happens in SpawnManager script

        //setting prices happens in all of the scripts that handle price
    }
}
