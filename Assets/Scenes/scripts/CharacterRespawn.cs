using UnityEngine;

public class CharacterRespawn : MonoBehaviour
{
    [Header("Player Respawn")]
    public Transform respawnPosition;  //Transform
    public float respawnDelay = 0f;  
    public int maxHealth = 3;
    public int currentHealth;

    [Header("Animation")]
    public Animator animator; 
    public string fallAnimationName = "Fall"; 
// on health increase decrease
private void Start()
{
    currentHealth = maxHealth;
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
           
            currentHealth -= 1;
            Debug.Log(currentHealth);
           
        }

        if (currentHealth <= 0)
        {
            animator.SetTrigger(fallAnimationName);
            Invoke("Respawn", respawnDelay);
            currentHealth = maxHealth;

        }
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;
        
    if (currentHealth <= 0)
        {
            animator.SetTrigger(fallAnimationName);
            Invoke("Respawn", respawnDelay);
            currentHealth = maxHealth;
        }

    }
 
    private void Respawn()
    {
        transform.position = respawnPosition.position;
    }
}