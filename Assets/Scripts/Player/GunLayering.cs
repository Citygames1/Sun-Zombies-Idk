using UnityEngine;

public class GunLayering : MonoBehaviour
{
    private GameObject player;
    private weaponManager weaponManagerScript;
    private GameObject currentGun;
    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer cGunSpriteRenderer;

    public bool layerPlayer = true;
    public bool layerGun = true;
    public bool layerBullets = true;
    public bool layerEnemy = true;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weaponManagerScript = player.GetComponentInChildren<weaponManager>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        currentGun = weaponManagerScript.currentGun;
        cGunSpriteRenderer = currentGun.GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && layerPlayer == true)
        {
            playerSpriteRenderer.sortingOrder -= 2;

            if (layerGun == true)
            {
                cGunSpriteRenderer.sortingOrder -= 2;
            }
        }
        if (collision.gameObject.tag == "Bullet" && layerBullets == true)
        {
            SpriteRenderer bulletSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            bulletSpriteRenderer.sortingOrder -= 1;
        }
        if (collision.gameObject.tag == "EnemyCollision" && layerEnemy == true)
        {
            SpriteRenderer enemySpriteRenderer = collision.gameObject.GetComponentInParent<SpriteRenderer>();
            enemySpriteRenderer.sortingOrder -= 2;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && layerPlayer == true)
        {
            playerSpriteRenderer.sortingOrder += 2;

            if (layerGun == true)
            {
                cGunSpriteRenderer.sortingOrder += 2;
            }
        }
        if (collision.gameObject.tag == "Bullet" && layerBullets == true)
        {
            SpriteRenderer bulletSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            bulletSpriteRenderer.sortingOrder += 1;
        }
        if (collision.gameObject.tag == "EnemyCollision" && layerEnemy == true)
        {
            SpriteRenderer enemySpriteRenderer = collision.gameObject.GetComponentInParent<SpriteRenderer>();
            enemySpriteRenderer.sortingOrder += 2;

        }
    }
}
