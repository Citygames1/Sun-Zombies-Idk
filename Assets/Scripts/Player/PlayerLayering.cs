using UnityEngine;

public class PlayerLayering : MonoBehaviour
{
    public GameObject player;
    private weaponManager weaponManagerScript;
    private GameObject currentGun;
    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer cGunSpriteRenderer;
    private SpriteRenderer bulletSpriteRenderer;

    private void Start()
    {
        weaponManagerScript = player.GetComponentInChildren<weaponManager>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        currentGun = weaponManagerScript.currentGun;

        //you can surely do better than calling this EVERY frame lol
        cGunSpriteRenderer = currentGun.GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cGunSpriteRenderer.sortingOrder -= 1;
            playerSpriteRenderer.sortingOrder -= 1;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            bulletSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            bulletSpriteRenderer.sortingOrder -= 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cGunSpriteRenderer.sortingOrder += 1;
            playerSpriteRenderer.sortingOrder += 1;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            bulletSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            bulletSpriteRenderer.sortingOrder += 1;
        }
    }
}
