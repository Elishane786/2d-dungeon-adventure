using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed = 5f;           // Movement speed
    public float jumpForce = 5f; 
    public float jumpHeight;     // Force applied when jumping
    public LayerMask groundLayer;     // Define what is considered ground
    private Rigidbody2D rb;           // Reference to the Rigidbody2D
    private bool isGrounded = false;  // Check if the player is on the ground
    private Collider2D playerCollider; // Player's collider

    public Animator animator;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private bool isFacingRight = true;

    public Transform respawnPoint;
    private bool isDead = false;

    void Start()
    {
        // Get the Rigidbody2D and Collider2D components
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        GameObject respawnObj = GameObject.FindWithTag("Respawn");
        if (respawnObj != null)
        {
            respawnPoint = respawnObj.transform;
        }
    }

    void Update()
    {
        // Horizontal movement
        float moveX = Input.GetAxis("Horizontal");
        if (!IsTouchingWall())
        {
            rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        }
        
        animator.SetBool("isRunning", moveX != 0);
        
        

        // flip to turn
           if (moveX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && isFacingRight)
        {
            Flip();
        }

        if (IsTouchingWall() && !isGrounded)
        {
            animator.SetTrigger("hang");
        }

         //Jumping logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // // Fall-through platform logic
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     StartCoroutine(FallThroughPlatform());
        // }

        

        // running anime 
        if (moveX != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        animator.SetBool("isFloored",isGrounded);
        animator.SetFloat("VerticalVelocity", rb.velocity.y);

        
    }

    private void FixedUpdate()
    {
        // Check if the player is grounded using Physics2D.OverlapCircle
        // isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
       isGrounded = rb.IsTouchingLayers(groundLayer);
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player touches a deadly object
        if (collision.gameObject.layer == LayerMask.NameToLayer("Deadly"))
        {
            Die();
        }
    }


    void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetTrigger("Die"); // Play death animation
        rb.velocity = Vector2.zero; // Stop movement
        rb.bodyType = RigidbodyType2D.Static; // Freeze player

        StartCoroutine(FadeAndRespawn());
    }

    IEnumerator FadeAndRespawn()
    {
        FindObjectOfType<FadeEffect>().StartFadeOut();
        yield return new WaitForSeconds(1.5f); // Wait for fade-out to complete

        Respawn();

        FindObjectOfType<FadeEffect>().StartFadeIn();
    }

    void Respawn()
    {
        isDead = false;
        transform.position = respawnPoint.position; // Move player to respawn position
        rb.bodyType = RigidbodyType2D.Dynamic; // Re-enable physics
        
    }

    

    // private IEnumerator FallThroughPlatform()
    // {
    //     // Temporarily disable player's collider to fall through platforms
    //     playerCollider.enabled = false;
    //     yield return new WaitForSeconds(0.5f); // Wait half a second
    //     playerCollider.enabled = true;
    // }

    private void Flip(){
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    bool IsTouchingWall()
    {
        Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.5f, groundLayer);

        return hit.collider != null;
    }

    
}
