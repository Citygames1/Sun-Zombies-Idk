using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject Player;
    public int costToOpen;
    public bool isInRange = false;
    private PointSystem totalPointsNumber;

    private void Start()
    {
        //getting the totalPoints variable from the pointsystem script
        totalPointsNumber = Player.GetComponent<PointSystem>();
    }

    private void Update()
    {
        if (isInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(totalPointsNumber.totalPoints >= costToOpen)
                {
                    gameObject.SetActive(false);

                    //taking away the cost of the door from the total points of the player
                    totalPointsNumber.totalPoints = totalPointsNumber.totalPoints - costToOpen;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }
}
