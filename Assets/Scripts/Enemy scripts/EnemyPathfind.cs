using UnityEngine;
using Pathfinding;

public class EnemyPathfind : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Transform target;

    private Vector2 relativePoint;

    public float speed = 200f;
    public float nextWaypointDistance = 3;

    IAstarAI ai;
    Path path;
    int currentWaypoint = 0;
    //bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("UpdatePath", 0f, 0.1f);
    }

    private void Update()
    {
        if (target != null && ai != null) ai.destination = target.position;
    }

    void FixedUpdate()
    {

        if(path == null)
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
        Vector2 force = usedDirection * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        animator.SetFloat("Speed", distance);

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
