using UnityEngine;

public class RNGhurtEnemy : MonoBehaviour
{
    public int damageToGive;
    public int pointsToGive;
    private GameObject player;

    //makes it a one in x chance
    public int chanceToOneShot;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        int num = Random.Range(1, chanceToOneShot + 1);
        
        if(num == chanceToOneShot)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
                player.GetComponent<PointSystem>().totalPoints += pointsToGive;
            }
        }

        Destroy(gameObject);
    }
}
