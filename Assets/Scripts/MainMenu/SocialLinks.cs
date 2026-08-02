using UnityEngine;

public class SocialLinks : MonoBehaviour
{
    void OpenYouTube(){
        Application.OpenURL("https://www.youtube.com/@CityGameDev");
    }
    
    void JoinDiscord()
    {
        Application.OpenURL("https://discord.gg/fvGyhEpTxV");
    }
    
    void OpenTikTok()
    {
        Application.OpenURL("https://www.tiktok.com/@citygames0725");
    }
}
