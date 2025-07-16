using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public GameObject player;
    private Animator animator;

    public int damageToGive;
    public bool hit;

    public float hitTimer;
    public float timeBetweenHits;
    public float animationTimer;
    public float animationTimerTime;

    public void Start()
    {
        animator = GetComponent<Animator>();

        hitTimer = timeBetweenHits;
        animationTimer = animationTimerTime;
    }

    public void Update()
    {
        if (hit == true)
        {
            animationTimer -= Time.deltaTime;

            if (animationTimer <= 0)
            {
                animator.SetBool("IsAttacking", false);
                hit = false;
                animationTimer = animationTimerTime;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            hitTimer -= Time.deltaTime;

            if(hitTimer <= 0)
            {
                hit = true;

                animator.SetBool("IsAttacking", true);

                other.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damageToGive);
                hitTimer = timeBetweenHits;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            hitTimer = timeBetweenHits;
        }
    }
}
