using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;   
    public float speed = 2f;          

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * moveDistance;
        transform.position = new Vector3(startPos.x, startPos.y + yOffset, startPos.z);
    }

    void OnCollisionEnter2D(Collision2D col)
{
    col.transform.SetParent(transform);
}

void OnCollisionExit2D(Collision2D col)
{
    col.transform.SetParent(null);
}
}
