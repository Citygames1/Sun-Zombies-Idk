using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class AmmoVault : MonoBehaviour
{
    private GameObject player;
    private GameObject gunHolder;
    public bool inRangeOfMachine;
    public int costOfMachine;
    private weaponManager playerShooting;

    void Start()
    {
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
