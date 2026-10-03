using UnityEngine;
using Pathfinding;

public class BrutePathfind : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BruteAttackl bruteAttack;
    public float distanceToKeep;

    Seeker seeker;
    Rigidbody2D rb;
    IAstarAI ai;
    Path path;
    int currentWaypoint = 0;

    private Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3;
    public float timeBetweenWaypoints = 0.5f;

    //footsteps
    public float timeBetweenSteps;
    private float timeBetweenStepsTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        bruteAttack = GetComponent<BruteAttackl>();

        //Name, When you want it to start, how often you want it to repeat (in seconds)
        InvokeRepeating("UpdatePath", 0f, timeBetweenWaypoints);

        timeBetweenStepsTimer = timeBetweenSteps;
    }

    private void Update()
    {
        if (target != null && ai != null) ai.destination = target.position;
    }

    void FixedUpdate()
    {
        if (path == null)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetFloat("Speed", 0f);
            bruteAttack.IsInRange();
            return;
        }
        else
        {
            bruteAttack.OutOfRange();
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetFloat("Speed", 0f);
            return;
        }

        Vector2 usedDirection = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 desiredVelocity = usedDirection * speed;

        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, desiredVelocity, 10f * Time.fixedDeltaTime);

        timeBetweenStepsTimer -= Time.deltaTime;

        if(timeBetweenStepsTimer <= 0)
        {
            int randomInt = Random.Range(1,100);

            if(randomInt == 1){
                GameObject soundObj1 = AudioManager.Instance.Play(AudioManager.SoundType.BruteGroan1);
                soundObj1.GetComponent<Transform>().position = GetComponent<Transform>().position;
            }
            else if(randomInt == 2){
                GameObject soundObj1 = AudioManager.Instance.Play(AudioManager.SoundType.BruteGroan2);
                soundObj1.GetComponent<Transform>().position = GetComponent<Transform>().position;
            }   

            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.BruteWalk);
            soundObj.GetComponent<Transform>().position = GetComponent<Transform>().position;
            timeBetweenStepsTimer = timeBetweenSteps;
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        float distanceFromPlayer = Vector2.Distance(rb.position, target.position);
        animator.SetFloat("Speed", rb.linearVelocity.magnitude);

        if(distance < nextWaypointDistance && distanceFromPlayer >= distanceToKeep)
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
        if (!seeker.IsDone())
            return;

        float dist = Vector2.Distance(rb.position, target.position);

        if (dist > distanceToKeep + 2)
        {
            // Chase
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        else
        {
            // Don't generate a new path.
            path = null;
        }
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
