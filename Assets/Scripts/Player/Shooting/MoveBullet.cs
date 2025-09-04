using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float bulletForce = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletForce;
    }
}
