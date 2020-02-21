using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    //In Game HUD Elements
    [SerializeField] TextMeshProUGUI waterLevel = null;
    [SerializeField] TextMeshProUGUI score = null;
    [SerializeField] TextMeshProUGUI holeAmount = null;

    //Pause Menu Elements
    [SerializeField] GameObject pauseMenu = null;

    [SerializeField] KeyCode pauseKey = KeyCode.Escape;

    GameManager gameManager = null;
    CameraController cameraController = null;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        cameraController = GameObject.Find("Camera").GetComponent<CameraController>();
    }

    void Update()
    {
        //In game HUD
        waterLevel.SetText("Water Level: " + string.Format("{0:0.00}", gameManager.GetWaterPercentage()) + "%");
        score.SetText("Score: " + gameManager.GetScore());
        holeAmount.SetText("Amount of holes: " + gameManager.GetAmountOfHoles());
        //Pause Menu

        if(Input.GetKeyDown(pauseKey))
        {   
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                UnityEngine.Cursor.lockState = CursorLockMode.Confined;
                cameraController.lookSensitivity = 0f;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                cameraController.lookSensitivity = gameManager.GetPlayerInfo().sensitivity;
            }
        }
        
    }

    public void ChangeSensitivity(float value)
    {
        gameManager.GetPlayerInfo().sensitivity = value;
    }
}
