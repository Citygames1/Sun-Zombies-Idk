using UnityEngine;

public class SRchallengeManager : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject startRoomDoor;
    private GameObject secretDoor;
    public GameObject blockade;
    public int roundToStartChallenge = 5;

    public bool challengeIsActive = false;
    private bool shopIsOpen = false;
    public bool isInShop;
    private bool animTriggered = false;
    private bool timerReset = true;

    public float timeToEnterShop = 10;
    private float timeToEnterShopTime;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        startRoomDoor = GameObject.FindGameObjectWithTag("StartRoomDoors");
        secretDoor = GameObject.FindGameObjectWithTag("SecretDoor");
        timeToEnterShopTime = timeToEnterShop;
    }

    void Update()
    {
        if (startRoomDoor.activeSelf == true && gameManager.roundCount == roundToStartChallenge && challengeIsActive == false)
        {
            startRoomDoor.SetActive(false);
            blockade.SetActive(true);
            challengeIsActive = true;
        }

        if (shopIsOpen == true)
        {
            if (isInShop == false)
            {
                timeToEnterShopTime -= Time.deltaTime;
            }
            else
            {
                if (timerReset == false)
                {
                    timeToEnterShopTime = timeToEnterShop;
                    timerReset = true;
                }
            }

            if (timeToEnterShopTime <= 0)
            {
                gameManager.canSpawnZombies = true;
                secretDoor.GetComponent<Animator>().SetTrigger("Change");
                shopIsOpen = false;
            }

        }

        if (challengeIsActive == true)
        {
            if (gameManager.roundCount % 3 == 0 && gameManager.zombiesSpawned == 0) //if round count is divisible by 3 and is start of round
            {
                if (animTriggered == false)
                {
                    gameManager.canSpawnZombies = false;
                    secretDoor.GetComponent<Animator>().SetTrigger("Change");
                    shopIsOpen = true;
                    animTriggered = true;

                }
            }

            if (gameManager.roundCount % 3 == 1 && gameManager.zombiesSpawned == 0)
            {
                animTriggered = false;
                timeToEnterShopTime = timeToEnterShop;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInShop = true;
        timerReset = false;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        isInShop = false;
    }
}
