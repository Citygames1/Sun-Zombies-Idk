using UnityEngine;

public class BruteAttackl : MonoBehaviour
{
    public bool isInRange = false;
    private bool hasShot = false;
    private GameObject player;
    private Animator animator;
    public float timeBetweenShots;
    private float timeBetweenShotsTimer;
    public GameObject bruteAttack;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

        timeBetweenShotsTimer = timeBetweenShots;
    }

    void Update()
    {
        if(isInRange == true)
        {
            timeBetweenShotsTimer -= Time.deltaTime;

            if(timeBetweenShotsTimer <= 1 && hasShot == false)
            {
                GameObject attack = Instantiate(bruteAttack, player.transform.position, Quaternion.identity);
                animator.SetTrigger("Attack");
                hasShot = true;
            }

            if(timeBetweenShotsTimer <= 0)
            {
                //set the collider here. adds a 1 second buffer before damage
                timeBetweenShotsTimer = timeBetweenShots;
                hasShot = false;
            }
        }
        else
        {
            timeBetweenShotsTimer = timeBetweenShots;
        }
    }

    public void IsInRange()
    {
        isInRange = true;
    }

    public void OutOfRange()
    {
        isInRange = false;
    }
}
