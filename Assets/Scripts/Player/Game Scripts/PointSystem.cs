using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    public int startingPoints;
    public float totalPoints;

    private float endPointsToGain;
    private float currentPointAdditionQueue;

    //text increase coroutine
    public float numIncreaseSpeed = 0.001f;
    private Coroutine scoreIncreaseCoroutine;
    [HideInInspector] public bool canContinueIncreasing;

    private void Start()
    {
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        totalPoints = startingPoints;
        endPointsToGain = 0;
    }
    public void GivePoints(int pointsToGain)
    {
        //multiplies the points gained by the difficulty multiplier and gives a rounded value so you dont get a float number
        endPointsToGain = Mathf.Round(pointsToGain * difficultyManager.pointsMultiplier);
        currentPointAdditionQueue += endPointsToGain;

        //starts the score increase effect
        scoreIncreaseCoroutine = StartCoroutine(ScoreIncreaseEffect());
    }

    public IEnumerator ScoreIncreaseEffect()
    {
        while(currentPointAdditionQueue > 0)
        {
            totalPoints += 1;
            currentPointAdditionQueue -= 1;
            yield return null; //this makes it so that it loops every frame, rather than waiting any seconds
        }
    }
}
