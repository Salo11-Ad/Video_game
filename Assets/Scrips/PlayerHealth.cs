using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject PanelGameOver;

    void Start()
    {
        if (PanelGameOver != null)
            PanelGameOver.SetActive(false);
        else
            Debug.LogError("PanelGameOver no asignado en el Inspector");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("BlackHole"))
        {
            if (PanelGameOver != null)
            {
                PanelGameOver.SetActive(true);
                PanelGameOver.transform.SetAsLastSibling();
            }
            Time.timeScale = 0f;
        }
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
