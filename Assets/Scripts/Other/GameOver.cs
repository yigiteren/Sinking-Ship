using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score = null;
    [SerializeField] TextMeshProUGUI highScore = null;
    void Start()
    {
        score.SetText(PlayerPrefs.GetInt("score", 0).ToString());
        highScore.SetText(PlayerPrefs.GetInt("highscore", 0).ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
