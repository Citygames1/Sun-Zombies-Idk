using UnityEngine;
using Pathfinding;

public class SprinterPathfind : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    Seeker seeker;
    Rigidbody2D rb;
    IAstarAI ai;
    Path path;
    int currentWaypoint = 0;

    private Transform target;
    public float speed = 50f;
    public float dashSpeed = 1000f;

    //timers
    public int dashAmount = 3;
    private int step = 0;
    public float inbetweenDashLength = 1f;
    private float inbetweenDashTimer;
    public float dashCooldownLength = 5f;
    private float dashCooldownTimer = 0f;

    private float nextWaypointDistance = 3;
    private float timeBetweenWaypoints = 0.1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        //Name, When you want it to start, how often you want it to repeat (in seconds)
        InvokeRepeating("UpdatePath", 0f, timeBetweenWaypoints);
    }

    private void Update()
    {
        if (target != null && ai != null) ai.destination = target.position;
    }

    void FixedUpdate()
    {

        if (path == null){
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count){
            return;
        }

        float distanceFromTarget = Vector2.Distance(target.position, rb.position);
        Vector2 usedDirection = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        if (distanceFromTarget < 8)
        {
            dashCooldownTimer -= Time.deltaTime;

            if (dashCooldownTimer <= 0)
            {
                inbetweenDashTimer -= Time.deltaTime;

                if (inbetweenDashTimer <= 0 && step < dashAmount)
                {
                    Vector2 dashForce = usedDirection * dashSpeed;
                    rb.AddForce(dashForce, ForceMode2D.Impulse);
                    step++;
                    inbetweenDashTimer = inbetweenDashLength;
                }
                else if(step >= dashAmount)
                {
                    step = 0;
                    dashCooldownTimer = dashCooldownLength;
                }
            }
        }
        else
        {
            dashCooldownTimer = 0;
            inbetweenDashTimer = 0;
        }

        Vector2 followForce = usedDirection * speed;
        rb.AddForce(followForce, ForceMode2D.Impulse);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        animator.SetFloat("Speed", distance);

        if (rb.velocity.x >= 0.01f)
        {
            //on the right
            spriteRenderer.flipX = false;
        }
        if (rb.velocity.x <= -0.01f)
        {
            //on the left
            spriteRenderer.flipX = true;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
