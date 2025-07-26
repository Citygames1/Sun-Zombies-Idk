using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private GameObject player;
    private TopDownMovement tdmPlayer;
    private PlayerHealth playerHealth;
    public float multiplier = 1.5f;
    public bool inRangeOfMachine;
    public bool hasBought;
    public int costOfMachine;

    void Start()
    {
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
