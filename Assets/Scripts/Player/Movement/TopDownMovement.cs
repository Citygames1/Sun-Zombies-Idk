using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public bool isRolling;
    public bool flipGuns;
    public bool canRoll;

    [HideInInspector] public Vector2 movement;
    Vector2 rollDirection;

    public float rollSpeed;
    public float rollLength;
    private float rollLengthRevert;
    public float runSpeed;

    private void Start()
    {
        canRoll = true;
        rollLengthRevert = rollLength;
    }

    void Update()
    {
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(movement.x));
        animator.SetFloat("VerticalSpeed", Mathf.Abs(movement.y));

        if(isRolling == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            rollDirection = movement;
        }

        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
            flipGuns = true;
        }
        if(movement.x > 0)
        {
            spriteRenderer.flipX = false;
            flipGuns = false;
        }

        if(canRoll && Input.GetKeyDown(KeyCode.Space))
        {
            if (isRolling != true)
            {
                animator.SetBool("IsRolling", true);
            }
            isRolling = true;
        }
    }

    private void FixedUpdate()
    {
        if(isRolling == false)
        {
            body.MovePosition(body.position + movement.normalized * runSpeed * Time.fixedDeltaTime);
        }
        if(isRolling == true)
        {
            if(rollLength > rollSpeed)
            {
                body.MovePosition(body.position + rollDirection.normalized * rollSpeed * Time.fixedDeltaTime);
                rollLength -= Time.deltaTime;
            }
            else
            {
                animator.SetBool("IsRolling", false);
                isRolling = false;
                rollLength = rollLengthRevert;
            }

        }
    }
}
