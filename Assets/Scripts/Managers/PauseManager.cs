using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public Animator optionsMenu;
    public GameObject playerUI;
    float previousTimeScale;

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
        optionsMenu.SetTrigger("Change");
        if(Time.timeScale > 0)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            playerUI.SetActive(false);
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = previousTimeScale;
            playerUI.SetActive(true);
        }
    }
}
