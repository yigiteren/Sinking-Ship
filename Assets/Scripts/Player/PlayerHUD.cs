using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHUD : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI waterLevel = null;
    [SerializeField] TextMeshProUGUI score = null;
    [SerializeField] TextMeshProUGUI holeAmount = null;

    GameManager gameManager = null;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {

        waterLevel.SetText("Water Level: " + string.Format("{0:0.00}", gameManager.GetWaterPercentage()) + "%");
        score.SetText("Score: " + gameManager.GetScore());
        holeAmount.SetText("Amount of holes: " + gameManager.GetAmountOfHoles());
        
    }
}
