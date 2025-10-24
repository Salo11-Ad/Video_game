using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text ScoreText;
    public TMP_Text MonedasText;
    public TMP_Text GemasText;

    public GameObject WarningPanel;
    public GameObject GameOverPanel;
    public GameObject VictoryPanel;

    private int score = 0;
    private int totalMonedas;
    private int totalGemas;
    private int collectedMonedas = 0;
    private int collectedGemas = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Collectible[] collectibles = FindObjectsOfType<Collectible>();
        foreach (var c in collectibles)
        {
            if (c.collectibleType == CollectibleType.Moneda)
                totalMonedas++;
            else if (c.collectibleType == CollectibleType.Gema)
                totalGemas++;
        }

        UpdateScoreText();
        UpdateCounters();

        Time.timeScale = 1f;

        if (WarningPanel != null) WarningPanel.SetActive(false);
        if (GameOverPanel != null) GameOverPanel.SetActive(false);
        if (VictoryPanel != null) VictoryPanel.SetActive(false);
    }

    public void AddScore(int amount, CollectibleType type)
    {
        score += amount;

        if (type == CollectibleType.Moneda)
            collectedMonedas++;
        else if (type == CollectibleType.Gema)
            collectedGemas++;

        UpdateScoreText();
        UpdateCounters();
    }

    void UpdateScoreText()
    {
        if (ScoreText != null)
            ScoreText.text = "Score: " + score;
    }

    void UpdateCounters()
    {
        if (MonedasText != null)
            MonedasText.text = "Monedas: " + collectedMonedas + "/" + totalMonedas;
        if (GemasText != null)
            GemasText.text = "Gemas: " + collectedGemas + "/" + totalGemas;
    }

    public void GameOver()
    {
        if (GameOverPanel != null)
            GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TryWin()
    {
        int leftMonedas = totalMonedas - collectedMonedas;
        int leftGemas = totalGemas - collectedGemas;

        int left = leftMonedas + leftGemas;

        if (left == 0)
        {
            if (VictoryPanel != null)
            {
                VictoryPanel.SetActive(true);
                VictoryPanel.transform.SetAsLastSibling();
            }
            Time.timeScale = 0f;
        }
        else
        {
            StartCoroutine(MostrarWarningPanel("Faltan objetos por recolectar (" + left + ")", 2f));
        }
    }

    private IEnumerator MostrarWarningPanel(string mensaje, float duracion)
    {
        if (WarningPanel != null)
        {
            WarningPanel.SetActive(true);

            TMP_Text text = WarningPanel.GetComponentInChildren<TMP_Text>();
            if (text != null)
                text.text = mensaje;

            yield return new WaitForSeconds(duracion);
            WarningPanel.SetActive(false);
        }
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
