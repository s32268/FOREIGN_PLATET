using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour
{
    public int health = 3;
    public float attackRange = 2f;

    private GameObject mc;
    private Animator mcAnimator;
    private Animator bossAnimator;

    private bool alreadyHitThisAttack = false;
    private bool isDead = false;

    void Start()
    {
        mc = GameObject.Find("mc");

        if (mc != null)
            mcAnimator = mc.GetComponent<Animator>();

        bossAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead || mc == null || mcAnimator == null)
            return;

        float distance = Vector2.Distance(transform.position, mc.transform.position);

        AnimatorStateInfo state = mcAnimator.GetCurrentAnimatorStateInfo(0);

        // Player is attacking and close enough
        if (state.IsName("Attack") && distance <= attackRange)
        {
            if (!alreadyHitThisAttack)
            {
                TakeDamage(1);
                alreadyHitThisAttack = true;
            }
        }
        else
        {
            // Reset when attack animation ends
            alreadyHitThisAttack = false;
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Boss HP: " + health);

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
{
    isDead = true;

    if (bossAnimator != null)
    {
        bossAnimator.Play("Death");
    }

    // Wait 2 seconds, regardless of animation length
    yield return new WaitForSeconds(1.7f);

    Destroy(gameObject);
}
}