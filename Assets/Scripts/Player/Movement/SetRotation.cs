using UnityEngine;

public class SetRotation : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Tooltip("How quickly the camera moves to the player.")] public float damping;

    private Vector3 vel = Vector3.zero;

    public void Update()
    {
        Vector3 targetPosition = player.position + offset;
        targetPosition.z = transform.position.z; //keeps camera z position static
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);
    }
}
