using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class weaponManager : MonoBehaviour
{
    public int totalWeapons = 1;
    public int currentWeaponIndex;

    public List<GameObject> guns;
    public GameObject weaponHolder;
    public GameObject currentGun;
    public TMP_Text bulletCountText;
    private Shooting currentGunShooting;
    private GameObject player;
    [HideInInspector] public float originalRunSpeed;

    void Start() //sets up the starting gun
    {
        player = GameObject.FindGameObjectWithTag("Player");
        originalRunSpeed = player.GetComponent<TopDownMovement>().runSpeed;

        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
        player.GetComponent<TopDownMovement>().runSpeed *= currentGun.GetComponent<Shooting>().weight;
    }

    void Update()
    {
        totalWeapons = guns.Count;
        currentGunShooting = currentGun.GetComponent<Shooting>();

        if (Input.GetKeyDown(KeyCode.Alpha2)) //move to next weapon
        {
            //next weapon
            if(currentWeaponIndex < totalWeapons-1)
            {
                int currentSortingOrder = currentGun.GetComponentInChildren<SpriteRenderer>().sortingOrder;
                player.GetComponent<TopDownMovement>().runSpeed = originalRunSpeed;
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex++;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
                currentGun.GetComponentInChildren<SpriteRenderer>().sortingOrder = currentSortingOrder;
                player.GetComponent<TopDownMovement>().runSpeed *= currentGun.GetComponent<Shooting>().weight;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) //move to previous weapon
        {
            //previous weapon
            if (currentWeaponIndex > 0) //if not the first weapon
            {
                int currentSortingOrder = currentGun.GetComponentInChildren<SpriteRenderer>().sortingOrder;
                player.GetComponent<TopDownMovement>().runSpeed = originalRunSpeed;
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex--;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
                currentGun.GetComponentInChildren<SpriteRenderer>().sortingOrder = currentSortingOrder;
                player.GetComponent<TopDownMovement>().runSpeed *= currentGun.GetComponent<Shooting>().weight;
            }
        }

        //setting UI
        bulletCountText.text = currentGunShooting.bulletsInMag.ToString() + "/" + currentGunShooting.totalBullets.ToString(); 
    }

    public void SetGunsActive()
    {
        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
    }

    public void RefreshGunList()
    {
        guns.Clear();
        for (int i = 0; i < weaponHolder.transform.childCount; i++)
        {
            guns.Add(weaponHolder.transform.GetChild(i).gameObject);
        }
    }
}
