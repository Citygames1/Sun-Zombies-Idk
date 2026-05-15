using UnityEngine;
using Pathfinding;

public class TankPathfind : MonoBehaviour
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
        Vector2 followForce = usedDirection * speed;

        timeBetweenStepsTimer -= Time.deltaTime;

        if(timeBetweenStepsTimer <= 0)
        {
            int randomInt = Random.Range(1,100);

            if(randomInt == 1){
                AudioManager.Instance.Play(AudioManager.SoundType.TankGroan1);
            }
            else if(randomInt == 2){
                AudioManager.Instance.Play(AudioManager.SoundType.TankGroan2);
            }  


            AudioManager.Instance.Play(AudioManager.SoundType.TankWalk);
            timeBetweenStepsTimer = timeBetweenSteps;
        }

        rb.AddForce(followForce, ForceMode2D.Impulse);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        animator.SetFloat("Speed", distance);

        if (rb.linearVelocity.x >= 0.01f)
        {
            //on the right
            spriteRenderer.flipX = false;
        }
        if (rb.linearVelocity.x <= -0.01f)
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
