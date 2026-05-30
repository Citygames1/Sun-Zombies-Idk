using UnityEngine;
using TMPro;

public class HealthBank : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    private GameObject player;
    private GameObject currentDetails;
    public bool inRangeOfMachine;
    public float costOfMachine;
    private PlayerHealth playerHS;
    public GameObject healthBar;
    private HealthBar healthBarScript;

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
        playerHS = player.GetComponent<PlayerHealth>();
        healthBarScript = healthBar.GetComponent<HealthBar>();
    }

    void Update()
    {
        if (inRangeOfMachine)
        {
            currentDetails.GetComponent<TMP_Text>().text = "Press E to heal all injuries for " + costOfMachine;

            if (player.GetComponent<PointSystem>().totalPoints >= costOfMachine && playerHS.currentHealth < playerHS.maxHealth && Input.GetKeyDown(KeyCode.E))
            {
                playerHS.currentHealth = playerHS.maxHealth;
                healthBarScript.healthBar.value = healthBarScript.healthBar.maxValue;
                healthBarScript.delayedBar.value = healthBarScript.delayedBar.maxValue;
                player.GetComponent<PointSystem>().totalPoints -= costOfMachine;
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
