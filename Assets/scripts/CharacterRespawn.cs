using UnityEngine;

public class CharacterRespawn : MonoBehaviour
{
    [Header("Player Respawn")]
    public Vector3 respawnPosition;  
    public float respawnDelay = 0f;  

    [Header("Animation")]
    public Animator animator; 
    public string fallAnimationName = "Fall"; 

    private void Start()
    {
        
        respawnPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            animator.SetTrigger(fallAnimationName);

           
            Invoke("Respawn", respawnDelay);
        }
    }

 
    private void Respawn()
    {
        transform.position = respawnPosition;
    }
}