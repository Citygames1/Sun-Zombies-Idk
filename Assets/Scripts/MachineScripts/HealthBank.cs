using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBank : MonoBehaviour
{
    private GameObject player;
    public bool inRangeOfMachine;
    public int costOfMachine;
    private PlayerHealth playerHS;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHS = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (inRangeOfMachine && Input.GetKeyDown(KeyCode.E))
        {
            if (player.GetComponent<PointSystem>().totalPoints >= costOfMachine && playerHS.currentHealth < playerHS.maxHealth)
            {
                playerHS.currentHealth = playerHS.maxHealth;
                player.GetComponent<PointSystem>().totalPoints -= costOfMachine;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRangeOfMachine = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRangeOfMachine = false;
        }
    }
}
