using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScreen : MonoBehaviour
{
    private Scene activeScene;

    public void Start()
    {
        activeScene = SceneManager.GetActiveScene();
    }

    public void MainMenuWarp()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(activeScene.name);
    }
}
