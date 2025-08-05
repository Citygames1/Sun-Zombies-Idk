using UnityEngine;

public class DoubleHealthPerk : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    private GameObject player;
    public GameObject healthBar;
    private HealthBar healthBarScript;
    private PlayerHealth playerHS;
    public bool inRangeOfMachine;
    public bool hasBought;
    public float costOfMachine;

    void Start()
    {
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        costOfMachine = costOfMachine * difficultyManager.priceMultiplier;
        player = GameObject.FindWithTag("Player");
        playerHS = player.gameObject.GetComponent<PlayerHealth>();
        healthBarScript = healthBar.gameObject.GetComponent<HealthBar>();
    }

    void Update()
    {
        if (hasBought == false && inRangeOfMachine && Input.GetKeyDown(KeyCode.E))
            {
                if (player.GetComponent<PointSystem>().totalPoints >= costOfMachine)
                {
                    playerHS.maxHealth = playerHS.maxHealth * 2;
                    playerHS.currentHealth = playerHS.currentHealth * 2;
                    healthBarScript.healthBar.maxValue = playerHS.maxHealth;
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
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRangeOfMachine = false;
        }
    }
}
