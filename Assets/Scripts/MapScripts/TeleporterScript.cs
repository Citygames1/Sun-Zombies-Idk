using TMPro;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    public float costOfTeleportation;

    public GameObject gameManager;
    public GameObject receptionTeleport;
    public GameObject foodHallTeleport;
    public GameObject startAreaTeleport;
    private GameObject player;
    private GameObject currentDetails;
    private GameObject camera;

    private Rigidbody2D rb;
    private Rigidbody2D rb2;
    private Rigidbody2D rb3;
    private Rigidbody2D rb4;

    private PointSystem ps;
    private GameManager gms;
    private TrainManager tms;

    public bool inRange;

    void Awake()
    {
        currentDetails = GameObject.FindGameObjectWithTag("CurrentDetails");
    }

    private void Start()
    {
        //setting price increase of difficulty
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        costOfTeleportation = costOfTeleportation * difficultyManager.priceMultiplier;

        gms = gameManager.GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        rb2 = receptionTeleport.GetComponent<Rigidbody2D>();
        rb3 = foodHallTeleport.GetComponent<Rigidbody2D>();
        rb4 = startAreaTeleport.GetComponent<Rigidbody2D>();
        ps = player.GetComponent<PointSystem>();
        tms = GetComponentInParent<TrainManager>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public void Update()
    {
        if(tms.currentLocation == "startArea")
        {
            if (inRange == true && Input.GetKeyDown(KeyCode.E) && ps.totalPoints >= costOfTeleportation)
            {
                ps.totalPoints = ps.totalPoints - costOfTeleportation;
                rb.position = rb2.position; // teleports to reception
                camera.GetComponent<Transform>().position = new Vector3(rb.position.x, rb.position.y, -10);

                foreach (GameObject zombie in gms.zombies)
                {
                    Destroy(zombie);
                    gms.zombiesSpawned -= 1;
                }
                gms.zombies.Clear();

                tms.currentLocation = "hotelArea";
            }
        }
        else if(tms.currentLocation == "hotelArea") 
        {
            if (inRange == true && Input.GetKeyDown(KeyCode.E) && ps.totalPoints >= costOfTeleportation)
            {
                ps.totalPoints = ps.totalPoints - costOfTeleportation;
                rb.position = rb3.position; // teleports to food hall
                camera.GetComponent<Transform>().position = new Vector3(rb.position.x, rb.position.y, -10);

                foreach (GameObject zombie in gms.zombies)
                {
                    Destroy(zombie);
                    gms.zombiesSpawned -= 1;
                }
                gms.zombies.Clear();

                tms.currentLocation = "foodHallArea";
            }
        }
        else if(tms.currentLocation == "foodHallArea") 
        {
            if (inRange == true && Input.GetKeyDown(KeyCode.E) && ps.totalPoints >= costOfTeleportation)
            {
                ps.totalPoints = ps.totalPoints - costOfTeleportation;
                rb.position = rb4.position; // teleports to start area
                camera.GetComponent<Transform>().position = new Vector3(rb.position.x, rb.position.y, -10);

                foreach (GameObject zombie in gms.zombies)
                {
                    Destroy(zombie);
                    gms.zombiesSpawned -= 1;
                }
                gms.zombies.Clear();

                tms.currentLocation = "startArea";
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
            currentDetails.SetActive(true);

            float price = tms.doorObjects[0].GetComponent<TeleporterScript>().costOfTeleportation;

            if(tms.currentLocation == "startArea")
            {
                currentDetails.GetComponentInChildren<TMP_Text>().text = "Press E to travel to The Grafton Hotel for " + price;
            }
            else if(tms.currentLocation == "hotelArea")
            {
                currentDetails.GetComponentInChildren<TMP_Text>().text = "Press E to travel to St. Peters Food Hall for " + price;
            }
            else if(tms.currentLocation == "foodHallArea")
            {
                currentDetails.GetComponentInChildren<TMP_Text>().text = "Press E to travel to Alexandra Station for " + price;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
            currentDetails.SetActive(false);
        }
    }
}
