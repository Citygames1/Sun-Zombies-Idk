using UnityEngine;

public class GunSound : MonoBehaviour
{
    private Vector3 playerPos;
    [HideInInspector] public GameObject currentReloadSoundObj;

    public void PlayShot(string nameOfGun)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if(nameOfGun == "StarterPistol")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.StarterPistolShot);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "Uzi")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.UziShot);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "Sniper")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.SniperShot);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "Semi-AutoShotgun")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.AutoShotgunShoot);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "RNGgun")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.RNGgunShot);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "MiniGun")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.MinigunShot);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "Magnum")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.MagnumShot);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "M16A2")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.M16A2shot);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "AssaultRifle")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.AssaultRifleShot);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "HuntingRifle")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.HuntingRifleShot);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
    }
    
    public void PlayReload(string nameOfGun)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if(nameOfGun == "StarterPistol")
        {
            currentReloadSoundObj = AudioManager.Instance.Play(AudioManager.SoundType.StarterPistolReload);
            currentReloadSoundObj.GetComponent<Transform>().position = playerPos;
        }
        else if(nameOfGun == "Uzi")
        {
            currentReloadSoundObj = AudioManager.Instance.Play(AudioManager.SoundType.UziReload);
            currentReloadSoundObj.GetComponent<Transform>().position = playerPos;
        }
        else if(nameOfGun == "Sniper")
        {
            currentReloadSoundObj = AudioManager.Instance.Play(AudioManager.SoundType.SniperReload);
            currentReloadSoundObj.GetComponent<Transform>().position = playerPos;
        }
        else if(nameOfGun == "Semi-AutoShotgun")
        {
            currentReloadSoundObj = AudioManager.Instance.Play(AudioManager.SoundType.AssaultRifleReload);
            currentReloadSoundObj.GetComponent<Transform>().position = playerPos;
        }
        else if(nameOfGun == "RNGgun")
        {
            currentReloadSoundObj = AudioManager.Instance.Play(AudioManager.SoundType.RNGgunReload);
            currentReloadSoundObj.GetComponent<Transform>().position = playerPos;
        }
        else if(nameOfGun == "MiniGun")
        {
            currentReloadSoundObj = AudioManager.Instance.Play(AudioManager.SoundType.MinigunReload);
            currentReloadSoundObj.GetComponent<Transform>().position = playerPos;
        }
        else if(nameOfGun == "Magnum")
        {
            currentReloadSoundObj = AudioManager.Instance.Play(AudioManager.SoundType.MagnumReload);
            currentReloadSoundObj.GetComponent<Transform>().position = playerPos;
        }
        else if(nameOfGun == "M16A2")
        {
            currentReloadSoundObj = AudioManager.Instance.Play(AudioManager.SoundType.M16A2reload);
            currentReloadSoundObj.GetComponent<Transform>().position = playerPos;
        }
        else if(nameOfGun == "AssaultRifle")
        {
            currentReloadSoundObj = AudioManager.Instance.Play(AudioManager.SoundType.AssaultRifleReload);
            currentReloadSoundObj.GetComponent<Transform>().position = playerPos;
        }
        else if(nameOfGun == "HuntingRifle")
        {
            currentReloadSoundObj = AudioManager.Instance.Play(AudioManager.SoundType.HuntingRifleReload);
            currentReloadSoundObj.GetComponent<Transform>().position = playerPos;
        }
        else{
            Debug.Log("No reload sound for this gun");
        }
    }
}
