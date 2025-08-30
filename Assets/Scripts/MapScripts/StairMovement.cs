using UnityEngine;

public class StairMovement : MonoBehaviour
{
    public GameObject Player;
    private TopDownMovement pMovement;
    private float initialSpeed;
    public float speedReductionMultiplier;
    private bool hasEffected = false;

    private void Start()
    {
        pMovement = Player.GetComponent<TopDownMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pMovement.canRoll = false;
        initialSpeed = pMovement.runSpeed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hasEffected == false)
        {
            pMovement.runSpeed = pMovement.runSpeed * speedReductionMultiplier;
            hasEffected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pMovement.canRoll = true;
        pMovement.runSpeed = initialSpeed;
        hasEffected = false;
    }
}
