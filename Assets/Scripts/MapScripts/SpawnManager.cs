using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool isBeingTriggered;
    public Transform[] spawners;
    public GameObject[] zombieVariants;
    public GameObject[] bossZombies;

    private GameObject gameManager;
    private GameManager gms;

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
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gms = gameManager.GetComponent<GameManager>();
    }

    public void Update()
    {
        if(gms.timerHasFinished == true && isBeingTriggered == true)
        {
            if(gms.zombiesSpawned < gms.zombiesInARound)
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
        int ArrayLength = spawners.Length;
        int randomSpawner = Random.Range(0, ArrayLength);
        int randomNumber = Random.Range(0, 7);

        if (gms.zombiesSpawned == 5 && gms.roundCount % 5 == 0)
        {
            //every 5 rounds it spawns a boss zombie
            GameObject spawnedZombie = Instantiate(bossZombies[0], spawners[randomSpawner].position, Quaternion.identity);
            gms.zombies.Add(spawnedZombie);
        }

        if (randomNumber <= 2)
        {
            //spawning the zombies in a random spawner in the room you are in (this spawns the basic zombie)
            GameObject spawnedZombie = Instantiate(zombieVariants[0], spawners[randomSpawner].position, Quaternion.identity);
            gms.zombies.Add(spawnedZombie);
        }
        if (randomNumber == 3 || randomNumber == 4)
        {
            GameObject spawnedZombie = Instantiate(zombieVariants[1], spawners[randomSpawner].position, Quaternion.identity);
            gms.zombies.Add(spawnedZombie);
        }
        if (randomNumber == 5 || randomNumber == 6)
        {
            GameObject spawnedZombie = Instantiate(zombieVariants[2], spawners[randomSpawner].position, Quaternion.identity);
            gms.zombies.Add(spawnedZombie);
        }

        gms.zombiesSpawned++;
    }
}
