using TMPro;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public GameObject[] doorObjects;
    public GameObject[] textsObjects;

    private Animator animator;

    public bool isReceptionRound;
    public bool isFoodHallRound;

    private GameManager gms;

    private void Start()
    {
        gms = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
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

                //Sets the text for each of the train doors
                for (int i = 0; i < doorObjects.Length; i++)
                {
                    float price = doorObjects[i].GetComponent<TeleporterScript>().costOfTeleportation;
                    textsObjects[i].GetComponentInChildren<TMP_Text>().text = "Press E to travel to The Grafton Hotel for " + price;
                }
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

                //Sets the text for each of the train doors
                for (int i = 0; i < doorObjects.Length; i++)
                {
                    float price = doorObjects[i].GetComponent<TeleporterScript>().costOfTeleportation;
                    textsObjects[i].GetComponentInChildren<TMP_Text>().text = "Press E to travel to St. Peters Food Hall for " + price;
                }
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
