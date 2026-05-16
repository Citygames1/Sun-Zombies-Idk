using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private DifficultyManager difficultyManager;

    //reducing the players run speed
    private Color originalColor;
    private SpriteRenderer sr;
    private TopDownMovement playerTDM;
    public float hitRunSpeedReduction;
    [HideInInspector] public float originalRunSpeed;

    public float maxHealth;
    public float currentHealth;

    [HideInInspector] public bool isDead;

    [HideInInspector] public float hitRecallTimer;
    [HideInInspector] public float hitRecallLength;

    [HideInInspector] public float hitTransparencyTimer;
    [HideInInspector] public float hitTransparencyLength;

    [HideInInspector] public bool hasBeenHitRecently;
    [HideInInspector] public bool turnTransparent;
    [HideInInspector] public bool isSlow;

    public void Awake()
    {
        //setting health with health multiplier from the difficulty manager
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        maxHealth = maxHealth * difficultyManager.playerHealthMultiplier;
        currentHealth = maxHealth;
    }

    public void Start()
    {
        playerTDM = GetComponent<TopDownMovement>();
        sr = GetComponent<SpriteRenderer>();
        originalRunSpeed = playerTDM.runSpeed;

        originalColor = sr.color;

        hitTransparencyTimer = hitTransparencyLength;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            isDead = true;
            gameObject.SetActive(false);
        }
        if (hasBeenHitRecently == true)
        {
            hitRecallTimer -= Time.deltaTime;

            if (isSlow == false)
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
        if(turnTransparent == true)
        {
            hitTransparencyTimer -= Time.deltaTime;

            if (hitTransparencyTimer > 0)
            {
                sr.color = new Vector4(1, 1, 1, 0.75f);
            }
            else
            {
                sr.color = originalColor;
                hitTransparencyTimer = hitTransparencyLength;
                turnTransparent = false;
            }
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        hasBeenHitRecently = true;
        hitRecallTimer = hitRecallLength;
        turnTransparent = true;
        hitTransparencyTimer = hitTransparencyLength;
    }
}
