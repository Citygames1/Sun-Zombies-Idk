using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public void PlayOpen(string nameOfDoor, Vector3 objectPos)
    {
        if(nameOfDoor == "StartRoom")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.StartRoomOpen);
            soundObj.GetComponent<Transform>().position = objectPos;
        }
        if(nameOfDoor == "Garden")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.GardenOpen);
            soundObj.GetComponent<Transform>().position = objectPos;
        }
        if(nameOfDoor == "SecurityRoom")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.SecurityRoomOpen);
            soundObj.GetComponent<Transform>().position = objectPos;
        }
        if(nameOfDoor == "Kitchen")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.KitchenOpen);
            soundObj.GetComponent<Transform>().position = objectPos;
        }
        if(nameOfDoor == "BreakfastHall")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.BreakfastHallOpen);
            soundObj.GetComponent<Transform>().position = objectPos;
        }
        if(nameOfDoor == "FoodHall")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.FoodHallOpen);
            soundObj.GetComponent<Transform>().position = objectPos;
        }
        if(nameOfDoor == "Reception")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.ReceptionOpen);
            soundObj.GetComponent<Transform>().position = objectPos;
        }
        if(nameOfDoor == "MainHall")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.MainHallOpen);
            soundObj.GetComponent<Transform>().position = objectPos;
        }
        if(nameOfDoor == "Secret")
        {
            GameObject soundObj = AudioManager.Instance.Play(AudioManager.SoundType.SecretOpen);
            soundObj.GetComponent<Transform>().position = objectPos;
        }
    }
}