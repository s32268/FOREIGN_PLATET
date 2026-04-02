using UnityEngine;

public class CharacterRespawn : MonoBehaviour
{
    [Header("Player Respawn")]
    public Vector3 respawnPosition;  // The position where the player will respawn
    public float respawnDelay = 0f;  // Delay before respawning

    [Header("Animation")]
    public Animator animator; // Reference to the Animator component
    public string fallAnimationName = "Fall"; // The name of the fall animation

    private void Start()
    {
        // Store the initial position of the player (where they respawn)
        respawnPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with an object tagged "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Play Fall animation
            animator.SetTrigger(fallAnimationName);

            // Start the respawn process
            Invoke("Respawn", respawnDelay);
        }
    }

    // Respawn the character at the original position
    private void Respawn()
    {
        transform.position = respawnPosition;
    }
}