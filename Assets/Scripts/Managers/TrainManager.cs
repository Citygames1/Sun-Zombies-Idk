using TMPro;
using UnityEngine;

//function: Manages how the trains arrive and depart the station
//Schedule: Every 4 rounds the train arrives at the start room and the hotel, 2 rounds later it arrives at the foodhall and repeat (cant travel back to spawn)
//new shecdule: Train moves from location to location. (Can travel back to the spawn area)

public class TrainManager : MonoBehaviour
{
    public int trainArrivalRound;

    public GameObject[] doorObjects;
    private GameObject currentDetails;
    public string currentLocation = "startArea";

    private Animator animator;

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
    }

    private void Update()
    {
        if(gms.roundCount  >= trainArrivalRound)
        {
            animator.SetBool("IsReceptionRound", true);
            float price = doorObjects[0].GetComponent<TeleporterScript>().costOfTeleportation;
        }
    }
}
