using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public GameObject player;
    private Animator animator;

    public int damageToGive;
    public bool hit;

    private float hitTimer;
    public float timeBetweenHits;
    public float animationTimer;
    private float animationTimerTime;

    public void Start()
    {
        animator = GetComponent<Animator>();

        hitTimer = timeBetweenHits;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
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

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            hitTimer = timeBetweenHits;
        }
    }
}
