using UnityEngine;
using TMPro;

public class HealthBank : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    private GameObject player;
    public GameObject textObject;
    public bool inRangeOfMachine;
    public float costOfMachine;
    private PlayerHealth playerHS;

    void Start()
    {
        //setting price increase of difficulty
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        costOfMachine = costOfMachine * difficultyManager.priceMultiplier;
        textObject.GetComponent<TMP_Text>().text = "Press E to heal all injuries for " + costOfMachine;

        player = GameObject.FindWithTag("Player");
        playerHS = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (inRangeOfMachine && Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<PointSystem>().totalPoints >= costOfMachine && playerHS.currentHealth < playerHS.maxHealth)
            {
                playerHS.currentHealth = playerHS.maxHealth;
                player.GetComponent<PointSystem>().totalPoints -= costOfMachine;
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
