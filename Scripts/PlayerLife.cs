using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // If player touches enemy, player dies
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;

        // Flip player sprite if need be (used so RIP tombstone is not backward)
        if (sprite.flipX == true)
        {
            sprite.flipX = false;
        }
        
        anim.SetTrigger("death");
    }

    // Load Overworld
    private void RestartLevel()
    {
        PlayerMovement.playerXPosition = LevelData.overWorldStartingPoints[StartLevel.level][0];
        PlayerMovement.playerYPosition = LevelData.overWorldStartingPoints[StartLevel.level][1];
        SceneManager.LoadScene("Overworld");
    }
}
