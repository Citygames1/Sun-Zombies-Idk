using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //reducing the players run speed
    public GameObject player;
    private Color originalColor;
    private SpriteRenderer sr;
    public TopDownMovement playerTDM;
    public float hitRunSpeedReduction;
    public float originalRunSpeed;

    public int maxHealth;
    public int currentHealth;

    public bool isDead;

    public float hitRecallTimer;
    public float hitRecallLength;

    public float hitTransparencyTimer;
    public float hitTransparencyLength;

    public bool hasBeenHitRecently;
    public bool isSlow;

    public void Start()
    {
        playerTDM = player.GetComponent<TopDownMovement>();
        sr = player.GetComponent<SpriteRenderer>();
        originalRunSpeed = playerTDM.runSpeed;

        originalColor = sr.color;

        currentHealth = maxHealth;
        hitRecallTimer = hitRecallLength;
        hitTransparencyTimer = hitTransparencyLength;
    }

    public void Update()
    {
        if(currentHealth <= 0)
        {
            isDead = true;
            gameObject.SetActive(false);
        }
        if(hasBeenHitRecently == true)
        {
            sr.color = new Vector4(1, 1, 1, 0.75f);

            hitRecallTimer -= Time.deltaTime;
            hitTransparencyTimer -= Time.deltaTime;

            if(hitTransparencyTimer <= 0)
            {
                sr.color = originalColor;
            }

            //this works, but its very ugly, find another way of making it so that it only triggers once
            if(isSlow == false)
            {
                playerTDM.runSpeed *= hitRunSpeedReduction;
                isSlow = true;
            }

            if (hitRecallTimer <= 0)
            {
                playerTDM.runSpeed = originalRunSpeed;

                hasBeenHitRecently = false;
                isSlow = false;
                hitRecallTimer = hitRecallLength;
            }
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        hasBeenHitRecently = true;
    }
}
