using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUi : MonoBehaviour
{
    public GameObject levelPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI levelText;
    public int levelNumber;

    public Button restartButton;
    public LevelManager levelManager;

    public Button menuButton;

    public TextMeshProUGUI gameOverText;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }


    private void Start()
    {
        menuButton.onClick.AddListener(MainMenuButton);
        restartButton.onClick.AddListener(RestartButton);
        UpdateLevelText();
        
    }

    private void UpdateLevelText() 
    {
        levelText.text = "Level: " + levelNumber;
    }

    private void HideLevelPanel() 
    {
        levelPanel.SetActive(false);
    }

    private void SetGameOverPanel(bool isActive) 
    {
        gameOverPanel.SetActive(isActive);
    }

    private void RestartButton()
    {
        soundManager.PlayButtonClickAudio();
        if (levelManager.isGameComplete) 
        {
            SceneManager.LoadScene(1);
            return;
        }
        levelManager.RestartLevel();
    }

    private void MainMenuButton()
    {
        soundManager.PlayButtonClickAudio();
        soundManager.DestroySoundManager();
        levelManager.LoadMainMenu();
    }

    public void ShowGameWinUI()
    {
        SetGameOverPanel(true);

        gameOverText.text = "Game Completed!!";
        gameOverText.color = Color.green;
        HideLevelPanel();
    }

    public void ShowGameLoseUI()
    {
        SetGameOverPanel(true);
        levelManager.isGameComplete = false;
        gameOverText.text = "Game Over!!";
        gameOverText.color = Color.red;
        HideLevelPanel();
    }
}
