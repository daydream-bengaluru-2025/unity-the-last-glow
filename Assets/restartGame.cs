using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void ResetGame()
    {
        Debug.Log("Script running...");
        // Resume time in case it was paused
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
