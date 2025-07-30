using UnityEngine;
using CodeMonkey.Utils;

public class AimWeapon : MonoBehaviour
{
    private Transform currentGunTransform;

    private GameObject gunHolder;
    private weaponManager wpnManager;
    private GameObject player;
    private TopDownMovement playerMovement;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        gunHolder = GameObject.FindWithTag("GunHolder");
        wpnManager = gunHolder.GetComponent<weaponManager>();
        playerMovement = player.GetComponent<TopDownMovement>();
    }

    void Update()
    {
        currentGunTransform = wpnManager.currentGun.transform;

        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        if (playerMovement.flipGuns == false)
        {
            currentGunTransform.eulerAngles = new Vector3(0, 0, angle);
        }
        else {
            currentGunTransform.eulerAngles = new Vector3(180, 0, -angle);
        }
    }
}
