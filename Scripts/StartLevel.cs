using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{

    public int levelNumber;
    public static int level;

    // In Overworld screen, when player touches level porta, load the black
    // title screen with level title
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            level = levelNumber;
            SceneManager.LoadScene("LevelTitle");
        }
        
    }

}
