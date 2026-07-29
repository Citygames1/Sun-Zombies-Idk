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

    public float speed = 200f;
    public float nextWaypointDistance = 3;
    public float timeBetweenWaypoints = 0.5f;

    //dash stuff
    public float dashSpeed;
    public float dashLength = 0.65f;
    private float dashLengthTimer;
    public float dashCooldown = 1;
    private float dashCooldownTimer;
    private bool isOnCooldown = false;

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

        //Name, When you want it to start, how often you want it to repeat (in seconds)
        InvokeRepeating("UpdatePath", 0f, timeBetweenWaypoints);

        timeBetweenStepsTimer = timeBetweenSteps;
        dashLengthTimer = dashLength;
        dashCooldownTimer = dashCooldown;
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

        float distanceFromTarget = Vector2.Distance(transform.position, target.transform.position);

        if(distanceFromTarget < 8)
        {
            if(isOnCooldown == false)
            {
                dashLengthTimer -= Time.deltaTime;

                Vector2 desiredVelocity = usedDirection * dashSpeed;
                rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, desiredVelocity, 10f * Time.fixedDeltaTime);

                if(dashLengthTimer <= 0)
                {
                    isOnCooldown = true;
                    dashLengthTimer = dashLength;
                }
            }
            else
            {
                Vector2 desiredVelocity = usedDirection * speed;
                rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, desiredVelocity, 10f * Time.fixedDeltaTime);

                dashCooldownTimer -= Time.deltaTime;

                if(dashCooldownTimer <= 0)
                {
                    isOnCooldown = false;
                }
            }
        }
        else
        {
            Vector2 desiredVelocity = usedDirection * speed;
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, desiredVelocity, 10f * Time.fixedDeltaTime);

            dashLengthTimer = dashLength;
            dashCooldownTimer = dashCooldown;
        }

        timeBetweenStepsTimer -= Time.deltaTime;

        if(timeBetweenStepsTimer <= 0)
        {
            int randomInt = Random.Range(1,100);

            if(randomInt == 1){
                GameObject soundObj1 = AudioManager.Instance.Play(AudioManager.SoundType.DefaultGroan1);
                soundObj1.GetComponent<Transform>().position = GetComponent<Transform>().position;
            }
            else if(randomInt == 2){
                GameObject soundObj1 = AudioManager.Instance.Play(AudioManager.SoundType.DefaultGroan2);
                soundObj1.GetComponent<Transform>().position = GetComponent<Transform>().position;
            }

            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.DefaultWalk);
            soundObj.GetComponent<Transform>().position = GetComponent<Transform>().position;
            timeBetweenStepsTimer = timeBetweenSteps;
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        animator.SetFloat("Speed", distance);

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
