using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemySquarePatrolPhysics : MonoBehaviour
{
    public float speed = 25f;         
    public float squareSize = 20f;    
    private Vector2[] waypoints;     
    private int currentWaypoint = 0;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 startPos = rb.position;

      
        waypoints = new Vector2[4];
        waypoints[0] = startPos;                              
        waypoints[1] = startPos + new Vector2(squareSize, 0); 
        waypoints[2] = startPos + new Vector2(squareSize, squareSize); 
        waypoints[3] = startPos + new Vector2(0, squareSize);  
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

       
        if (Vector2.Distance(rb.position, target) < 0.05f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
}