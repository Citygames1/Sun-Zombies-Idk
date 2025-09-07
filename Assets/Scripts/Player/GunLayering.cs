using UnityEngine;

public class GunLayering : MonoBehaviour
{
    private GameObject player;
    private weaponManager weaponManagerScript;
    private GameObject currentGun;
    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer cGunSpriteRenderer;

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
        if (collision.gameObject.tag == "Player")
        {
            cGunSpriteRenderer.sortingOrder -= 2;
            playerSpriteRenderer.sortingOrder -= 2;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            SpriteRenderer bulletSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            bulletSpriteRenderer.sortingOrder -= 1;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SpriteRenderer enemySpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            enemySpriteRenderer.sortingOrder -= 1;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cGunSpriteRenderer.sortingOrder += 2;
            playerSpriteRenderer.sortingOrder += 2;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            SpriteRenderer bulletSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            bulletSpriteRenderer.sortingOrder += 1;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SpriteRenderer enemySpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            enemySpriteRenderer.sortingOrder += 1;

        }
    }
}
