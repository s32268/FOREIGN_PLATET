using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float speed = 2f;
    public float leftLimit = -4f;
    public float rightLimit = 4f;

    private bool movingRight = true;

    void Update()
    {
        if (transform.position.x <= leftLimit)
            movingRight = true;
        else if (transform.position.x >= rightLimit)
            movingRight = false;

        float direction = movingRight ? 1f : -1f;
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
        collision.transform.SetParent(transform);
}

void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
        collision.transform.SetParent(null);
}
}