using UnityEngine;

public class StairMovement : MonoBehaviour
{
    public GameObject Player;
    private TopDownMovement pMovement;
    private float initialSpeed;

    private void Start()
    {
        pMovement = Player.GetComponent<TopDownMovement>();
        initialSpeed = pMovement.runSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pMovement.isRolling = false;
        pMovement.canRoll = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pMovement.movement.y > 0)
        {
            pMovement.runSpeed = 5f;
        }
        if (pMovement.movement.y < 0)
        {
            pMovement.runSpeed = 7.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pMovement.canRoll = true;
        pMovement.runSpeed = initialSpeed;
    }
}
