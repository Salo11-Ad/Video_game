using UnityEngine;

public class CollectibleBook : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.TryWin();
        }
    }
}
