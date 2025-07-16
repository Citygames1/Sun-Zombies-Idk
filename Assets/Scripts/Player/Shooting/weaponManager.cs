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

    void Start()
    {
        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
    }

    void Update()
    {
        totalWeapons = weaponHolder.transform.childCount;
        currentGunShooting = currentGun.GetComponent<Shooting>();

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //next weapon
            if(currentWeaponIndex < totalWeapons-1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex++;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //previous weapon
            if (currentWeaponIndex > 0)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex--;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
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
}
