using UnityEngine;
using UnityEngine.UI;

public class GunImage : MonoBehaviour
{
    private GameObject player;
    private GameObject gunHolder;
    private weaponManager playerShooting;
    private Image imageObject;

    private void Start() 
    {
        player = GameObject.FindWithTag("Player");
        gunHolder = GameObject.FindWithTag("GunHolder");
        playerShooting = gunHolder.GetComponent<weaponManager>();
        imageObject = GetComponent<Image>();
    }

    public void Update()
    {
        imageObject.SetNativeSize();
        imageObject.sprite = playerShooting.currentGun.GetComponent<Shooting>().UIphoto;
        imageObject.SetNativeSize();
    }
}
