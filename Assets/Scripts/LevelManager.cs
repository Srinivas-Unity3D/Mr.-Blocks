using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private const int mainMenuIndex = 0;
    internal int currentSceneIndex;

    public LevelUi levelUI;

    public bool isGameComplete;

    private void Start() => currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    internal void OnLevelComplete() => LoadNextLevel();
    internal void OnPlayerDeath() => levelUI.ShowGameLoseUI();
    internal void RestartLevel() => SceneManager.LoadScene(currentSceneIndex);
    internal void LoadMainMenu() => SceneManager.LoadScene(mainMenuIndex);

    private void LoadNextLevel() 
    {
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex < totalNumberOfScenes)
        {
            isGameComplete = false;
            SceneManager.LoadScene(nextSceneIndex);
        }
        else 
        {
            isGameComplete = true;
            levelUI.ShowGameWinUI();
        }
    }
}
