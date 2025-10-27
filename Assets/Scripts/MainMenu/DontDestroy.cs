using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //This script works for any object as long as there isnt two objects with the same name. why would there be lol

    void Start()
    {
        for (int i = 0; i < Object.FindObjectsByType(typeof(DontDestroy), FindObjectsSortMode.None).Length; i++)
        {
            if (Object.FindObjectsByType(typeof(DontDestroy), FindObjectsSortMode.None)[i] != this)
            {
                if (Object.FindObjectsByType(typeof(DontDestroy), FindObjectsSortMode.None)[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
