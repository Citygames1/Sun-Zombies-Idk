using UnityEngine;

public class DoubleHealthPerk : MonoBehaviour
{
    public GameObject player;
    public GameObject healthBar;
    public HealthBar healthBarScript;
    public PlayerHealth playerHS;
    public bool inRangeOfMachine;
    public bool hasBought;
    public int costOfMachine;

    void Start()
    {
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
