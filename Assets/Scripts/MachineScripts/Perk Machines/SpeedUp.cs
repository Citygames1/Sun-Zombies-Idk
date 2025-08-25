using UnityEngine;
using TMPro;

public class SpeedUp : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    private GameObject player;
    public GameObject textObject;
    private TopDownMovement tdmPlayer;
    private PlayerHealth playerHealth;
    public float multiplier = 1.5f;
    public bool inRangeOfMachine;
    public bool hasBought;
    public float costOfMachine;

    void Start()
    {
        //setting price increase of difficulty
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        costOfMachine = costOfMachine * difficultyManager.priceMultiplier;
        textObject.GetComponent<TMP_Text>().text = "Press E to permanently increase speed for " + costOfMachine;

        player = GameObject.FindWithTag("Player");
        tdmPlayer = player.GetComponent<TopDownMovement>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (hasBought == false && inRangeOfMachine && Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<PointSystem>().totalPoints >= costOfMachine)
            {
                tdmPlayer.runSpeed *= multiplier;
                playerHealth.originalRunSpeed = tdmPlayer.runSpeed;
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
