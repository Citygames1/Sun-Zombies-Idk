using UnityEngine;

public class BulletLayering : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            SpriteRenderer bulletSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            bulletSpriteRenderer.sortingOrder += 1;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            SpriteRenderer bulletSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            bulletSpriteRenderer.sortingOrder -= 1;
        }
    }
}
