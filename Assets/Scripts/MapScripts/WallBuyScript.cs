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
    public bool hasAlreadyBeenBought;

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
            if (player.GetComponent<PointSystem>().totalPoints >= costOfGun && hasAlreadyBeenBought == false) 
            {
                hasAlreadyBeenBought = true;

                if (weaponManager.guns.Count >= 3)
                {
                    GameObject oldGun = weaponManager.currentGun;
                    int replaceIndex = weaponManager.currentWeaponIndex;

                    // Create new gun
                    GameObject newGun = Instantiate(wallBuyWeapon, gunHolderTransform);

                    // Move new gun to the same hierarchy slot
                    newGun.transform.SetSiblingIndex(replaceIndex);

                    // Destroy old one and replace in list
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

                // Deduct points and refresh weapon setup
                player.GetComponent<PointSystem>().totalPoints -= costOfGun;

                // Start coroutine to refresh next frame
                // This is to stop Destroy from activating after the list is sorted. Which is so niche and dumb.
                StartCoroutine(RefreshWeaponsNextFrame());
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

    private System.Collections.IEnumerator RefreshWeaponsNextFrame()
    {
        // Wait one frame so Destroy() finishes
        yield return null;

        weaponManager.RefreshGunList();
        weaponManager.SetGunsActive();

        weaponManager.currentWeaponIndex = weaponManager.guns.IndexOf(weaponManager.currentGun);
        if (weaponManager.currentWeaponIndex >= 0)
            weaponManager.guns[weaponManager.currentWeaponIndex].SetActive(true);
    }
}