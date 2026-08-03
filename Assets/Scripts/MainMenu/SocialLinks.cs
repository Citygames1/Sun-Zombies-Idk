using UnityEngine;

public class SocialLinks : MonoBehaviour
{
    public void OpenYouTube(){
        Application.OpenURL("https://www.youtube.com/@CityGameDev");
    }
    
    public void JoinDiscord()
    {
        Application.OpenURL("https://discord.gg/fvGyhEpTxV");
    }
    
    public void OpenTikTok()
    {
        Application.OpenURL("https://www.tiktok.com/@citygames0725");
    }
}
