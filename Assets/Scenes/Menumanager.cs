using UnityEngine;
using UnityEngine.SceneManagement;

public class Menumanager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("level0"); // Replace "GameScene" with your main game scene's name
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit(); // Quits the application (only works in builds, not in editor)
    }
}
