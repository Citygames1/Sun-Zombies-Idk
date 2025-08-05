using UnityEngine;

public class SaveBulletChance : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    private GameObject player;
    private GameObject weaponHolder;
    private weaponManager weaponManager;
    [HideInInspector] public Shooting currentGunShooting;
    public bool inRangeOfMachine;
    public bool hasBought;
    public float costOfMachine;
    public int chanceToSaveBulletOutOf100;

    public void Start()
    {
        //setting price increase of difficulty
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        costOfMachine = costOfMachine * difficultyManager.priceMultiplier;

        player = GameObject.FindWithTag("Player");
        weaponHolder = GameObject.FindWithTag("GunHolder");
        weaponManager = weaponHolder.GetComponent<weaponManager>();
    }

    void Update()
    {
        currentGunShooting = weaponManager.currentGun.GetComponent<Shooting>();

        if (hasBought == false && inRangeOfMachine && Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<PointSystem>().totalPoints >= costOfMachine)
            {
                currentGunShooting.chanceToSaveBulletInt = chanceToSaveBulletOutOf100;
                currentGunShooting.chanceToSaveBullet = true;
                player.GetComponent<PointSystem>().totalPoints -= costOfMachine;
                hasBought = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRangeOfMachine = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRangeOfMachine = false;
        }
    }
}
