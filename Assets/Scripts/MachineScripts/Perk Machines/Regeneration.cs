using UnityEngine;
using TMPro;

public class Regeneration : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    private GameObject player;
    private PlayerHealth playerHS;
    private GameObject currentDetails;
    public bool inRangeOfMachine;
    public bool hasBought;
    public float costOfMachine;
    public int healthPerRegenTick = 15;

    public float regenIntervalTimer;
    public float regenInterval;
    public bool regenActive;

    void Awake()
    {
        currentDetails = GameObject.FindGameObjectWithTag("CurrentDetails");
    }

    void Start()
    {
        //setting price increase of difficulty
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        costOfMachine = costOfMachine * difficultyManager.priceMultiplier;

        player = GameObject.FindWithTag("Player");
        playerHS = player.gameObject.GetComponent<PlayerHealth>();
        regenIntervalTimer = regenInterval;
    }

    void Update()
    {
        //taking points and achknowledging purchase
        if (hasBought == false && inRangeOfMachine)
        {
            currentDetails.GetComponent<TMP_Text>().text = "Press E to gain regeneration for " + costOfMachine;

            if (player.GetComponent<PointSystem>().totalPoints >= costOfMachine && Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PointSystem>().totalPoints -= costOfMachine;
                hasBought = true;
            }
        }

        //result of purchase
        if(hasBought == true)
        {
            //regen timer
            if(playerHS.hasBeenHitRecently == false && playerHS.currentHealth != playerHS.maxHealth)
            {
                regenIntervalTimer -= Time.deltaTime;

                if (regenIntervalTimer <= 0 && regenActive == false)
                {
                    regenActive = true;
                    regenIntervalTimer = regenInterval;
                }
            }

            //regeneration
            if(regenActive == true && playerHS.currentHealth != playerHS.maxHealth)
            {
                if(playerHS.maxHealth - playerHS.currentHealth >= healthPerRegenTick)
                {
                    //regeneration occurs
                    playerHS.currentHealth += healthPerRegenTick;
                    regenActive = false;
                }
                else
                {
                    //if the player doesnt need the full health tick to be full, we can just set it to max health
                    playerHS.currentHealth = playerHS.maxHealth;
                    regenActive = false;
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRangeOfMachine = true;
            currentDetails.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRangeOfMachine = false;
            currentDetails.SetActive(false);
        }
    }
}
