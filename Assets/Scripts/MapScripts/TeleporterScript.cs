using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    public float costOfTeleportation;

    public GameObject gameManager;
    public GameObject receptionTeleport;
    public GameObject foodHallTeleport;
    public GameObject player;

    private Rigidbody2D rb;
    private Rigidbody2D rb2;
    private Rigidbody2D rb3;

    private PointSystem ps;
    private GameManager gms;
    private TrainManager tms;

    public bool inRange;

    private void Start()
    {
        //setting price increase of difficulty
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        costOfTeleportation = costOfTeleportation * difficultyManager.priceMultiplier;

        gms = gameManager.GetComponent<GameManager>();
        rb = player.GetComponent<Rigidbody2D>();
        rb2 = receptionTeleport.GetComponent<Rigidbody2D>();
        rb3 = foodHallTeleport.GetComponent<Rigidbody2D>();
        ps = player.GetComponent<PointSystem>();
        tms = GetComponentInParent<TrainManager>();
    }
    public void Update()
    {
        if(tms.isReceptionRound == true)
        {
            if (inRange == true && Input.GetKeyDown(KeyCode.E) && ps.totalPoints >= costOfTeleportation)
            {
                ps.totalPoints = ps.totalPoints - costOfTeleportation;
                rb.position = rb2.position; // teleports to reception

                foreach (GameObject zombie in gms.zombies)
                {
                    Destroy(zombie); // this can be changed to teleport them to a random active spawn location
                }
                gms.zombies.Clear();
            }
        }

        if(tms.isFoodHallRound == true) 
        {
            if (inRange == true && Input.GetKeyDown(KeyCode.E) && ps.totalPoints >= costOfTeleportation)
            {
                ps.totalPoints = ps.totalPoints - costOfTeleportation;
                rb.position = rb3.position; // teleports to food hall

                foreach (GameObject zombie in gms.zombies)
                {
                    Destroy(zombie); // this can be changed to teleport them to a random active spawn location
                }
                gms.zombies.Clear();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
