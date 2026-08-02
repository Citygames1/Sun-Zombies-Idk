using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool isActive = false;
    public GameObject playerUI;
    public GameObject EscapeMenuUI;
    private GameObject gunHolder;
    private float previousTimeScale;

    void Start()
    {
        gunHolder = GameObject.FindWithTag("GunHolder");
        previousTimeScale = Time.timeScale;
    }

    void Update()
    {
        //if the player isnt dead and presses P
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().isDead == false)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if(isActive == false)
        {
            Time.timeScale = 0;
            gunHolder.GetComponent<weaponManager>().currentGun.GetComponent<Shooting>().timeBetweenShotTimerRunning = true;
            EscapeMenuUI.transform.localScale = new Vector3(1,1,1);
            playerUI.transform.localScale = new Vector3(0,0,1);
            isActive = true;
        }
        else
        {
            Time.timeScale = previousTimeScale;
            EscapeMenuUI.transform.localScale = new Vector3(0,0,1);
            playerUI.transform.localScale = new Vector3(1,1,1);
            isActive = false;
        }
    }
}
