using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void LoadScene(string sceneName) // Load a scene by name
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene() // Reload the current scene
    {
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
    }

    public void LoadNextScene() // Load the next scene in the build order
    {
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
    public void LoadPreviousScene() // Load the previous scene in the build order
    {
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        int previousSceneIndex = currentScene.buildIndex - 1;
        if (previousSceneIndex >= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogWarning("No previous scene in the build order.");
        }
    }
    public void QuitGame() // Quit the game
    {
        Application.Quit();
    }
}