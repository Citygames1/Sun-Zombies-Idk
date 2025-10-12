using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public int pointsToGive;
    private GameObject player;
    public GameObject canvas;
    public Slider healthBar;

    public float enemyMaxHealth;
    public float enemyCurrentHealth;

    private GameObject gameManager;
    private GameManager gameManagerScript;

    public Transform damageTextSpawnLocation;
    public GameObject damageTextObject;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        GetComponentInChildren<Canvas>().worldCamera = Camera.main;

        canvas.SetActive(false);
        healthBar.maxValue = enemyMaxHealth;
        healthBar.value = enemyMaxHealth;
        healthBar.minValue = 0;

        enemyCurrentHealth = enemyMaxHealth;

        //getting the player object
        player = GameObject.FindWithTag("Player");
    }

    public void HurtEnemy(int damageToGive)
    {
        enemyCurrentHealth -= damageToGive;

        GameObject spawnedDamageTextObject = Instantiate(damageTextObject, damageTextSpawnLocation);
        spawnedDamageTextObject.GetComponent<TMP_Text>().text = "-" + damageToGive;

        if(enemyCurrentHealth <= 0)
        {
            Die();
        }
    }

    public void UpdateHealthBar()
    {
        canvas.SetActive(true);
        healthBar.value = enemyCurrentHealth;
    }

    public void Die()
    {
        Destroy(gameObject);
        gameManagerScript.zombies.Remove(gameObject);

        //giving the player points when they kill an enemy
        player.GetComponent<PointSystem>().GivePoints(pointsToGive);

    }
    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }
}
