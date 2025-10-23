using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text ScoreText;
    public TMP_Text WarningText;

    private int score = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        ScoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        WarningText.text = "GAME OVER";
        WarningText.gameObject.SetActive(true);
    }

    public void TryWin()
    {
        int totalCollectibles = FindObjectsOfType<Collectible>().Length;

        if (totalCollectibles == 0)
        {
            WarningText.gameObject.SetActive(true);
            WarningText.text = "¡GANASTE!";
            Time.timeScale = 0f;
        }
        else
        {
            StartCoroutine(MostrarWarning("Todavía faltan objetos por recolectar.", 2f));
        }
    }

    private IEnumerator MostrarWarning(string mensaje, float duracion)
    {
        WarningText.gameObject.SetActive(true);
        WarningText.text = mensaje;
        yield return new WaitForSeconds(duracion);
        WarningText.gameObject.SetActive(false);
    }

    public void ShowWarning()
    {
        if (WarningText != null)
            WarningText.gameObject.SetActive(true);
    }

    public void WinGame()
    {
        Debug.Log("Ganaste el juego");
    }
}

