using UnityEngine;
using Pathfinding;

public class LungerPathfind : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    Seeker seeker;
    Rigidbody2D rb;
    IAstarAI ai;
    Path path;
    int currentWaypoint = 0;

    //bool reachedEndOfPath = false;
    private Transform target;
    private Vector2 relativePoint;

    public float speed = 200f;
    private float nextWaypointDistance = 3;
    private float timeBetweenWaypoints = 0.1f;

    //timer
    public float movementTimer;
    private float movementTimerTime;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        //Name, When you want it to start, how often you want it to repeat (in seconds)
        InvokeRepeating("UpdatePath", 0f, timeBetweenWaypoints);
        movementTimerTime = movementTimer;
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

        if (movementTimerTime <= 0)
        {
            rb.AddForce(followForce);
            movementTimerTime = movementTimer;
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        relativePoint = transform.InverseTransformPoint(target.position);

        if (relativePoint.x < 0f)
        {
            //on the right
            spriteRenderer.flipX = true;
        }
        if (relativePoint.x > 0f)
        {
            //on the left
            spriteRenderer.flipX = false;
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
