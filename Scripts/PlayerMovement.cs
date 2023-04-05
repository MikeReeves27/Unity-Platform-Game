using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    public static float playerXPosition = -4.5f;
    public static float playerYPosition = 1.5f;

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        // When scene is created, set player position according to Overworld level data
        if (SceneManager.GetActiveScene().name.Equals("Overworld"))
        {
            sprite.transform.position = new Vector3(playerXPosition, playerYPosition, 0);
        }

    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        
        // If player is not static (dead)
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            // Set player movement velocity
            rb.velocity = new Vector2(dirX * 12f, rb.velocity.y);

            // If JUMP is pressed and player is on stable ground, set jump velocity
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, 16f);
            }

            // If player moving right, set animation to run
            if (dirX > 0f)
            {
                anim.SetBool("running", true);
                sprite.flipX = false;
            }

            // If player moving left, set animation to run and flip sprite
            else if (dirX < 0f)
            {
                sprite.flipX = true;
                anim.SetBool("running", true);
            }

            // If player not moving, set animation to idle
            else
            {
                anim.SetBool("running", false);
            } 
        }

        // If player goes below lowest screen bounds, player has fallen off screen and is dead
        if (sprite.transform.position.y <= -10)
        {
            FallOffScreen();
        }
        
    }

    // Check if player is on stable ground (used for determining if player can jump)
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    // If player has fallen off screen, reload Overworld
    private void FallOffScreen()
    {
        PlayerMovement.playerXPosition = LevelData.overWorldStartingPoints[StartLevel.level][0];
        PlayerMovement.playerYPosition = LevelData.overWorldStartingPoints[StartLevel.level][1];
        SceneManager.LoadScene("Overworld");
    }
}
