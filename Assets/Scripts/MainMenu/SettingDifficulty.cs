using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class SettingDifficulty : MonoBehaviour
{
    private DifficultyManager difficultyManager;

    private string startingCashString;
    private string setPlayerHMultiplierString;
    private string setEnemyHMultiplierString;
    private string setEnemySMultiplierString;
    private string setPointsMultiplierString;
    private string setPriceMultiplierString;

    private int startingCashInt;
    private float setPlayerHMultiplierFloat;
    private float setEnemyHMultiplierFloat;
    private float setEnemySMultiplierFloat;
    private float setPointsMultiplierFloat;
    private float setPriceMultiplierFloat;

    void Start()
    {
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
    }

    #region setting the slider values and rounding them to 2 digits
    public void SetStartingCash(GameObject thisSlider)
    {
        float startingCash = thisSlider.GetComponent<Slider>().value;
        difficultyManager.StartingPoints = startingCash;
        string resultString = System.Convert.ToString(startingCash);
        startingCashString = resultString;
    }
    public void SetPlayerHealthMultiplier(GameObject thisSlider)
    {
        float playerHMultiplier = thisSlider.GetComponent<Slider>().value;
        double result = Math.Round(playerHMultiplier, 2);
        float resultFloat = System.Convert.ToSingle(result);
        string resultString = System.Convert.ToString(resultFloat);
        difficultyManager.playerHealthMultiplier = resultFloat;
        setPlayerHMultiplierString = resultString;
    }
    public void SetEnemyHealthMultiplier(GameObject thisSlider)
    {
        float enemyHMultiplier = thisSlider.GetComponent<Slider>().value;
        double result = Math.Round(enemyHMultiplier, 2);
        float resultFloat = System.Convert.ToSingle(result);
        string resultString = System.Convert.ToString(resultFloat);
        difficultyManager.enemyHealthMultiplier = resultFloat;
        setEnemyHMultiplierString = resultString;
    }
    public void SetEnemySpeedMultiplier(GameObject thisSlider)
    {
        float enemySMultiplier = thisSlider.GetComponent<Slider>().value;
        double result = Math.Round(enemySMultiplier, 2);
        float resultFloat = System.Convert.ToSingle(result);
        string resultString = System.Convert.ToString(resultFloat);
        difficultyManager.enemySpeedMultiplier = resultFloat;
        setEnemySMultiplierString = resultString;
    }
    public void SetPointsMultiplier(GameObject thisSlider)
    {
        float pointMultiplier = thisSlider.GetComponent<Slider>().value;
        double result = Math.Round(pointMultiplier, 2);
        float resultFloat = System.Convert.ToSingle(result);
        string resultString = System.Convert.ToString(resultFloat);
        difficultyManager.pointsMultiplier = resultFloat;
        setPointsMultiplierString = resultString;
    }
    public void SetPriceMultiplier(GameObject thisSlider)
    {
        float pricesMultiplier = thisSlider.GetComponent<Slider>().value;
        double result = Math.Round(pricesMultiplier, 2);
        float resultFloat = System.Convert.ToSingle(result);
        string resultString = System.Convert.ToString(resultFloat);
        difficultyManager.priceMultiplier = resultFloat;
        setPriceMultiplierString = resultString;
    }
    #endregion

    #region setting the input field texts
    public void SetStartingCashText(GameObject thisInputField)
    {
        thisInputField.GetComponent<TMP_InputField>().text = startingCashString;
    }
    public void SetPlayerHealthMultiplierText(GameObject thisInputField)
    {
        thisInputField.GetComponent<TMP_InputField>().text = setPlayerHMultiplierString;
    }
    public void SetEnemyHealthMultiplierText(GameObject thisInputField)
    {
        thisInputField.GetComponent<TMP_InputField>().text = setEnemyHMultiplierString;
    }
    public void SetEnemySpeedMultiplierText(GameObject thisInputField)
    {
        thisInputField.GetComponent<TMP_InputField>().text = setEnemySMultiplierString;
    }
    public void SetPointsMultiplierText(GameObject thisInputField)
    {
        thisInputField.GetComponent<TMP_InputField>().text = setPointsMultiplierString;
    }
    public void SetPriceMultiplierText(GameObject thisInputField)
    {
        thisInputField.GetComponent<TMP_InputField>().text = setPriceMultiplierString;
    }
    #endregion

    #region setting the text values
    public void SetStartingCashInt(GameObject thisInputField)
    {
        startingCashInt = (int)System.Convert.ToInt64(thisInputField.GetComponent<TMP_InputField>().text);
    }
    public void SetPlayerHealthMultiplierFloat(GameObject thisInputField)
    {
        setPlayerHMultiplierFloat = (float)System.Convert.ToDouble(thisInputField.GetComponent<TMP_InputField>().text);
    }
    public void SetEnemyHealthMultiplierFloat(GameObject thisInputField)
    {
        setEnemyHMultiplierFloat = (float)System.Convert.ToDouble(thisInputField.GetComponent<TMP_InputField>().text);
    }
    public void SetEnemySpeedMultiplierFloat(GameObject thisInputField)
    {
        setEnemySMultiplierFloat = (float)System.Convert.ToDouble(thisInputField.GetComponent<TMP_InputField>().text);
    }
    public void SetPointsMultiplierFloat(GameObject thisInputField)
    {
        setPointsMultiplierFloat = (float)System.Convert.ToDouble(thisInputField.GetComponent<TMP_InputField>().text);
    }
    public void SetPriceMultiplierFloat(GameObject thisInputField)
    {
        setPriceMultiplierFloat = (float)System.Convert.ToDouble(thisInputField.GetComponent<TMP_InputField>().text);
    }
    #endregion

    #region setting the slider values to the input field texts
    public void SetStartingCashFromInput(GameObject thisSlider)
    {
        if (startingCashInt > thisSlider.GetComponent<Slider>().maxValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().maxValue;
        }
        else if (startingCashInt < thisSlider.GetComponent<Slider>().minValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().minValue;
        }
        else
        {
            thisSlider.GetComponent<Slider>().value = startingCashInt;
        }
    }
    public void SetPlayerHealthMultiplierFromInput(GameObject thisSlider)
    {
        if (setPlayerHMultiplierFloat > thisSlider.GetComponent<Slider>().maxValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().maxValue;
        }
        else if (setPlayerHMultiplierFloat < thisSlider.GetComponent<Slider>().minValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().minValue;
        }
        else
        {
            thisSlider.GetComponent<Slider>().value = setPlayerHMultiplierFloat;
        }
    }
    public void SetEnemyHealthMultiplierFromInput(GameObject thisSlider)
    {
        if (setEnemyHMultiplierFloat > thisSlider.GetComponent<Slider>().maxValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().maxValue;
        }
        else if (setEnemyHMultiplierFloat < thisSlider.GetComponent<Slider>().minValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().minValue;
        }
        else
        {
            thisSlider.GetComponent<Slider>().value = setEnemyHMultiplierFloat;
        }
    }
    public void SetEnemySpeedMultiplierFromInput(GameObject thisSlider)
    {
        if (setEnemySMultiplierFloat > thisSlider.GetComponent<Slider>().maxValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().maxValue;
        }
        else if (setEnemySMultiplierFloat < thisSlider.GetComponent<Slider>().minValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().minValue;
        }
        else
        {
            thisSlider.GetComponent<Slider>().value = setEnemySMultiplierFloat;
        }
    }
    public void SetPointsMultiplierFromInput(GameObject thisSlider)
    {
        if (setPointsMultiplierFloat > thisSlider.GetComponent<Slider>().maxValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().maxValue;
        }
        else if (setPointsMultiplierFloat < thisSlider.GetComponent<Slider>().minValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().minValue;
        }
        else
        {
            thisSlider.GetComponent<Slider>().value = setPointsMultiplierFloat;
        }
    }
    public void SetPriceMultiplierFromInput(GameObject thisSlider)
    {
        if (setPriceMultiplierFloat > thisSlider.GetComponent<Slider>().maxValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().maxValue;
        }
        else if (setPriceMultiplierFloat < thisSlider.GetComponent<Slider>().minValue)
        {
            thisSlider.GetComponent<Slider>().value = thisSlider.GetComponent<Slider>().minValue;
        }
        else
        {
            thisSlider.GetComponent<Slider>().value = setPriceMultiplierFloat;
        }
    }
    #endregion

}
