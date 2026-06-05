using UnityEngine;
using TMPro;

public class CollisionDetection : MonoBehaviour
{
    public GameObject Player;
    private GameObject currentDetails;

    public int costToOpen;
    [HideInInspector] public bool hasBeenBought;
    public bool isInRange = false;
    private PointSystem totalPointsNumber;
    private Animator animator;
    public string nameOfDoor;

    private bool playSound = false;
    private bool soundHasPlayed = false;
    public float timeBeforeSound;
    private float timeBeforeSoundTimer;

    void Awake()
    {
        currentDetails = GameObject.FindGameObjectWithTag("CurrentDetails");
    }

    private void Start()
    {
        //getting the totalPoints variable from the pointsystem script
        totalPointsNumber = Player.GetComponent<PointSystem>();

        animator = GetComponent<Animator>();
        timeBeforeSoundTimer = timeBeforeSound;
    }

    void Update()
    {
        if (isInRange == true)
        {
            currentDetails.GetComponentInChildren<TMP_Text>().text = "Press E to open the " + nameOfDoor + " for " + costToOpen;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if(totalPointsNumber.totalPoints >= costToOpen)
                {
                    if (animator == null)
                    {
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        hasBeenBought = true;
                        GetComponent<EdgeCollider2D>().enabled = false;
                        animator.SetTrigger("Open");
                        playSound = true;
                    }

                    //taking away the cost of the door from the total points of the player
                    totalPointsNumber.totalPoints = totalPointsNumber.totalPoints - costToOpen;
                }
            }
        }

        if(playSound == true && soundHasPlayed == false)
        {
            timeBeforeSoundTimer -= Time.deltaTime;
            if(timeBeforeSoundTimer <= 0)
            {
                GetComponent<DoorSound>().PlayOpen(nameOfDoor, GetComponent<Transform>().position);
                soundHasPlayed = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInRange = true;
            if(hasBeenBought == false)
            {
                currentDetails.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInRange = false;
            currentDetails.SetActive(false);
        }
    }
}
