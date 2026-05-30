using TMPro;
using UnityEngine;

public class DoubleHealthPerk : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    private GameObject player;
    public GameObject healthBar;
    private GameObject currentDetails;
    private HealthBar healthBarScript;
    private PlayerHealth playerHS;
    public bool inRangeOfMachine;
    public bool hasBought;
    public float costOfMachine;

    void Awake()
    {
        currentDetails = GameObject.FindGameObjectWithTag("CurrentDetails");
    }

    void Start()
    {
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        costOfMachine = costOfMachine * difficultyManager.priceMultiplier;

        player = GameObject.FindWithTag("Player");
        playerHS = player.GetComponent<PlayerHealth>();
        healthBarScript = healthBar.GetComponent<HealthBar>();
    }

    void Update()
    {
        if (hasBought == false && inRangeOfMachine)
            {
                currentDetails.GetComponent<TMP_Text>().text = "Press E to permanently increase health for " + costOfMachine;

                if (player.GetComponent<PointSystem>().totalPoints >= costOfMachine && Input.GetKeyDown(KeyCode.E))
                {
                    playerHS.maxHealth = playerHS.maxHealth * 2;
                    playerHS.currentHealth = playerHS.currentHealth * 2;
                    healthBarScript.healthBar.maxValue = playerHS.maxHealth;
                    healthBarScript.delayedBar.maxValue = playerHS.maxHealth;
                    healthBarScript.healthBar.value = playerHS.currentHealth;
                    healthBarScript.delayedBar.value = playerHS.currentHealth;
                    player.GetComponent<PointSystem>().totalPoints -= costOfMachine;
                    hasBought = true;
                }
            }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRangeOfMachine = true;
            currentDetails.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRangeOfMachine = false;
            currentDetails.SetActive(false);
        }
    }
}
