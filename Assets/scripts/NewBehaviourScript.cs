using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemySquarePatrolPhysics : MonoBehaviour
{
    public float speed = 25f;          // Movement speed
    public float squareSize = 20f;     // Length of each side of the square

    private Vector2[] waypoints;      // 4 points of the square
    private int currentWaypoint = 0;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 startPos = rb.position;

        // Define square points clockwise
        waypoints = new Vector2[4];
        waypoints[0] = startPos;                               // Bottom-left
        waypoints[1] = startPos + new Vector2(squareSize, 0);  // Bottom-right
        waypoints[2] = startPos + new Vector2(squareSize, squareSize); // Top-right
        waypoints[3] = startPos + new Vector2(0, squareSize);  // Top-left
    }

    private void FixedUpdate()
    {
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        Vector2 target = waypoints[currentWaypoint];
        Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

        rb.MovePosition(newPosition);

        // Check if we reached the waypoint
        if (Vector2.Distance(rb.position, target) < 0.05f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
}