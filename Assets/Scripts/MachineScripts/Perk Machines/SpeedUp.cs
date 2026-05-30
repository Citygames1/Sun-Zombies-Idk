using UnityEngine;
using TMPro;

public class SpeedUp : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    private GameObject player;
    private GameObject currentDetails;
    private TopDownMovement tdmPlayer;
    private PlayerHealth playerHealth;
    public float multiplier = 1.5f;
    public bool inRangeOfMachine;
    public bool hasBought;
    public float costOfMachine;

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
        tdmPlayer = player.GetComponent<TopDownMovement>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (hasBought == false && inRangeOfMachine)
        {
            currentDetails.GetComponent<TMP_Text>().text = "Press E to permanently increase speed for " + costOfMachine;

            if (player.GetComponent<PointSystem>().totalPoints >= costOfMachine && Input.GetKeyDown(KeyCode.E))
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
