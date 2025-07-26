using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WallBuyScript : MonoBehaviour
{
    public GameObject wallBuyWeapon;
    private GameObject gunHolder;
    private Transform gunHolderTransform;
    private weaponManager weaponManager;
    private GameObject player;

    public int costOfGun;

    public bool inRange;
    public bool hasAlreadyBeenBought;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        gunHolder = GameObject.FindWithTag("GunHolder");
        gunHolderTransform = gunHolder.transform;
        weaponManager = gunHolder.GetComponent<weaponManager>();
    }

    public void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<PointSystem>().totalPoints >= costOfGun && hasAlreadyBeenBought == false) 
            {
                hasAlreadyBeenBought = true;
                GameObject instantiatedGun = Instantiate(wallBuyWeapon, gunHolderTransform);
                weaponManager.guns.Add(instantiatedGun);
                weaponManager.currentGun = instantiatedGun;
                player.GetComponent<PointSystem>().totalPoints -= costOfGun;
                weaponManager.SetGunsActive();
                weaponManager.currentWeaponIndex = weaponManager.totalWeapons;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
