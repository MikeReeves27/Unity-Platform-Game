using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{

    public int level;

    // Once player touches portal in level, reload Overworld
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerMovement.playerXPosition = LevelData.overWorldStartingPoints[StartLevel.level][0];
            PlayerMovement.playerYPosition = LevelData.overWorldStartingPoints[StartLevel.level][1];
            SceneManager.LoadScene("Overworld");
        }
        
    }
}
