using UnityEngine;

public class SetVolume : MonoBehaviour
{
    public float volume;
    public float maxDistance;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        volume = Mathf.Clamp01(1 - distance/maxDistance);

        var audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = volume;
    }
}
