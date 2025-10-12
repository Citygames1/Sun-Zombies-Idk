using UnityEngine;

public class PointsTextHandler : MonoBehaviour
{
    public float duration;
    public float moveSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        duration -= Time.deltaTime;
        
        rb.linearVelocityY = moveSpeed * Time.deltaTime;

        if(duration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
