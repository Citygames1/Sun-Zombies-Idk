using System.Collections.Generic;
using UnityEngine;

public class SettingBuildingOpacity : MonoBehaviour
{
    public List<GameObject> objectsToBeOpaque;

    public Color originalColor;
    public Color opaqueColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < objectsToBeOpaque.Count; ++i)
        {
            objectsToBeOpaque[i].GetComponent<SpriteRenderer>().color = opaqueColor;
        }
    }

    private void OnTriggerExit2D(Collider2D other )
    {
        for (int i = 0; i < objectsToBeOpaque.Count; ++i)
        {
            objectsToBeOpaque[i].GetComponent<SpriteRenderer>().color = originalColor;
        }
    }
}
