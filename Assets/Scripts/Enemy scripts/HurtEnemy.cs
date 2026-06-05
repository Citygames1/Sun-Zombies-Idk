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

            int randomInt = Random.Range(1,4);
            if(randomInt == 1){
                GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.Hurt1);
                soundObj.GetComponent<Transform>().position = GetComponent<Transform>().position;
            }
            else if(randomInt == 2){
                GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.Hurt2);
                soundObj.GetComponent<Transform>().position = GetComponent<Transform>().position;
            }
            else if(randomInt == 3){
                GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.Hurt3);
                soundObj.GetComponent<Transform>().position = GetComponent<Transform>().position;
            }
            else if(randomInt == 4){
                GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.Hurt4);
                soundObj.GetComponent<Transform>().position = GetComponent<Transform>().position;
            }
            else{
               GameObject soundObj =  AudioManager.Instance.Play(AudioManager.SoundType.Hurt1);
               soundObj.GetComponent<Transform>().position = GetComponent<Transform>().position;
            }

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
