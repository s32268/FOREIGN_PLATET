using System.Collections;
using UnityEngine;

public class EnemyDeathOnHit : MonoBehaviour
{
    public float detectionRange = 1.5f;

    private Animator enemyAnimator;
    private GameObject mc;
    private bool isDead = false;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        mc = GameObject.Find("mc");
    }

    void Update()
    {
        if (isDead || mc == null)
            return;

        float distance = Vector2.Distance(transform.position, mc.transform.position);

        if (distance <= detectionRange)
        {
            Animator mcAnimator = mc.GetComponent<Animator>();

            if (mcAnimator != null &&
                mcAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                Die();
            }
        }
    }

    void Die()
    {
        isDead = true;

        if (enemyAnimator != null)
        {
            enemyAnimator.Play("Bbydeath");
        }

        StartCoroutine(DestroyAfterDelay());
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}