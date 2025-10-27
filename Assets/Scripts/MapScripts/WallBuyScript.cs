using UnityEngine;
using TMPro;

public class WallBuyScript : MonoBehaviour
{

    private DifficultyManager difficultyManager;
    public GameObject textObject;
    public GameObject wallBuyWeapon;
    private GameObject gunHolder;
    private Transform gunHolderTransform;
    private weaponManager weaponManager;
    private GameObject player;

    public float costOfGun;
    public string nameOfGun;

    public bool inRange;
    public bool hasGun = false;

    public void Start()
    {
        //setting price increase of difficulty
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        costOfGun = costOfGun * difficultyManager.priceMultiplier;
        textObject.GetComponent<TMP_Text>().text = "Press E to buy a " + nameOfGun + " for " + costOfGun;

        player = GameObject.FindWithTag("Player");
        gunHolder = GameObject.FindWithTag("GunHolder");
        gunHolderTransform = gunHolder.transform;
        weaponManager = gunHolder.GetComponent<weaponManager>();
    }

    public void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<PointSystem>().totalPoints >= costOfGun && hasGun == false)
            {
                hasGun = true;

                if (weaponManager.guns.Count >= 3)
                {
                    GameObject oldGun = weaponManager.currentGun;
                    int replaceIndex = weaponManager.currentWeaponIndex;

                    GameObject newGun = Instantiate(wallBuyWeapon, gunHolderTransform);
                    newGun.transform.SetSiblingIndex(replaceIndex);
                    Destroy(oldGun);

                    weaponManager.guns[replaceIndex] = newGun;
                    weaponManager.currentGun = newGun;
                }
                else
                {
                    // Add new gun normally
                    GameObject newGun = Instantiate(wallBuyWeapon, gunHolderTransform);
                    weaponManager.guns.Insert(weaponManager.currentWeaponIndex + 1, newGun);
                    weaponManager.currentGun = newGun;
                }
                player.GetComponent<PointSystem>().totalPoints -= costOfGun;

                // Start coroutine to refresh next frame
                // This is to stop Destroy from activating after the list is sorted. Which is so niche and dumb.
                StartCoroutine(RefreshWeaponsNextFrame());
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            inRange = true;

            //checking if the player already has the gun
            for (int i = 0; i < weaponManager.guns.Count; i++)
            {
                if (weaponManager.guns[i].CompareTag(nameOfGun))
                {
                    hasGun = true;
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            hasGun = false; //auto assumes the player doesnt have the gun anymore, as it will be checked again regardless
        }
    }

    private System.Collections.IEnumerator RefreshWeaponsNextFrame()
    {
        // Wait one frame so Destroy() finishes. which is so niche and dumb
        yield return null;

        weaponManager.RefreshGunList();
        weaponManager.SetGunsActive();

        weaponManager.currentWeaponIndex = weaponManager.guns.IndexOf(weaponManager.currentGun);
        if (weaponManager.currentWeaponIndex >= 0)
            weaponManager.guns[weaponManager.currentWeaponIndex].SetActive(true);
    }
}