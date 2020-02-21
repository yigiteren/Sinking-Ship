using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Info", menuName = "Create Player Info")]
public class PlayerInfo : ScriptableObject
{
    public int score = 0;
    public int highScore = 0;
    public float sensitivity = 100f;

    public void UpdateHighScore()
    {
        if(score > highScore)
            highScore = score;
    }
}
