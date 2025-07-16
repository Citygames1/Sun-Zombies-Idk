using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public GameObject player;
    public PlayerHealth playerHealth;

    public void Start()
    {
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
        SetHealthStart();
    }
    public void Update()
    {
        SetHealth();
    }

    public void SetHealth()
    {
        healthBar.value = playerHealth.currentHealth;
    }
    public void SetHealthStart()
    {
        healthBar.value = playerHealth.maxHealth;
        healthBar.maxValue = playerHealth.maxHealth;
    }
}
