using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public GameObject bottomTrain;
    public GameObject receptionTrain;
    public GameObject foodHallTrain;
    private Animator animator;

    public bool isReceptionRound;
    public bool isFoodHallRound;

    private GameObject gameManager;
    private GameManager gms;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gms = gameManager.GetComponent<GameManager>();
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
