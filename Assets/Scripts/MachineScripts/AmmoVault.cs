using UnityEngine;
using TMPro;

public class AmmoVault : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    private GameObject player;
    private GameObject gunHolder;
    private GameObject currentDetails;
    public bool inRangeOfMachine;
    private float costOfMachine;
    private weaponManager playerShooting;

    void Awake()
    {
        currentDetails = GameObject.FindGameObjectWithTag("CurrentDetails");
    }

    void Start()
    {
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();

        player = GameObject.FindWithTag("Player");
        gunHolder = GameObject.FindWithTag("GunHolder");
        playerShooting = gunHolder.GetComponent<weaponManager>();
    }

    void Update()
    {
        costOfMachine = playerShooting.currentGun.GetComponent<Shooting>().costToReload * difficultyManager.priceMultiplier;

        if (inRangeOfMachine)
        {
            currentDetails.GetComponent<TMP_Text>().text = "Press E to fill the Ammunition of your " + playerShooting.currentGun.name + " for " + costOfMachine + " points";

            if (player.GetComponent<PointSystem>().totalPoints >= costOfMachine && playerShooting.currentGun.GetComponent<Shooting>().needsAmmo == true && Input.GetKeyDown(KeyCode.E))
            {
                playerShooting.currentGun.GetComponent<Shooting>().SetBullets();
                player.GetComponent<PointSystem>().totalPoints -= costOfMachine;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRangeOfMachine = true;
            currentDetails.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRangeOfMachine = false;
            currentDetails.SetActive(false);
        }
    }
}
