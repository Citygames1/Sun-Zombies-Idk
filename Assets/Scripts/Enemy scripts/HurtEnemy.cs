using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    public int pointsToGive;

    private GameObject player;
    private bool hasHit = false;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && hasHit == false)
        {
            //this is done to stop the player from recieving death points and hit points at the same time.
            if (collision.gameObject.GetComponent<EnemyHealthManager>().enemyCurrentHealth > damageToGive)
            {
                player.GetComponent<PointSystem>().GivePoints(pointsToGive);
            }
            
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            collision.gameObject.GetComponent<EnemyHealthManager>().UpdateHealthBar();

            Destroy(gameObject);
            hasHit = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasHit == false)
        {
            Destroy(gameObject);
            hasHit = true;
        }
    }
}
