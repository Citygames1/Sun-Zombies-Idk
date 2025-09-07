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
            
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            collision.gameObject.GetComponent<EnemyHealthManager>().UpdateHealthBar();
            player.GetComponent<PointSystem>().GivePoints(pointsToGive);

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
