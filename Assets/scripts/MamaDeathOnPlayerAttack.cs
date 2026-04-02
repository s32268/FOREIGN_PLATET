using UnityEngine;

public class MamaDeathOnPlayerAttack : MonoBehaviour
{
    public Animator mamaAnimator;   // Mama's Animator
    public Animator mcAnimator;     // mc's Animator
    public float attackRange = 2f;  // distance at which mc can hit Mama

    private bool isDead = false;    // ensures death happens only once

    void Update()
    {
        if (isDead) return; // already dead

        // Check distance between mc and Mama
        float distance = Vector2.Distance(mcAnimator.transform.position, transform.position);
        if (distance > attackRange) return;

        // Check if mc is currently in Attack animation
        AnimatorStateInfo stateInfo = mcAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Attack"))
        {
            // Trigger Mama's Death animation
            isDead = true;
            mamaAnimator.SetTrigger("Death");
        }
    }

    // Call this from an Animation Event at the last frame of Mama's Death animation
    public void OnDeathAnimationEnd()
    {
        Destroy(gameObject);
    }
}