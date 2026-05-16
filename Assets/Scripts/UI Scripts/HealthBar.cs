using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Slider delayedBar;
    [Tooltip("The delay before the second bar follows the first.")] public float delay;
    private float delayTimer;
    private bool isActive = false;
    private GameObject player;
    private PlayerHealth playerHealth;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();

        delayTimer = delay;

        SetHealthStart();
    }
    public void Update()
    {
        SetHealth();

        if(healthBar.value != delayedBar.value && isActive == false)
        {
            delayTimer -= Time.deltaTime;

            if(delayTimer <= 0)
            {
                StartCoroutine(HealthDecreaseEffect());
                delayTimer = delay;
                isActive = true;
            }
        }
    }

    public void SetHealth()
    {
        healthBar.value = playerHealth.currentHealth;
    }
    public void SetHealthStart()
    {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
        delayedBar.maxValue = healthBar.maxValue;
        delayedBar.value = healthBar.value;
    }

    public IEnumerator HealthDecreaseEffect()
    {
        while(delayedBar.value > healthBar.value)
        {
            delayedBar.value -= 1;
            yield return 0.1f;
        }
        isActive = false;
    }
}
