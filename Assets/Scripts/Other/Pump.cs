using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] private float pumpPower = 2f;
    [SerializeField] private float pumpDrawHeight = 0f;
    private float decrease;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        decrease = gameManager.GetHoleFillAmount() * pumpPower;
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.DecreaseWaterLevel(decrease * Time.deltaTime);
        if(gameManager.GetCurrentWaterAmount() < pumpDrawHeight)
        gameManager.SetCurrentWaterAmount(pumpDrawHeight);
        
        Debug.Log(gameManager.GetCurrentWaterAmount());
    }
}
