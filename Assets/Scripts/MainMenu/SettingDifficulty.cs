using UnityEngine;
using UnityEngine.UI;
using System;
public class SettingDifficulty : MonoBehaviour
{
    private DifficultyManager difficultyManager;

    void Start()
    {
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
    }

    public void SetStartingCash(GameObject thisSlider)
    {
        float startingCash = thisSlider.GetComponent<Slider>().value;
        difficultyManager.StartingPoints = startingCash;
    }

    public void SetPlayerHealthMultiplier(GameObject thisSlider)
    {
        float playerHMultiplier = thisSlider.GetComponent<Slider>().value;
        double result = Math.Round(playerHMultiplier, 2);
        float resultFloat  = System.Convert.ToSingle(result);
        difficultyManager.playerHealthMultiplier = resultFloat;
    }
    public void SetEnemyHealthMultiplier(GameObject thisSlider)
    {
        float enemyHMultiplier = thisSlider.GetComponent<Slider>().value;
        double result = Math.Round(enemyHMultiplier, 2);
        float resultFloat  = System.Convert.ToSingle(result);
        difficultyManager.enemyHealthMultiplier = resultFloat;
    }
    public void SetEnemySpeedMultiplier(GameObject thisSlider)
    {
        float enemySMultiplier = thisSlider.GetComponent<Slider>().value;
        double result = Math.Round(enemySMultiplier, 2);
        float resultFloat  = System.Convert.ToSingle(result);
        difficultyManager.enemySpeedMultiplier = resultFloat;
    }
    public void SetPointsMultiplier(GameObject thisSlider)
    {
        float pointMultiplier = thisSlider.GetComponent<Slider>().value;
        double result = Math.Round(pointMultiplier, 2);
        float resultFloat  = System.Convert.ToSingle(result);
        difficultyManager.pointsMultiplier = resultFloat;
    }
    public void SetPriceMultiplier(GameObject thisSlider)
    {
        float pricesMultiplier = thisSlider.GetComponent<Slider>().value;
        double result = Math.Round(pricesMultiplier, 2);
        float resultFloat  = System.Convert.ToSingle(result);
        difficultyManager.priceMultiplier = resultFloat;
    }
}
