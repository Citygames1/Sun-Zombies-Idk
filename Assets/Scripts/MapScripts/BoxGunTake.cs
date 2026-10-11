using UnityEngine;
using TMPro;

public class BoxGunTake : MonoBehaviour
{
    private GameObject boxGunSpawner;
    private GameObject currentDetails;
    private GameObject gunHolder;
    private Transform gunHolderTransform;
    private GameObject player;
    public GameObject gunToGet;
    private weaponManager weaponManager;
    public string nameOfGun;
    private bool playerInRange = false;

    void Awake()
    {
        boxGunSpawner = GameObject.FindGameObjectWithTag("BoxGunSpawner");
        currentDetails = GameObject.FindGameObjectWithTag("CurrentDetails");
        player = GameObject.FindWithTag("Player");
        gunHolder = GameObject.FindWithTag("GunHolder");
        gunHolderTransform = gunHolder.transform;
        weaponManager = gunHolder.GetComponent<weaponManager>();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            currentDetails.SetActive(false);

            if (weaponManager.guns.Count >= 3)
            {
                GameObject oldGun = weaponManager.currentGun;
                int replaceIndex = weaponManager.currentWeaponIndex;

                GameObject newGun = Instantiate(gunToGet, gunHolderTransform);
                newGun.transform.SetSiblingIndex(replaceIndex);
                boxGunSpawner.GetComponent<BoxGunSpawn>().currentGunInstance = null;
                Destroy(oldGun);

                weaponManager.guns[replaceIndex] = newGun;
                weaponManager.currentGun = newGun;

                // Update player speed based on the new gun's weight
                player.GetComponent<TopDownMovement>().runSpeed = weaponManager.originalRunSpeed;
                player.GetComponent<TopDownMovement>().runSpeed *= weaponManager.currentGun.GetComponent<Shooting>().weight;
            }
            else
            {
                // Add new gun normally
                GameObject oldGun = weaponManager.currentGun;
                GameObject newGun = Instantiate(gunToGet, gunHolderTransform);
                oldGun.SetActive(false);
                weaponManager.currentWeaponIndex++;
                weaponManager.guns.Insert(weaponManager.currentWeaponIndex, newGun);
                weaponManager.currentGun = newGun;

                // Update player speed based on the new gun's weight
                player.GetComponent<TopDownMovement>().runSpeed = weaponManager.originalRunSpeed;
                player.GetComponent<TopDownMovement>().runSpeed *= weaponManager.currentGun.GetComponent<Shooting>().weight;
            }

            // Start coroutine to refresh next frame
            // This is to stop Destroy from activating after the list is sorted. Which is so niche and dumb.
            StartCoroutine(RefreshWeaponsNextFrame());
            boxGunSpawner.GetComponent<BoxGunSpawn>().currentGunInstance = null;
            Destroy(gameObject);
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.Q))
        {
            currentDetails.SetActive(false);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            currentDetails.GetComponent<TMP_Text>().text = "Press E to take the" + nameOfGun + ", or press Q to discard it.";
            currentDetails.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            currentDetails.SetActive(false);
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

// errors consist of the current details object being set to inactive while the player is still in range, but the box gun spawn tries to activate it again.