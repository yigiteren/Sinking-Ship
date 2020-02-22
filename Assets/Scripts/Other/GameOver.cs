using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] PlayerInfo playerInfo = null;
    [SerializeField] TextMeshProUGUI score = null;
    [SerializeField] TextMeshProUGUI highScore = null;
    void Start()
    {
        score.SetText(playerInfo.score.ToString());
        highScore.SetText(playerInfo.highScore.ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
