using System.Collections.Generic;
using UnityEngine;

public class EnablePopUpText : MonoBehaviour
{
    public List<GameObject> thingsToEnable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < thingsToEnable.Count; ++i)
            {
                thingsToEnable[i].SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < thingsToEnable.Count; ++i)
            {
                thingsToEnable[i].SetActive(false);
            }
        }
    }
}
