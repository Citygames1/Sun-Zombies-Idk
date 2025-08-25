using UnityEngine;
using TMPro;

public class AmmoVault : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    private GameObject player;
    private GameObject gunHolder;
    public GameObject textObject;
    public bool inRangeOfMachine;
    public float costOfMachine;
    private weaponManager playerShooting;

    void Start()
    {
        //setting price increase of difficulty
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        costOfMachine = costOfMachine * difficultyManager.priceMultiplier;
        textObject.GetComponent<TMP_Text>().text = "Press E to fill the Ammunition of your current gun for " + costOfMachine;

        player = GameObject.FindWithTag("Player");
        gunHolder = GameObject.FindWithTag("GunHolder");
        playerShooting = gunHolder.GetComponent<weaponManager>();
    }

    void Update()
    {
        if (inRangeOfMachine && Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<PointSystem>().totalPoints >= costOfMachine && playerShooting.currentGun.GetComponent<Shooting>().needsAmmo == true)
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
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRangeOfMachine = false;
        }
    }
}
