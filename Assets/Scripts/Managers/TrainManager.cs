using UnityEngine;

//function: Manages how the trains arrive and depart the station
//old Schedule: Every 4 rounds the train arrives at the start room and the hotel, 2 rounds later it arrives at the foodhall and repeat (cant travel back to spawn)
//new shecdule: Train moves from location to location. (Can travel back to the spawn area)

public class TrainManager : MonoBehaviour
{
    private bool trainArrived = false;
    public int trainArrivalRound;

    public GameObject[] doorObjects;
    private GameObject currentDetails;
    public string currentLocation = "startArea";

    public float timeToWait;
    private float timeToWaitTimer;
    public bool canTeleport;
    [HideInInspector] public Animator animator;
    private bool initialMovement = false;

    private GameManager gms;

    void Awake()
    {
        currentDetails = GameObject.FindGameObjectWithTag("CurrentDetails");
    }

    private void Start()
    {
        gms = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();

        currentDetails.SetActive(false);
        timeToWaitTimer = timeToWait;
    }

    private void Update()
    {
        if(canTeleport == false)
        {
            timeToWaitTimer -= Time.deltaTime;
            if(initialMovement == false)
            {
                initialMovement = true;
                animator.SetTrigger("Change");
            }

            if(timeToWaitTimer <= 0)
            {
                canTeleport = true;
                initialMovement = false;
                timeToWaitTimer = timeToWait;

                animator.SetTrigger("Change");
            }
        }

        if(gms.roundCount  >= trainArrivalRound)
        {
            if(trainArrived == false)
            {
                trainArrived = true;
                animator.SetTrigger("Change");
                Debug.Log("Train has arrived at the station");
            }
        }
    }
}
