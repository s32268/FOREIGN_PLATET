using UnityEngine;

public class PlayerControllerUpdate : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float runSpeed = 7f;
    public float jumpForce = 400f;

    private bool isSprint = false;
    private bool isJump = false;
    private float moveVector = 0f; // ✅ class-level, ok to use 'private'

    [Header("Components")]
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public GroundChecker groundChecker;
    public Animator anim;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (anim == null) anim = GetComponent<Animator>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Correct: no 'private' here
        moveVector = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {
            isJump = true;
            anim.SetBool("Jump", true);
        }

        if (Input.GetKeyDown(KeyCode.Q) && groundChecker.isGrounded)
        {
            anim.SetTrigger("Attack");
        }

        anim.SetBool("Run", moveVector != 0);

        if (moveVector > 0) spriteRenderer.flipX = false;
        else if (moveVector < 0) spriteRenderer.flipX = true;

        if (!groundChecker.isGrounded)
        {
            if (rb.velocity.y > 0)
            {
                anim.SetBool("Jump", true);
                anim.SetBool("JumpDown", false);
                anim.SetBool("Land", false);
            }
            else if (rb.velocity.y < 0)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("JumpDown", true);
                anim.SetBool("Land", false);
            }
        }
        else
        {
            anim.SetBool("Jump", false);
            anim.SetBool("JumpDown", false);
            anim.SetBool("Land", true);
        }
    }

   private void FixedUpdate()
{
    float speed = isSprint ? runSpeed : moveSpeed;

    rb.velocity = new Vector2(moveVector * speed, rb.velocity.y);

    if (isJump)
    {
        rb.AddForce(Vector2.up * jumpForce);
        isJump = false;
    }
}
}