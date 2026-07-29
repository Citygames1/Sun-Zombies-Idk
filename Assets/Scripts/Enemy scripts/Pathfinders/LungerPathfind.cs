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
    public float nextWaypointDistance = 3;
    public float timeBetweenWaypoints = 1f;

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

        if (movementTimerTime <= 0)
        {
            animator.SetTrigger("lunge");
            lungeActive = true;
            movementTimerTime = movementTimer;
        }

        if (lungeActive == true)
        {
            lengthOfLungeTime -= Time.deltaTime;

            Vector2 desiredVelocity = usedDirection * speed;
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, desiredVelocity, 10f * Time.fixedDeltaTime);

            if (lengthOfLungeTime <= 0)
            {
                lungeActive = false;
                rb.linearVelocity = Vector2.zero;
                lengthOfLungeTime = lengthOfLunge;
            }
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //Flipping the sprite based on bigger movements rather than small
        float xDifference = target.position.x - transform.position.x;

        if (Mathf.Abs(xDifference) > 0.15f)
        {
            spriteRenderer.flipX = xDifference < 0;
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
