using UnityEngine;

public class MamaDeathOnPlayerAttack : MonoBehaviour
{
    public Animator mamaAnimator;  
    public Animator mcAnimator;    
    public float attackRange = 2f; 

    private bool isDead = false;   
    void Update()
    {
        if (isDead) return; 
        
        float distance = Vector2.Distance(mcAnimator.transform.position, transform.position);
        if (distance > attackRange) return;

      
        AnimatorStateInfo stateInfo = mcAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Attack"))
        {
          
            isDead = true;
            mamaAnimator.SetTrigger("Death");
        }
    }

    
    public void OnDeathAnimationEnd()
    {
        Destroy(gameObject);
    }
}