using UnityEngine;
using TMPro;

public class TicketMachine : MonoBehaviour
{
    private GameObject currentDetails;
    private TrainManager trainManager;
    private GameManager gameManager;
    private bool inRange;

    private void Awake() {
        currentDetails = GameObject.FindGameObjectWithTag("CurrentDetails");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        trainManager = GameObject.FindGameObjectWithTag("TrainManager").GetComponent<TrainManager>();
    }
    
    private void Update() {
        if(gameManager.roundCount < trainManager.trainArrivalRound && inRange == true)
        {
            currentDetails.GetComponent<TMP_Text>().text = "The train will be arriving shortly!";
        }
        else if(gameManager.roundCount >= trainManager.trainArrivalRound && inRange == true)
        {
            currentDetails.GetComponent<TMP_Text>().text = "The train is waiting!";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentDetails.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentDetails.SetActive(false);
            inRange = false;
        }
    }
}
