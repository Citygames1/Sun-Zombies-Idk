using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Scene activeScene;

    public List <GameObject> zombies;
    public float roundCount = 3;
    public float zombiesInARound;
    public int zombiesSpawned;

    public TMP_Text roundCountText;
    public TMP_Text pointCountText;

    public GameObject player;
    public GameObject roundCountUI;
    public GameObject ammoCountUI;
    public GameObject healthBarBorderUI;
    public GameObject pointsCountUI;
    public GameObject restartButtonUI;
    public GameObject mainMenuButtonUI;
    public GameObject splashTextUI;
    private PlayerHealth playerHealth;
    private PointSystem pointSystem;

    //difficulty stuff
    public float difficulty = 1;

    //timer
    public int timeBetweenSpawns = 1;
    public float timeBetweenSpawnsTimer;
    public bool timerHasFinished;

    public void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        playerHealth = player.GetComponent<PlayerHealth>();
        pointSystem = player.GetComponent<PointSystem>();
        roundCount++;

        timeBetweenSpawnsTimer = timeBetweenSpawns;
    }
    public void Update()
    {
        if (timeBetweenSpawnsTimer > 0)
        {
            timerHasFinished = false;
            timeBetweenSpawnsTimer -= Time.deltaTime;
        }

        if (timeBetweenSpawnsTimer < 0)
        {
            timerHasFinished = true;
            timeBetweenSpawnsTimer = timeBetweenSpawns;
        }

        roundCountText.text = roundCount.ToString();
        pointCountText.text = pointSystem.totalPoints.ToString();

        if(playerHealth.isDead == true)
        {
            roundCountUI.SetActive(false);
            ammoCountUI.SetActive(false);
            healthBarBorderUI.SetActive(false);
            pointsCountUI.SetActive(false);
            restartButtonUI.SetActive(true);
            mainMenuButtonUI.SetActive(true);
            splashTextUI.SetActive(true);
        }
    }
}
