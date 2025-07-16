using UnityEngine;
using CodeMonkey.Utils;

public class AimWeapon : MonoBehaviour
{
    public Transform currentGunTransform;

    public GameObject gunHolder;
    private weaponManager wpnManager;
    private TopDownMovement movement;

    public void Start()
    {
        wpnManager = gunHolder.GetComponent<weaponManager>();
        movement = GetComponent<TopDownMovement>();
    }

    void Update()
    {
        currentGunTransform = wpnManager.currentGun.transform;

        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        if (movement.flipGuns == false)
        {
            currentGunTransform.eulerAngles = new Vector3(0, 0, angle);
        }
        else
        {
            currentGunTransform.eulerAngles = new Vector3(180, 0, -angle);
        }
    }
}
