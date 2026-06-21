using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;

    public float attackRange = 2f;

    private GameObject mc;
    private Animator mcAnimator;
    private Animator bossAnimator;

    private bool alreadyHitThisAttack = false;
    private bool isDead = false;

    void Start()
    {
        health = maxHealth;

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

        yield return new WaitForSeconds(1.7f);

        Destroy(gameObject);
    }
}