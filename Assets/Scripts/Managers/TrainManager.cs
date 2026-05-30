using TMPro;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public GameObject[] doorObjects;
    private GameObject currentDetails;

    private Animator animator;

    public bool isReceptionRound;
    public bool isFoodHallRound;

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
        if(gms.roundCount > 3)
        {
            if (gms.roundCount % 4 == 0)
            {
                isReceptionRound = true;
                animator.SetBool("IsReceptionRound", true);
                animator.SetBool("IsNextRound", false);

                float price = doorObjects[0].GetComponent<TeleporterScript>().costOfTeleportation;
                currentDetails.GetComponentInChildren<TMP_Text>().text = "Press E to travel to The Grafton Hotel for " + price;
            }
            if (gms.roundCount % 4 == 1)
            {
                isReceptionRound = false;
                animator.SetBool("IsReceptionRound", false);
                animator.SetBool("IsNextRound", true);
            }
            if (gms.roundCount % 4 == 2)
            {
                isFoodHallRound = true;
                animator.SetBool("IsFoodHallRound", true);
                animator.SetBool("IsNextRound", false);

                float price = doorObjects[0].GetComponent<TeleporterScript>().costOfTeleportation;
                currentDetails.GetComponentInChildren<TMP_Text>().text = "Press E to travel to St. Peters Food Hall for " + price;
            }
            if (gms.roundCount % 4 == 3)
            {
                isFoodHallRound = false;
                animator.SetBool("IsFoodHallRound", false);
                animator.SetBool("IsNextRound", true);
            }
        }
    }
}
