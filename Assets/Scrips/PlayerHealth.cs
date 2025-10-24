using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("BlackHole"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
