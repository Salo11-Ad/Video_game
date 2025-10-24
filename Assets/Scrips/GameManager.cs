using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text ScoreText;
    public TMP_Text WarningText;

    public GameObject GameOverPanel;

    private int score = 0;
    private int totalCollectibles;
    private int collected = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        totalCollectibles = FindObjectsOfType<Collectible>().Length;
        UpdateScoreText();
        Time.timeScale = 1f;
    }

    public void AddScore(int amount)
    {
        score += amount;
        collected++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (ScoreText != null)
            ScoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        if (GameOverPanel != null)
            GameOverPanel.SetActive(true);

        Debug.Log("GAME OVER");
    }

    public void TryWin()
    {
        int left = totalCollectibles - collected;

        if (left == 0)
        {
            WarningText.text = "¡GANASTE!";
            WarningText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            StartCoroutine(MostrarWarning("Faltan objetos por recolectar (" + left + ")", 2f));
        }
    }

    private IEnumerator MostrarWarning(string mensaje, float duracion)
    {
        WarningText.gameObject.SetActive(true);
        WarningText.text = mensaje;
        yield return new WaitForSeconds(duracion);
        WarningText.gameObject.SetActive(false);
    }
}

