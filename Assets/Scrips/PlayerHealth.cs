using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("BlackHole"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
