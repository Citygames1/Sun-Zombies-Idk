using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    public int pointsToGive;

    private GameObject player;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            collision.gameObject.GetComponent<EnemyHealthManager>().UpdateHealthBar();
            player.GetComponent<PointSystem>().GivePoints(pointsToGive);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
