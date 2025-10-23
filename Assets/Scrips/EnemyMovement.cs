using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        if (Vector3.Distance(startPos, transform.position) >= distance)
        {
            direction *= -1;
        }
    }
}
