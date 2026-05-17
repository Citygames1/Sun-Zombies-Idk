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

    //colors
    public Color goodHealthColor;
    public Color goodHealthColorFade;
    public Color badHealthColor;
    public Color badHealthColorFade;
    public Color criticalHealthColor;
    public Color criticalHealthColorFade;

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
        float currentPercentage = (playerHealth.currentHealth / playerHealth.maxHealth) * 100;
        if(currentPercentage > 55)
        {
            healthBar.GetComponentInChildren<Image>().color = goodHealthColor;
            delayedBar.GetComponentInChildren<Image>().color = goodHealthColorFade;
        }
        else if(currentPercentage > 25)
        {
            healthBar.GetComponentInChildren<Image>().color = badHealthColor;
            delayedBar.GetComponentInChildren<Image>().color = badHealthColorFade;
        }
        else
        {
            healthBar.GetComponentInChildren<Image>().color = criticalHealthColor;
            delayedBar.GetComponentInChildren<Image>().color = criticalHealthColorFade;
        }
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
