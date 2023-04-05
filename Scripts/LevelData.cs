using UnityEngine;

public class LevelData : ScriptableObject
{
    // Set Overworld starting positions (used for when player returns to
    // Overworld. Player will be placed at correct portal)
    public static float[][] overWorldStartingPoints = new float[][]
    {
        new float[] {-3.5f, 1.5f}, // Overworld
        new float[] {1.5f, 0.5f}, // Level 1
        new float[] {6.5f, 0.5f}, // Level 2
    };

    // Set screen bounds for each level: left, right, bottom, top
    public static float[][] screenBounds = new float[][]
    {
        new float[] {-3.3f, 75.5f, 1, 25}, // Overworld
        new float[] {-3.3f, 35.3f, 1, 25}, // Level 1
        new float[] {-3.3f, 75.5f, 1, 29} // Level 2
    };

    // Set level names
    public static string[] levelName = new string[]
    {
        "Overworld", "The Grassy-verse", "The Beachy-verse"
    };

}