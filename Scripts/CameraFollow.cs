using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform target;
    public Vector3 offset;
    [Range(1, 30)]
    public float smoothFactor;
    private int level;
    private float screenLeft;
    private float screenRight;
    private float screenTop;
    private float screenBottom;

    // Get screen bounds from level data
    private void Start()
    {
        level = StartLevel.level;
        screenLeft = LevelData.screenBounds[StartLevel.level][0];
        screenRight = LevelData.screenBounds[StartLevel.level][1];
        screenBottom = LevelData.screenBounds[StartLevel.level][2];
        screenTop = LevelData.screenBounds[StartLevel.level][3];
    }

    private void LateUpdate()
    {
        Follow();
    }

    // If player reaches screen bound, camera is no longer a child object of player.
    // Camera will now float accordingly and with a screen bound clamp
    void Follow()
    {
        if (target.position.x <= screenLeft || target.position.x >= screenRight || target.position.y <= screenBottom || target.position.y >= screenTop)
        {
            transform.SetParent(null);
            Vector3 boundPosition = new Vector3(
                Mathf.Clamp(target.position.x, (float) screenLeft, (float) screenRight),
                Mathf.Clamp(target.position.y, screenBottom, screenTop),
                Mathf.Clamp(target.position.z, -10, -10));
            transform.position = boundPosition;
        
        // If player leaves screen bound range, player becomes parent to camera object again
        } else
        {
            transform.SetParent(target);
        }
        
    }
}
