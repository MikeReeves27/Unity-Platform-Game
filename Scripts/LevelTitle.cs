using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTitle : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI levelText;

    // Display level number and title. Load level scene after short delay
    void Start()
    {
        levelText.text = "Level " + StartLevel.level + "\n\n" + LevelData.levelName[ StartLevel.level];
        Invoke("LoadLevel", 2.0f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene("Level" + StartLevel.level.ToString());
    }

}
