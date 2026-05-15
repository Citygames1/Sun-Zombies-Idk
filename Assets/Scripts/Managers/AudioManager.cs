using UnityEngine;
using System.Collections.Generic;
 
public class AudioManager : MonoBehaviour
{
    //How to reference: AudioManager.Instance.Play(AudioManager.SoundType.whateverType);

    public enum SoundType
    {
        //player
        Roll, Walk,

        //guns
        StarterPistolShot, StarterPistolReload, SniperShot, SniperReload,
        HuntingRifleShot, HuntingRifleReload, AutoShotgunShoot, AutoShotgunReload,
        M16A2shot, M16A2reload, AssaultRifleShot, AssaultRifleReload, UziShot, UziReload,
        MagnumShot, MagnumReload, MinigunShot, MinigunReload, RNGgunShot, RNGgunReload,

        //doors
        StartRoomOpen, GardenOpen, KitchenOpen, ReceptionOpen, SecurityRoomOpen,
        FoodHallOpen, MainHallOpen, BreakfastHallOpen, SecretOpen,

        //enemy
        DefaultWalk, FastWalk, FastDash, TankWalk, BruteWalk,
        DefaultGroan1, DefaultGroan2, FastGroan1, FastGroan2, TankGroan1, TankGroan2, BruteGroan1, BruteGroan2,
        Hurt1, Hurt2, Hurt3, Hurt4,
        
        //music
        Music_Menu, 
        Music_Battle
    }
 
    [System.Serializable]
    public class Sound
    {
        public SoundType Type;
        public AudioClip Clip;
        [Range(0f, 1f)] public float Volume = 1f;
        [HideInInspector] public AudioSource Source;
    }
 
    public static AudioManager Instance;
 
    public Sound[] AllSounds;
 
    private Dictionary<SoundType, Sound> _soundDictionary = new Dictionary<SoundType, Sound>();
    private AudioSource _musicSource;
 
    private void Awake()
    {
        Instance = this;
 
        foreach(var s in AllSounds)
        {
            _soundDictionary[s.Type] = s;
        }
    }
 
 
 
    //Call this method to play a sound
    public void Play(SoundType type)
    {
        if (!_soundDictionary.TryGetValue(type, out Sound s))
        {
            Debug.LogWarning($"Sound type {type} not found!");
            return;
        }
 
        var soundObj = new GameObject($"Sound_{type}");
        var audioSrc = soundObj.AddComponent<AudioSource>();
 
        audioSrc.clip = s.Clip;
        audioSrc.volume = s.Volume;
        audioSrc.Play();
        Destroy(soundObj, s.Clip.length);
    }
 
    //Call this method to change music tracks
    public void ChangeMusic(SoundType type)
    {
        if (!_soundDictionary.TryGetValue(type, out Sound track))
        {
            Debug.LogWarning($"Music track {type} not found!");
            return;
        }
 
        if (_musicSource == null)
        {
            var container = new GameObject("SoundTrackObj");
            _musicSource = container.AddComponent<AudioSource>();
            _musicSource.loop = true;
        }
 
        _musicSource.clip = track.Clip;
        _musicSource.Play();
    }
}
