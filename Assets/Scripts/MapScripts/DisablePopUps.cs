using System.Collections.Generic;
using UnityEngine;

public class DisablePopUps : MonoBehaviour
{
    public List<BoxCollider2D> boxCollidersToDisable;
    private CollisionDetection collisionDetection;

    public void Start()
    {
        collisionDetection = GetComponent<CollisionDetection>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < boxCollidersToDisable.Count; ++i)
            {
                if (collisionDetection != null) //if the object has a collision detection script
                {
                    if (collisionDetection.hasBeenBought == true)
                    {
                        boxCollidersToDisable[i].enabled = false;
                    }
                }
                else
                {
                    boxCollidersToDisable[i].enabled = false;
                }
            }
        }
    }
}
