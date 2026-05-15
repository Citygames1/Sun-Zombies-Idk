using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public void PlayOpen(string nameOfDoor)
    {
        if(nameOfDoor == "StartRoom")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.StartRoomOpen);
        }
        if(nameOfDoor == "Garden")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.GardenOpen);
        }
        if(nameOfDoor == "SecurityRoom")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.SecurityRoomOpen);
        }
        if(nameOfDoor == "Kitchen")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.KitchenOpen);
        }
        if(nameOfDoor == "BreakfastHall")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.BreakfastHallOpen);
        }
        if(nameOfDoor == "FoodHall")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.FoodHallOpen);
        }
        if(nameOfDoor == "Reception")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.ReceptionOpen);
        }
        if(nameOfDoor == "MainHall")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.MainHallOpen);
        }
        if(nameOfDoor == "Secret")
        {
            AudioManager.Instance.Play(AudioManager.SoundType.SecretOpen);
        }
    }
}