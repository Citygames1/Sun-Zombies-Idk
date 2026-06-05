using UnityEngine;

public class GunSound : MonoBehaviour
{
    private Vector3 playerPos;

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
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.StarterPistolReload);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "Uzi")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.UziReload);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "Sniper")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.SniperReload);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "Semi-AutoShotgun")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.AssaultRifleReload);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "RNGgun")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.RNGgunReload);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "MiniGun")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.MinigunReload);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "Magnum")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.MagnumReload);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "M16A2")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.M16A2reload);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "AssaultRifle")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.AssaultRifleReload);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
        if(nameOfGun == "HuntingRifle")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.HuntingRifleReload);
            soundObj.GetComponent<Transform>().position = playerPos;
        }
    }
}
