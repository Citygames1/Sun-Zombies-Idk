using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    public int startingPoints;
    public float totalPoints;

    private void Start()
    {
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        totalPoints = startingPoints;
    }
    public void GivePoints(int pointsToGain)
    {
        //multiplies the points gained by the difficulty multiplier and gives a rounded value so you dont get a float number
        float endPointsToGain = Mathf.Round(pointsToGain * difficultyManager.pointsMultiplier);

        totalPoints = totalPoints + endPointsToGain;
    }
}
