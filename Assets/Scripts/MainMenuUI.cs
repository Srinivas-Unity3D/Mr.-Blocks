using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    private const int firstLevel = 1;

    private SoundManager soundManager;


    private void Awake()
    {
        AddListeners();

        soundManager = FindObjectOfType<SoundManager>();
    }

    private void AddListeners()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    public void Play()
    {
        soundManager.PlayButtonClickAudio();
        SceneManager.LoadScene(firstLevel);  
    }

    public void Quit()
    {
        soundManager.PlayButtonClickAudio();
        Application.Quit();  
    }
}
