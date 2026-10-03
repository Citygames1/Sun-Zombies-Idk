using UnityEngine;

public class BruteProjectile : MonoBehaviour
{
    public GameObject player;
    public int damageToGive;
    public float hitTime;
    private bool hasHit = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        hitTime -= Time.deltaTime;

        if(hitTime <= 1)
        {
            GetComponent<CircleCollider2D>().enabled = true;
        }
        if(hitTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && hasHit == false)
        {
            collision.gameObject.GetComponent<PlayerHealth>().HurtPlayer(damageToGive);
            hasHit = true;
        }
    }
}
