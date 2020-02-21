using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject titleScreen = null;
    [SerializeField] GameObject howToPlayScreen = null;
    [SerializeField] GameObject aboutScreen = null;


    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnHowTo()
    {
        titleScreen.SetActive(false);
        howToPlayScreen.SetActive(true);
    }

    public void OnAbout()
    {
        titleScreen.SetActive(false);
        aboutScreen.SetActive(true);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnMainMenu()
    {
        howToPlayScreen.SetActive(false);
        aboutScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
