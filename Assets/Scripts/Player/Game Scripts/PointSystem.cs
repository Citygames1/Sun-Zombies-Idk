using System.Collections;
using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    private DifficultyManager difficultyManager;
    public float totalPoints;

    private float endPointsToGain;
    private float currentPointAdditionQueue;
    public Transform pointsTextObjectSpawnLocation;
    public GameObject pointsTextObject;

    private Coroutine scoreIncreaseCoroutine;

    private void Start()
    {
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        totalPoints = difficultyManager.startingPoints;
        endPointsToGain = 0;
    }
    public void GivePoints(int pointsToGain)
    {
        //multiplies the points gained by the difficulty multiplier and gives a rounded value so you dont get a float number
        endPointsToGain = Mathf.Round(pointsToGain * difficultyManager.pointsMultiplier);
        currentPointAdditionQueue += endPointsToGain;

        //starts the score increase effect
        scoreIncreaseCoroutine = StartCoroutine(ScoreIncreaseEffect());

        GameObject spawnedPointsTextObject = Instantiate(pointsTextObject, pointsTextObjectSpawnLocation);
        spawnedPointsTextObject.GetComponent<TMP_Text>().text = "+" + endPointsToGain; //sets the text of the instantiated points object
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
