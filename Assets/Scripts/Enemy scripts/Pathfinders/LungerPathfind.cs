using UnityEngine;
using Pathfinding;

public class LungerPathfind : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    Seeker seeker;
    Rigidbody2D rb;
    IAstarAI ai;
    Path path;
    int currentWaypoint = 0;

    //bool reachedEndOfPath = false;
    private Transform target;
    public float speed = 200f;
    private float nextWaypointDistance = 3;
    private float timeBetweenWaypoints = 0.1f;

    //timer
    public float movementTimer;
    private float movementTimerTime;
    public float lengthOfLunge;
    private float lengthOfLungeTime;
    private bool lungeActive;


    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        //Name, When you want it to start, how often you want it to repeat (in seconds)
        InvokeRepeating("UpdatePath", 0f, timeBetweenWaypoints);
        movementTimerTime = movementTimer;
        lengthOfLungeTime = lengthOfLunge;
    }

    private void Update()
    {
        if (target != null && ai != null) ai.destination = target.position;
    }

    void FixedUpdate()
    {
        //lunge timer
        movementTimerTime -= Time.deltaTime;
        
        if (path == null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count) 
        {
            //reachedEndOfPath = true;
            return;
        }
        else
        {
            //reachedEndOfPath = false;
        }

        Vector2 usedDirection = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 followForce = usedDirection * speed;

        //issue of tiny jump lies with ^ not being a big enough value to give a lot of force i believe
        //issue of animation not playing when thing is bumped lies with 

        if (movementTimerTime <= 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(followForce, ForceMode2D.Impulse);
            animator.SetBool("Lunge", true);
            lungeActive = true;
            movementTimerTime = movementTimer;
        }

        if (lungeActive == true)
        {
            lengthOfLungeTime -= Time.deltaTime;

            if (lengthOfLungeTime <= 0)
            {
                animator.SetBool("Lunge", false);
                lungeActive = false;
                lengthOfLungeTime = lengthOfLunge;
            }
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //animator.SetBool("Lunge", false);

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
