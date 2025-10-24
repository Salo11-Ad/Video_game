using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Buttons : MonoBehaviour
{

    public GameObject CreditsPanel;
    public GameObject PausePanel;
    public GameObject SettingsPanel;
    public GameObject InstructionsPanel;
    public GameObject GameOverPanel;


    public bool isPaused = false;

    public void PlayGame() 
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CreditsOn()
    {
        CreditsPanel.SetActive(true);
    }

    public void CreditsOff()
    {
        CreditsPanel.SetActive(false);
    }

    public void PauseOn()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void PauseOff()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SettingsOn()
    {
        SettingsPanel.SetActive(true);
        PausePanel.SetActive(false);

    }

    public void SettingsOff()
    {
        SettingsPanel.SetActive(false);
    }

    public void InstructionsOff()
    {
        InstructionsPanel.SetActive(false);
    }

    public void GameOverOn()
    {
        GameOverPanel.SetActive(true);
    }

    public void GoHomeScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}