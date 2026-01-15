using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public GameObject player;
    private Animator animator;

    public int damageToGive;
    private bool firstHit = false;
    private bool hit;

    public float firstHitTime;
    private float firstHitTimeTimer;
    private float hitTimer;
    public float timeBetweenHits;

    public void Start()
    {
        animator = GetComponent<Animator>();

        hitTimer = timeBetweenHits;
        firstHitTimeTimer = firstHitTime;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(firstHit == false)
            {
                firstHitTimeTimer -= Time.deltaTime;

                if(firstHitTimeTimer <= 0)
                {
                    firstHit = true;
                    other.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damageToGive);
                }
            }
            else
            {
                hitTimer -= Time.deltaTime;

                if(hitTimer <= 0)
                {
                    hit = true;

                    animator.SetTrigger("Attack");

                    other.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damageToGive);
                    hitTimer = timeBetweenHits;
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            hitTimer = timeBetweenHits;
            firstHit = false;
            firstHitTimeTimer = firstHitTime;
        }
    }
}
