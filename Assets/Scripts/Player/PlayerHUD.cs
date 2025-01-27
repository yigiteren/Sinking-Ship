﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHUD : MonoBehaviour
{
    //In Game HUD Elements
    [SerializeField] TextMeshProUGUI waterLevel = null;
    [SerializeField] TextMeshProUGUI score = null;
    [SerializeField] TextMeshProUGUI holeAmount = null;

    //Pause Menu Elements
    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] TextMeshProUGUI sensitivity = null;
    [SerializeField] TextMeshProUGUI sound = null;

    [SerializeField] Slider sensitivitySlider;
    [SerializeField] Slider soundSlider;

    [SerializeField] KeyCode pauseKey = KeyCode.Escape;

    GameManager gameManager = null;
    CameraController cameraController = null;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        cameraController = GameObject.Find("Camera").GetComponent<CameraController>();

        cameraController.lookSensitivity = PlayerPrefs.GetFloat("sensitivity", 3);
        sensitivity.SetText(cameraController.lookSensitivity.ToString());
        sensitivitySlider.value = cameraController.lookSensitivity;


        AudioListener.volume = PlayerPrefs.GetFloat("volume", 100) / 100f;
        sound.SetText(PlayerPrefs.GetFloat("volume", 100).ToString());
        soundSlider.value = PlayerPrefs.GetFloat("volume", 100);

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
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                UnityEngine.Cursor.lockState = CursorLockMode.Confined;
                UnityEngine.Cursor.visible = true;
                cameraController.lookSensitivity = 0f;
                AudioListener.volume = 0f;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                UnityEngine.Cursor.visible = false;
                cameraController.lookSensitivity = PlayerPrefs.GetFloat("sensitivity", 3);
                AudioListener.volume = PlayerPrefs.GetFloat("volume", 100) / 100f;
            }
        }
        
    }

    public void ChangeSensitivity(float value)
    {
        PlayerPrefs.SetFloat("sensitivity", value);
        PlayerPrefs.Save();
        sensitivity.SetText(value.ToString());
    }

    public void ChangeSound(float value)
    {
        PlayerPrefs.SetFloat("volume", value);
        PlayerPrefs.Save();
        sound.SetText(value.ToString());
    }
}
