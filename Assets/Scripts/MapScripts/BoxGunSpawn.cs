using UnityEngine;

public class BoxGunSpawn : MonoBehaviour
{
    public GameObject[] availableGuns;
    public GameObject currentGunInstance = null;
    public float priceToHit;
    private DifficultyManager difficultyManager;
    private weaponManager weaponManager;
    private GameObject currentDetails;
    private GameObject player;
    private CircleCollider2D circleCollider;
    public bool playerInRange = false;

    void Start()
    {
        weaponManager = GameObject.FindGameObjectWithTag("GunHolder").GetComponent<weaponManager>();
        player = GameObject.FindWithTag("Player");
        circleCollider = GetComponent<CircleCollider2D>();
        currentDetails = GameObject.FindGameObjectWithTag("CurrentDetails");

        //setting price increase of difficulty
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        priceToHit = priceToHit * difficultyManager.priceMultiplier;
    }

    void Update()
    {
        if(currentGunInstance == null)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<PointSystem>().totalPoints >= priceToHit)
            {
                player.GetComponent<PointSystem>().totalPoints -= priceToHit;

                // Spawn a new random gun from the availableGuns array
                int randomIndex = Random.Range(0, availableGuns.Length);
                bool isDuplicate = true;

                //keeps generating a random index until it finds a gun that is not already in the player's inventory
                while(isDuplicate)
                {
                    isDuplicate = false;
                    for (int i = 0; i < weaponManager.guns.Count; i++)
                    {
                        if (weaponManager.guns[i].GetComponent<Shooting>().gunName == availableGuns[randomIndex].GetComponent<BoxGunTake>().nameOfGun)
                        {
                            isDuplicate = true;
                            randomIndex = Random.Range(0, availableGuns.Length);
                            break;
                        }
                    }
                }

                currentGunInstance = Instantiate(availableGuns[randomIndex], transform.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(currentGunInstance == null)
            {
                playerInRange = true;
                currentDetails.SetActive(true);
                currentDetails.GetComponent<TMPro.TMP_Text>().text = "Press E to hit the box for " + priceToHit + " points";
            }
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
}
