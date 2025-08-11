using System.Net.Http.Headers;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool isBeingTriggered;
    public Transform[] spawners;

    [Tooltip("You must have 5 variants and 5 chances for those variants.")]
    public GameObject[] zombieVariants;

    [Tooltip("Based on the zombieVariants array. Chances[0] = zombieVariants[0]. Adds all the numbers together and creates a chance based on that figure.")]
    public int[] chances;
    private int totalChanceInt = 0;
    public GameObject[] bossZombies;

    private DifficultyManager difficultyManager;
    private GameObject gameManager;
    private GameManager gms;

    //For chances n shi
    private int arrayLength;
    private int randomNumber;
    private int chance1;
    private int chance2;
    private int chance3;
    private int chance4;
    private int chance5;

    public void OnTriggerStay2D(Collider2D collision)
    {
        isBeingTriggered = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isBeingTriggered = false;
    }

    private void Start()
    {
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gms = gameManager.GetComponent<GameManager>();

        //I know lol
        arrayLength = spawners.Length;
        chance1 = chances[0];
        chance2 = chance1 + chances[1];
        chance3 = chance2 + chances[2];
        chance4 = chance3 + chances[3];
        chance5 = chance4 + chances[4];

        //Creating chances for each zombie.
        foreach (int chance in chances)
        {
            totalChanceInt += chance;
        }

    }

    public void Update()
    {
        if(gms.timerHasFinished == true && isBeingTriggered == true)
        {
            if (gms.zombiesSpawned < gms.zombiesInARound)
            {
                SpawnZombie();
            }

            //if a new round has started
            if (gms.zombies.Count == 0)
            {
                gms.roundCount++;
                gms.zombiesSpawned = 0;
                gms.zombiesInARound = gms.roundCount * 5;
            }
        }
    }

    public void SpawnZombie()
    {
        int randomSpawner = Random.Range(0, arrayLength);
        randomNumber = Random.Range(0, totalChanceInt);

        //Boss zombie
        if (gms.zombiesSpawned == 5 && gms.roundCount % 5 == 0)
        {
            //every 5 rounds it spawns a boss zombie
            GameObject spawnedZombie = Instantiate(bossZombies[0], spawners[randomSpawner].position, Quaternion.identity);

            //sets the new speed based on the difficulty
            EnemyPathfind enemySpeed = spawnedZombie.GetComponent<EnemyPathfind>();
            enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;

            //sets the new health based on the difficulty
            EnemyHealthManager enemyHealth = spawnedZombie.GetComponent<EnemyHealthManager>();
            enemyHealth.enemyMaxHealth = enemyHealth.enemyMaxHealth * difficultyManager.enemyHealthMultiplier;
            enemyHealth.enemyCurrentHealth = enemyHealth.enemyMaxHealth;

            gms.zombies.Add(spawnedZombie);
        }
        //Zombies
        if (randomNumber <= chance1)
        {
            //spawning the zombies in a random spawner in the room you are in (this spawns the basic zombie)
            GameObject spawnedZombie = Instantiate(zombieVariants[0], spawners[randomSpawner].position, Quaternion.identity);

            //sets the new speed based on the difficulty
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Basic == true){
                EnemyPathfind enemySpeed = spawnedZombie.GetComponent<EnemyPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Sprinter == true){
                SprinterPathfind enemySpeed = spawnedZombie.GetComponent<SprinterPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Tank == true){
                EnemyPathfind enemySpeed = spawnedZombie.GetComponent<EnemyPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Lunger == true){
                LungerPathfind enemySpeed = spawnedZombie.GetComponent<LungerPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }

            //sets the new health based on the difficulty
            EnemyHealthManager enemyHealth = spawnedZombie.GetComponent<EnemyHealthManager>();
            enemyHealth.enemyMaxHealth = enemyHealth.enemyMaxHealth * difficultyManager.enemyHealthMultiplier;
            enemyHealth.enemyCurrentHealth = enemyHealth.enemyMaxHealth;

            gms.zombies.Add(spawnedZombie);
        }
        if (randomNumber > chance1 && randomNumber <= chance2)
        {
            GameObject spawnedZombie = Instantiate(zombieVariants[1], spawners[randomSpawner].position, Quaternion.identity);

            //sets the new speed based on the difficulty
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Basic == true){
                EnemyPathfind enemySpeed = spawnedZombie.GetComponent<EnemyPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Sprinter == true){
                SprinterPathfind enemySpeed = spawnedZombie.GetComponent<SprinterPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Tank == true){
                EnemyPathfind enemySpeed = spawnedZombie.GetComponent<EnemyPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Lunger == true){
                LungerPathfind enemySpeed = spawnedZombie.GetComponent<LungerPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }

            //sets the new health based on the difficulty
            EnemyHealthManager enemyHealth = spawnedZombie.GetComponent<EnemyHealthManager>();
            enemyHealth.enemyMaxHealth = enemyHealth.enemyMaxHealth * difficultyManager.enemyHealthMultiplier;
            enemyHealth.enemyCurrentHealth = enemyHealth.enemyMaxHealth;

            gms.zombies.Add(spawnedZombie);
        }
        if (randomNumber > chance2 && randomNumber <= chance3)
        {
            GameObject spawnedZombie = Instantiate(zombieVariants[2], spawners[randomSpawner].position, Quaternion.identity);

            //sets the new speed based on the difficulty
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Basic == true){
                EnemyPathfind enemySpeed = spawnedZombie.GetComponent<EnemyPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Sprinter == true){
                SprinterPathfind enemySpeed = spawnedZombie.GetComponent<SprinterPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Tank == true){
                EnemyPathfind enemySpeed = spawnedZombie.GetComponent<EnemyPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Lunger == true){
                LungerPathfind enemySpeed = spawnedZombie.GetComponent<LungerPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }

            //sets the new health based on the difficulty
            EnemyHealthManager enemyHealth = spawnedZombie.GetComponent<EnemyHealthManager>();
            enemyHealth.enemyMaxHealth = enemyHealth.enemyMaxHealth * difficultyManager.enemyHealthMultiplier;
            enemyHealth.enemyCurrentHealth = enemyHealth.enemyMaxHealth;

            gms.zombies.Add(spawnedZombie);
        }
        if (randomNumber > chance3 && randomNumber <= chance4)
        {
            GameObject spawnedZombie = Instantiate(zombieVariants[1], spawners[randomSpawner].position, Quaternion.identity);

            //sets the new speed based on the difficulty
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Basic == true){
                EnemyPathfind enemySpeed = spawnedZombie.GetComponent<EnemyPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Sprinter == true){
                SprinterPathfind enemySpeed = spawnedZombie.GetComponent<SprinterPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Tank == true){
                EnemyPathfind enemySpeed = spawnedZombie.GetComponent<EnemyPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Lunger == true){
                LungerPathfind enemySpeed = spawnedZombie.GetComponent<LungerPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }

            //sets the new health based on the difficulty
            EnemyHealthManager enemyHealth = spawnedZombie.GetComponent<EnemyHealthManager>();
            enemyHealth.enemyMaxHealth = enemyHealth.enemyMaxHealth * difficultyManager.enemyHealthMultiplier;
            enemyHealth.enemyCurrentHealth = enemyHealth.enemyMaxHealth;

            gms.zombies.Add(spawnedZombie);
        }
        if (randomNumber > chance4 && randomNumber <= chance5)
        {
            GameObject spawnedZombie = Instantiate(zombieVariants[2], spawners[randomSpawner].position, Quaternion.identity);

            //sets the new speed based on the difficulty
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Basic == true){
                EnemyPathfind enemySpeed = spawnedZombie.GetComponent<EnemyPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Sprinter == true){
                SprinterPathfind enemySpeed = spawnedZombie.GetComponent<SprinterPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Tank == true){
                EnemyPathfind enemySpeed = spawnedZombie.GetComponent<EnemyPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }
            if (spawnedZombie.GetComponent<EnemyTypeSetter>().Lunger == true){
                LungerPathfind enemySpeed = spawnedZombie.GetComponent<LungerPathfind>();
                enemySpeed.speed = enemySpeed.speed * difficultyManager.enemySpeedMultiplier;
            }

            //sets the new health based on the difficulty
            EnemyHealthManager enemyHealth = spawnedZombie.GetComponent<EnemyHealthManager>();
            enemyHealth.enemyMaxHealth = enemyHealth.enemyMaxHealth * difficultyManager.enemyHealthMultiplier;
            enemyHealth.enemyCurrentHealth = enemyHealth.enemyMaxHealth;

            gms.zombies.Add(spawnedZombie);
        }

        gms.zombiesSpawned++;
    }
}
