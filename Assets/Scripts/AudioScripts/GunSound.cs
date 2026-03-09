using UnityEngine;

public class GunSound : MonoBehaviour
{
    public void PlayShot(string nameOfGun)
    {
        if(nameOfGun == "StarterPistol")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.StarterPistolShot);
        }
        if(nameOfGun == "Uzi")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.UziShot);
        }
        if(nameOfGun == "Sniper")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.SniperShot);
        }
        if(nameOfGun == "Semi-AutoShotgun")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.AutoShotgunShoot);
        }
        if(nameOfGun == "RNGgun")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.RNGgunShot);
        }
        if(nameOfGun == "MiniGun")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.MinigunShot);
        }
        if(nameOfGun == "Magnum")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.MagnumShot);
        }
        if(nameOfGun == "M16A2")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.M16A2shot);
        }
        if(nameOfGun == "AssaultRifle")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.AssaultRifleShot);
        }
        if(nameOfGun == "HuntingRifle")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.HuntingRifleShot);
        }
    }
    
    public void PlayReload(string nameOfGun)
    {
        if(nameOfGun == "StarterPistol")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.StarterPistolReload);
        }
        if(nameOfGun == "Uzi")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.UziReload);
        }
        if(nameOfGun == "Sniper")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.SniperReload);
        }
        if(nameOfGun == "Semi-AutoShotgun")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.AssaultRifleReload);
        }
        if(nameOfGun == "RNGgun")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.RNGgunReload);
        }
        if(nameOfGun == "MiniGun")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.MinigunReload);
        }
        if(nameOfGun == "Magnum")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.MagnumReload);
        }
        if(nameOfGun == "M16A2")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.M16A2reload);
        }
        if(nameOfGun == "AssaultRifle")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.AssaultRifleReload);
        }
        if(nameOfGun == "HuntingRifle")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.HuntingRifleReload);
        }
    }
}
