using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List <GameObject> zombies;
    public float roundCount = 3;
    public float zombiesInARound;
    [HideInInspector] public int zombiesSpawned;

    private TMP_Text roundCountText;
    private TMP_Text pointCountText;

    private GameObject player;
    private GameObject roundCountUI;
    private GameObject ammoCountUI;
    private GameObject healthBarBorderUI;
    private GameObject pointsCountUI;
    private GameObject FPScount;
    private GameObject restartButtonUI;
    private GameObject mainMenuButtonUI;
    private GameObject splashTextUI;
    private PlayerHealth playerHealth;
    private PointSystem pointSystem;

    //timer
    public int SpawnTimer = 1;
    [HideInInspector] public float timeBetweenSpawnsTimer;
    [HideInInspector] public bool timerHasFinished;

    public void Start()
    {
        //setting variables
        player = GameObject.FindGameObjectWithTag("Player");
        roundCountText = GameObject.FindGameObjectWithTag("RoundCountText").GetComponent<TMP_Text>();
        pointCountText = GameObject.FindGameObjectWithTag("PointCountText").GetComponent<TMP_Text>();
        roundCountUI = GameObject.FindGameObjectWithTag("RoundCount");
        ammoCountUI = GameObject.FindGameObjectWithTag("AmmoCount");
        healthBarBorderUI = GameObject.FindGameObjectWithTag("HealthBarBorder");
        pointsCountUI = GameObject.FindGameObjectWithTag("PointCount");
        FPScount = GameObject.FindGameObjectWithTag("FPScount");
        restartButtonUI = GameObject.FindGameObjectWithTag("RestartButton");
        mainMenuButtonUI = GameObject.FindGameObjectWithTag("MainMenuButton");
        splashTextUI = GameObject.FindGameObjectWithTag("SplashText");

        playerHealth = player.GetComponent<PlayerHealth>();
        pointSystem = player.GetComponent<PointSystem>();

        //turn off deathscreen
        restartButtonUI.SetActive(false);
        mainMenuButtonUI.SetActive(false);
        splashTextUI.SetActive(false);

        //starting rounds
        roundCount++;

        //setting timers
        timeBetweenSpawnsTimer = SpawnTimer;
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
            timeBetweenSpawnsTimer = SpawnTimer;
        }

        roundCountText.text = roundCount.ToString();
        pointCountText.text = pointSystem.totalPoints.ToString();

        if(playerHealth.isDead == true)
        {
            roundCountUI.SetActive(false);
            ammoCountUI.SetActive(false);
            healthBarBorderUI.SetActive(false);
            pointsCountUI.SetActive(false);
            FPScount.SetActive(false);
            restartButtonUI.SetActive(true);
            mainMenuButtonUI.SetActive(true);
            splashTextUI.SetActive(true);
        }
    }
}
