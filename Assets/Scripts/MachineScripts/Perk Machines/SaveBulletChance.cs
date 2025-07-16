using UnityEngine;

public class SaveBulletChance : MonoBehaviour
{
    public GameObject player;
    public GameObject weaponHolder;
    public weaponManager weaponManager;
    [HideInInspector] public Shooting currentGunShooting;
    public bool inRangeOfMachine;
    public bool hasBought;
    public int costOfMachine;
    public int chanceToSaveBulletOutOf100;

    public void Start()
    {
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
