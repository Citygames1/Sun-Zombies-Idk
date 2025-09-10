using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject Player;
    public int costToOpen;
    [HideInInspector] public bool hasBeenBought;
    public bool isInRange = false;
    private PointSystem totalPointsNumber;
    private Animator animator;

    private void Start()
    {
        //getting the totalPoints variable from the pointsystem script
        totalPointsNumber = Player.GetComponent<PointSystem>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isInRange == true)
        {
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
                    }

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
