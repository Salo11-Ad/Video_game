using UnityEngine;

public enum CollectibleType
{
    Moneda,
    Gema
}

public class Collectible : MonoBehaviour
{
    public int value = 1;
    public CollectibleType collectibleType;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(value, collectibleType);
            Destroy(gameObject);
        }
    }
}
